using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Areas.CartNS.Models;
using E_Commerce.Models;
using System.Security.Claims;
using E_Commerce.Areas.Identity.Data;

namespace E_Commerce.Areas.CartNS.Controllers
{
    [Area("Cart")]
    [Route("cart")]
    public class CartsController : Controller
    {
        private readonly IdentityContext _context;

        public CartsController(IdentityContext context)
        {
            _context = context;
        }


        [HttpGet("{customerId}/Orders")]
        public async Task<IActionResult> GetOrdersForCustomer(string customerId)
        {
            var carts = await _context.Carts
               .Include(c => c.CartItems)
               .Where(c => c.E_CommerceUserId == customerId && c.IsCompleted)
               .ToListAsync();


            if (carts == null)
            {
                return NotFound();
            }

            return Ok(carts);
        }

        [HttpGet("{customerId}/Cart")]
        public async Task<IActionResult> GetCartForCustomer(string customerId)
        {
            var cartItems = await _context.CartItems
                .Where(c => c.Cart.E_CommerceUserId == customerId && !c.Cart.IsCompleted)
                .ToListAsync();

            if (cartItems == null || !cartItems.Any())
            {
                return NotFound();
            }

            var response = cartItems.Select(c => new {
                c.Id,
                c.Name,
                c.Price,
                c.imageString,
                c.Quantity,
                c.CartId
            });

            return Ok(response);
        }


        [HttpPost("{customerId}/AddToCart/{productId}")]
        public async Task<IActionResult> AddToCart(string customerId, int productId, int quantity)
        {
            // Find the cart for the customer
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.E_CommerceUserId == customerId && !c.IsCompleted);

            // If no cart exists, create a new one
            if (cart == null)
            {
                cart = new Models.Cart { E_CommerceUserId = customerId, IsCompleted = false };
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
