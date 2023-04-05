using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Customers.Models;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Areas.CartNS.Models
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
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0.");
            }

            var existingCartItem = CartItems.FirstOrDefault(x => x.productID == product.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                var newCartItem = new CartItem
                {
                    productID = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    imageString = product.ImagesString,
                    Quantity = quantity,
                    CartId = this.Id,
                    // Cart = this // Set the Cart property to the current Cart instance
                };

                CartItems.Add(newCartItem);
            }
        }

        public void RemoveItem(int productId, int quantity)
        {
            var existingCartItem = CartItems.FirstOrDefault(x => x.productID == productId);
            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity > quantity)
                {
                    existingCartItem.Quantity -= quantity;
                }
                else
                {
                    CartItems.Remove(existingCartItem);
                }
            }
        }


        public void RemoveAllItems()
        {
            CartItems.Clear();
        }

    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string imageString { get; set; }

        public int Quantity { get; set; }

        public int productID { get; set; }

        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
    }
}
