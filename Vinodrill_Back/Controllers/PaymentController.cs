using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vinodrill_Back.Models.EntityFramework;
using Stripe;
using Vinodrill_Back.Models.Auth;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Vinodrill_Back.Models.Repository;
using Stripe.Checkout;

namespace Vinodrill_Back.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IDataRepository<Adresse> adresseRepository;
        private readonly IcommandeRepository commandeRepository;
        private readonly IDataRepository<Reservation> reservationRepository;
        private readonly IDataRepository<Paiement> paiementRepository;
        private readonly IBonreductionRepository bonReductionRepository;

        public PaymentController(IDataRepository<Adresse> adresseRepo, IBonreductionRepository bonReductionRepo, IcommandeRepository commandeRepo, IDataRepository<Reservation> reservationRepo, IDataRepository<Paiement> paiementRepo)
        {
            adresseRepository = adresseRepo;
            commandeRepository = commandeRepo;
            reservationRepository = reservationRepo;
            paiementRepository = paiementRepo;
            bonReductionRepository = bonReductionRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("checkout")]
        public async Task<IActionResult> Checkout(List<Article> articles, bool saveCredentials, int idAdresse, bool estCheque, string emailClient, List<ReservationModel> reservations, string noteCommande = "", string? coupon = null)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

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
            foreach(Article article in articles) {
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
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
                Customer = customer.Id,
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

            var service = new SessionService();

            Session session = service.Create(stripe_option);
            
            AdditionnalData additionalData = new AdditionnalData {
                ChequeCadeau = "true",
                EstCadeau = false,
                IdClient = 1,
                SaveCredentials = saveCredentials,
                Reservations = reservations,
                NoteCommande = noteCommande,
                StripeCustomerId = customer.Id,
                Coupon = coupon,
                SessionId = session.Id,
                EstCheque = estCheque,
            };

            string additionalDataJson = JsonConvert.SerializeObject(additionalData);

            httpContextAccessor.HttpContext.Session.SetString("additional_data", additionalDataJson);

            return Ok(new { id = session.Id });
        }

        [HttpPost]
        [Authorize]
        [Route("checkout/success")]
        public async Task<IActionResult> CheckoutSuccess()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            string additionalDataJson = httpContextAccessor.HttpContext.Session.GetString("additional_data");

            AdditionnalData additionalData = JsonConvert.DeserializeObject<AdditionnalData>(additionalDataJson);

            Session session = new SessionService().Get(additionalData.SessionId);

            PaymentIntent paymentIntent = new PaymentIntentService().Get(session.PaymentIntentId);

            PaymentMethod paymentMethod = new PaymentMethodService().Get(paymentIntent.PaymentMethodId);

            // create a new command
            int idCommande = await commandeRepository.Add(new Commande {
                IdClient = additionalData.IdClient,
                DateCommande = DateTime.Now,
                Message = additionalData.NoteCommande,
                PrixCommande = paymentIntent.Amount / 100,
                Quantite = 1,
                CheminFacture = session.Invoice.HostedInvoiceUrl,
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

            return Redirect($"{Environment.GetEnvironmentVariable("FRONTEND_URL")}/paiement/merci?session_id={session.Id}&refcommande={idCommande}");
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
        public string SessionId { get; set; }
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
        public int Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
