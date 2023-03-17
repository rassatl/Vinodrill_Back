using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Stripe;
using Vinodrill_Back.Models.Auth;
using Newtonsoft.Json;
using Vinodrill_Back.Models.Repository;
using Stripe.Checkout;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IDataRepository<Adresse> adresseRepository;
        private readonly IcommandeRepository commandeRepository;
        private readonly IDataRepository<Reservation> reservationRepository;
        private readonly IDataRepository<Paiement> paiementRepository;
        private readonly IBonreductionRepository bonReductionRepository;
        private readonly StripeOptions _stripeOptions;
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration, IOptions<StripeOptions> stripeOptions, IDataRepository<Adresse> adresseRepo, IBonreductionRepository bonReductionRepo, IcommandeRepository commandeRepo, IDataRepository<Reservation> reservationRepo, IDataRepository<Paiement> paiementRepo)
        {
            adresseRepository = adresseRepo;
            commandeRepository = commandeRepo;
            reservationRepository = reservationRepo;
            paiementRepository = paiementRepo;
            bonReductionRepository = bonReductionRepo;
            _stripeOptions = stripeOptions.Value;
            _configuration = configuration;
        }

        [HttpPost]
        //[Authorize]
        [Route("checkout")]
        public async Task<IActionResult> Checkout( [FromBody] RequestBody articlesAndReservations, bool saveCredentials, int idAdresse, bool estCheque, string emailClient, string noteCommande = "", string? coupon = null)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            StripeConfiguration.ApiKey = _stripeOptions.Secret;

            // check if a user exists with the email
            Customer customer = new Customer();
            CustomerService customerService = new CustomerService();
            StripeList<Customer> customers = customerService.List(new CustomerListOptions
            {
                Email = emailClient
            });

            var adresse = await adresseRepository.GetById(idAdresse);

            // if the user doesn't exist, create a new one
            if (customers.Data.Count == 0)
            {
                customer = customerService.Create(new CustomerCreateOptions
                {
                    Email = emailClient,
                    Name = "Jenny Rosen",
                    PreferredLocales = new List<string> { "fr" },
                    Address = new AddressOptions
                    {
                        City = adresse.Value?.VilleAdresse,
                        Country = adresse.Value?.PaysAdresse,
                        Line1 = adresse.Value?.RueAdresse,
                        PostalCode = adresse.Value?.CodePostalAdresse,
                    }
                });
            } else {
                customer = customers.Data[0];

                // update the customer's address if it's different
                if (customer.Address.City != adresse.Value?.VilleAdresse || customer.Address.Country != adresse.Value.PaysAdresse || customer.Address.Line1 != adresse.Value.RueAdresse || customer.Address.PostalCode != adresse.Value.CodePostalAdresse)
                {
                    customerService.Update(customer.Id, new CustomerUpdateOptions
                    {
                        Address = new AddressOptions
                        {
                            City = adresse.Value?.VilleAdresse,
                            Country = adresse.Value?.PaysAdresse,
                            Line1 = adresse.Value?.RueAdresse,
                            PostalCode = adresse.Value?.CodePostalAdresse,
                        }
                    });
                }
            }

            //create lineItems List
            List<SessionLineItemOptions> lineItems = new List<SessionLineItemOptions>();
            foreach(Article article in articlesAndReservations.Articles) {
                lineItems.Add(new SessionLineItemOptions {
                    PriceData = new SessionLineItemPriceDataOptions {
                        UnitAmount = article.Price * 100,
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions {
                            Name = article.Name,
                            Images = new List<string> {
                                article.Image,
                            },
                        },
                    },
                    Quantity = article.Quantity,
                });
            }

            // create a payment intent
            SessionCreateOptions stripe_option = new SessionCreateOptions {
                PaymentMethodTypes = new List<string> {
                    "card",
                },
                // create line items for each article
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = _stripeOptions.SuccessUrl,
                CancelUrl = _stripeOptions.CancelUrl + "?session_id={CHECKOUT_SESSION_ID}",
                Customer = customer.Id,
                InvoiceCreation = new SessionInvoiceCreationOptions {
                    Enabled = true,
                },
            };

            if(coupon is not null) {
                // check if the coupon already exists in stripe
                var couponService = new CouponService();
                try {
                    var couponStripe = couponService.Get(coupon);
                } catch (StripeException e) {
                    // if the coupon doesn't exist, create it
                    if (e.StripeError.Code == "resource_missing") {
                        couponService.Create(new CouponCreateOptions {
                            Id = coupon,
                            Duration = "once",
                            AmountOff = 1000,
                        });
                    }
                }

                // apply the coupon to the payment intent
                stripe_option.Discounts = new List<SessionDiscountOptions> {
                    new SessionDiscountOptions {
                        Coupon = coupon,
                    },
                };
            }

            if(saveCredentials) {
                stripe_option.PaymentIntentData = new SessionPaymentIntentDataOptions {
                    SetupFutureUsage = "on_session",
                };
            }
            
            AdditionnalData additionalData = new AdditionnalData {
                ChequeCadeau = "true",
                EstCadeau = false,
                IdClient = 1,
                SaveCredentials = saveCredentials,
                Reservations = articlesAndReservations.Reservations,
                NoteCommande = noteCommande,
                StripeCustomerId = customer.Id,
                Coupon = coupon,
                EstCheque = estCheque
            };

            string jwtToken = GenerateJwtToken(additionalData);

            stripe_option.SuccessUrl += $"?jwt={jwtToken}";

            stripe_option.SuccessUrl += "&session_id={CHECKOUT_SESSION_ID}";

            var service = new SessionService();

            Session session = service.Create(stripe_option);

            return Ok(new { checkoutURL = session.Url });
        }

        [HttpGet]
        [Route("checkout/success")]
        public async Task<IActionResult> CheckoutSuccess(string session_id, string jwt)
        {
            StripeConfiguration.ApiKey = _stripeOptions.Secret;

            AdditionnalData additionalData = ReadJwtToken(jwt);

            Session session = new SessionService().Get(session_id);

            PaymentIntent paymentIntent = new PaymentIntentService().Get(session.PaymentIntentId);

            PaymentMethod paymentMethod = new PaymentMethodService().Get(paymentIntent.PaymentMethodId);

            // create a new command
            int idCommande = await commandeRepository.Add(new Commande {
                IdClient = additionalData.IdClient,
                DateCommande = DateTime.Now,
                Message = additionalData.NoteCommande,
                PrixCommande = paymentIntent.Amount / 100,
                Quantite = 1,
                CheminFacture = session.InvoiceId,
                EstCheque = additionalData.EstCheque,
            });

            await paiementRepository.Add(new Paiement {
                IdClientPaiement = additionalData.IdClient,
                LibellePaiement = paymentMethod.Card.Brand,
                PreferencePaiement = additionalData.SaveCredentials,
            });

            List<ReservationModel> reservations = additionalData.Reservations;

            foreach(ReservationModel reservation in reservations) {
                await reservationRepository.Add(new Reservation {
                    RefCommande = idCommande,
                    IdSejour = reservation.IdSejour,
                    DateDebutReservation = reservation.DateDebutReservation,
                    EstCadeau = reservation.EstCadeau,
                    NbAdulte = reservation.NbAdultes,
                    NbEnfant = reservation.NbEnfants,
                    NbChambre = reservation.NbChambres,
                });
            }

            if(additionalData.Coupon is not null) {
                var coupon = await bonReductionRepository.GetByCode(additionalData.Coupon);
                BonReduction bonReduction = coupon.Value;
                bonReduction.EstValide = false;
                await bonReductionRepository.Update(coupon.Value, bonReduction);
            }

            return Redirect($"{_stripeOptions.FrontUrl}/paiement/merci?session_id={session.Id}&refcommande={idCommande}");
        }

        [HttpGet]
        [Route("checkout/cancel")]
        public RedirectResult CheckoutCancel(string session_id)
        {
            StripeConfiguration.ApiKey = _stripeOptions.Secret;

            var service = new SessionService();
            service.Expire(session_id);
            return Redirect($"{_stripeOptions.FrontUrl}/paiement?error=cancel");
        }

        private string GenerateJwtToken(AdditionnalData additionnalData)
        {
            var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("additional_data", JsonConvert.SerializeObject(additionnalData)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private AdditionnalData ReadJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var additionalData = jwtToken.Claims.First(x => x.Type == "additional_data").Value;
            return JsonConvert.DeserializeObject<AdditionnalData>(additionalData);
        }
    }

    internal class AdditionnalData
    {
        public string ChequeCadeau { get; set; }
        public bool EstCadeau { get; set; }
        public int IdClient { get; set; }
        public bool SaveCredentials { get; set; }
        public bool EstCheque { get; set; }
        public List<ReservationModel> Reservations { get; set; }
        public string NoteCommande { get; set; }
        public string StripeCustomerId { get; set; }
        public string? Coupon { get; set; }
    }

    public class ReservationModel 
    {
        public int IdSejour { get; set; }
        public DateTime DateDebutReservation { get; set; }
        public bool EstCadeau { get; set; }
        public int NbEnfants { get; set; }
        public int NbAdultes { get; set; }
        public int NbChambres { get; set; }
    }

    public class Article 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }

    public class RequestBody
    {
        public List<ReservationModel> Reservations { get; set; }
        public List<Article> Articles { get; set; }
    }
}
