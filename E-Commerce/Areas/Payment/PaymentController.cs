﻿using Microsoft.AspNetCore.Mvc;
using E_Commerce.Areas.CartNS.Models;
using Stripe;
using E_Commerce.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce.Areas.Payment
{
    public class PaymentController : Controller
    {


        private readonly IdentityContext _context;

        public PaymentController(IdentityContext context)
        {
            _context = context;
        }

        public IActionResult Index(int cartID)
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys
            StripeConfiguration.ApiKey = "sk_test_51Mrkr2DMlYSWSoFpJ64FJZskIyxKDwaYUg7SFC3e26PbC3AfNK1e1fKZVz17cItcO5edPz8LhyWLRqlBwPFJppQy008roeSQsV";
            var _cart =  _context.Carts
                    .Include(c => c.CartItems)
                    .FirstOrDefault(c => c.Id == cartID);

            var _Amount = (long)_cart.TotalPrice * 100;
            //invoice bill
            var options = new PaymentIntentCreateOptions
            {
                Amount = _Amount,
                Currency = "usd",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };
            var service = new PaymentIntentService();
            var intent = service.Create(options);


            ViewData["ClientSecret"] = intent.ClientSecret;
            _cart.IsCompleted = true;
            _context.SaveChanges();

            return View();
        }

        [Authorize(Roles = "Admin")]
        [Route("Admin/orders/all")]
        public ActionResult ListPayments()
        {
            StripeConfiguration.ApiKey = "sk_test_51Mrkr2DMlYSWSoFpJ64FJZskIyxKDwaYUg7SFC3e26PbC3AfNK1e1fKZVz17cItcO5edPz8LhyWLRqlBwPFJppQy008roeSQsV";

            var options = new ChargeListOptions { Limit = 1000 };
            var service = new ChargeService();
            StripeList<Charge> charges = service.List(options);
            return View(charges);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
