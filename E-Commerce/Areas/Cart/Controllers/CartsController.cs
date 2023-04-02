using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Areas.Cart.Models;
using E_Commerce.Models;
using System.Security.Claims;

namespace E_Commerce.Areas.Cart.Controllers
{
    [Area("Cart")]
    [Route("cart")]
    public class CartsController : Controller
    {
        private readonly databaseContext _context;

        public CartsController(databaseContext context)
        {
            _context = context;
        }


        [HttpGet("{customerId}/Carts")]
        public async Task<IActionResult> GetCartsForCustomer(int customerId)
        {
            var carts = await _context.Carts
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();

            if (carts == null)
            {
                return NotFound();
            }

            return Ok(carts);
        }

        [HttpPost("{customerId}/AddToCart/{productId}")]
        public async Task<IActionResult> AddToCart(int customerId, int productId, int quantity)
        {
            // Find the cart for the customer
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId && !c.IsCompleted);

            // If no cart exists, create a new one
            if (cart == null)
            {
                cart = new Models.Cart { CustomerId = customerId, IsCompleted = false };
                _context.Carts.Add(cart);
            }

            // Find the product
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);


            // If the product doesn't exist, return a not found result
            if (product == null)
            {
                return NotFound();
            }

            // Add the product to the cart
            cart.AddItem(product, quantity);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated cart
            return Ok(cart);
        }


    }
}
