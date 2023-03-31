using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace E_Commerce.Areas.Payment
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys
            StripeConfiguration.ApiKey = "sk_test_51Mrkr2DMlYSWSoFpJ64FJZskIyxKDwaYUg7SFC3e26PbC3AfNK1e1fKZVz17cItcO5edPz8LhyWLRqlBwPFJppQy008roeSQsV";

            //invoice bill
            var options = new PaymentIntentCreateOptions
            {
                Amount = 1099,
                Currency = "usd",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };
            var service = new PaymentIntentService();
            var intent = service.Create(options);

            ViewData["ClientSecret"] = intent.ClientSecret;
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
