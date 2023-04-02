using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.CartArea.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("E_CommerceUser")]
        public string E_CommerceUserId { get; set; }

        public virtual E_CommerceUser E_CommerceUser { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        [NotMapped]
        public decimal TotalPrice => CartItems?.Sum(x => x.Price * x.Quantity) ?? 0;

        public bool IsCompleted { get; set; }

        public void AddItem(Product product, int quantity)
        {
            var existingCartItem = CartItems.FirstOrDefault(x => x.Id == product.Id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(int productId)
        {
            var existingCartItem = CartItems.FirstOrDefault(x => x.Id == productId);
            if (existingCartItem != null)
            {
                CartItems.Remove(existingCartItem);
            }
        }

        public void Clear()
        {
            CartItems.Clear();
        }

        public void Checkout()
        {
            IsCompleted = true;
            // Additional logic for order completion (e.g. payment processing, shipping, etc.) could be added here
        }
    }

    public class CartItem : Product
    {
        public int Quantity { get; set; }
    }
}
