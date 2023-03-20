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
using Microsoft.AspNetCore.WebUtilities;

namespace Vinodrill_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IDataRepository<Adresse> adresseRepository;
        private readonly IcommandeRepository commandeRepository;
        private readonly IDataRepository<Reservation> reservationRepository;
        private readonly IPaiementRepository paiementRepository;
        private readonly IBonreductionRepository bonReductionRepository;
        private readonly StripeOptions _stripeOptions;
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration, IOptions<StripeOptions> stripeOptions, IDataRepository<Adresse> adresseRepo, IBonreductionRepository bonReductionRepo, IcommandeRepository commandeRepo, IDataRepository<Reservation> reservationRepo, IPaiementRepository paiementRepo)
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
        public async Task<IActionResult> Checkout( [FromBody] RequestBody requestBody)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            StripeConfiguration.ApiKey = _stripeOptions.Secret;

            // check if a user exists with the email
            Customer customer = new Customer();
            CustomerService customerService = new CustomerService();
            StripeList<Customer> customers = customerService.List(new CustomerListOptions
            {
                Email = requestBody.EmailClient
            });

            var adresse = await adresseRepository.GetById(requestBody.IdAdresse);

            // if the user doesn't exist, create a new one
            if (customers.Data.Count == 0)
            {
                customer = customerService.Create(new CustomerCreateOptions
                {
                    Email = requestBody.EmailClient,
                    Name = requestBody.NomClient,
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
            foreach(Article article in requestBody.Articles) {
                lineItems.Add(new SessionLineItemOptions {
                    PriceData = new SessionLineItemPriceDataOptions {
                        UnitAmount = article.Price,
                        Currency = "eur",
                        ProductData = new SessionLineItemPriceDataProductDataOptions {
                            Name = article.Name,
                            Images = new List<string> {
                                article.Image,
                            },
                            Description = article.Description,
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

            if(requestBody.Coupon is not null) {
                // check if the coupon already exists in stripe
                var couponService = new CouponService();
                try {
                    var couponStripe = couponService.Get(requestBody.Coupon);
                } catch (StripeException e) {
                    // if the coupon doesn't exist, create it
                    if (e.StripeError.Code == "resource_missing") {
                        var bonReduction = await bonReductionRepository.getByCode(requestBody.Coupon);
                        var amountOff = await bonReductionRepository.getAmount(bonReduction.Value);
                        couponService.Create(new CouponCreateOptions {
                            Id = requestBody.Coupon,
                            Duration = "once",
                            AmountOff = (long)amountOff.Value * 100,
                            Currency = "eur",
                        });
                    }
                }

                // apply the coupon to the payment intent
                stripe_option.Discounts = new List<SessionDiscountOptions> {
                    new SessionDiscountOptions {
                        Coupon = requestBody.Coupon,
                    },
                };
            }

            if(requestBody.SaveCredentials) {
                stripe_option.PaymentIntentData = new SessionPaymentIntentDataOptions {
                    SetupFutureUsage = "on_session",
                };
            }
            
            AdditionnalData additionalData = new AdditionnalData {
                ChequeCadeau = "true",
                EstCadeau = false,
                IdClient = requestBody.IdClient,
                SaveCredentials = requestBody.SaveCredentials,
                Reservations = requestBody.Reservations,
                NoteCommande = requestBody.NoteCommande,
                StripeCustomerId = customer.Id,
                Coupon = requestBody.Coupon,
                EstCheque = requestBody.EstCheque,
            };

            string jwtToken = GenerateJwtToken(additionalData);

            // encode the jwt token to be url safe
            jwtToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(jwtToken));

            stripe_option.SuccessUrl += "/{CHECKOUT_SESSION_ID}";

            stripe_option.SuccessUrl += $"/{jwtToken}";
            
            var service = new SessionService();

            Session session = service.Create(stripe_option);

            return Ok(new { checkoutURL = session.Url });
        }

        [HttpGet]
        [Authorize]
        [Route("checkout/success/{session_id}/{jwt}")]
        public async Task<IActionResult> CheckoutSuccess(string session_id, string jwt)
        {
            StripeConfiguration.ApiKey = _stripeOptions.Secret;

            AdditionnalData additionalData = new AdditionnalData();

            try {
                string decodedJwt = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(jwt));
                additionalData = ReadJwtToken(decodedJwt);
            } catch(Exception e) {
                return BadRequest(new { error = "Invalid JWT token" });
            }

            Session session = new SessionService().Get(session_id);

            PaymentIntent paymentIntent = new PaymentIntentService().Get(session.PaymentIntentId);

            PaymentMethod paymentMethod = new PaymentMethodService().Get(paymentIntent.PaymentMethodId);

            var paiment = await paiementRepository.Add(new Paiement {
                IdClientPaiement = additionalData.IdClient,
                LibellePaiement = paymentMethod.Card.Brand,
                PreferencePaiement = additionalData.SaveCredentials,
            });

            // create a new command
            int idCommande = await commandeRepository.Add(new Commande {
                IdClient = additionalData.IdClient,
                DateCommande = DateTime.Now,
                Message = additionalData.NoteCommande,
                PrixCommande = paymentIntent.Amount / 100,
                Quantite = 1,
                CheminFacture = session.InvoiceId,
                EstCheque = additionalData.EstCheque,
                IdPaiement = paiment.Value.IdPaiement,
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
                var coupon = await bonReductionRepository.getByCode(additionalData.Coupon);
                BonReduction bonReduction = coupon.Value;
                bonReduction.EstValide = false;
                await bonReductionRepository.Update(coupon.Value, bonReduction);
            }

            return Ok(new { idCommande = idCommande, session_id = session.Id });
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
        public bool SaveCredentials { get; set; }
        public int IdAdresse { get; set; }
        public bool EstCheque { get; set; }
        public string EmailClient { get; set; }
        public string? NoteCommande { get; set; } = "";
        public string? Coupon { get; set; } = null;
        public int IdClient { get; set;}
        public string NomClient { get; set; }
    }
}
