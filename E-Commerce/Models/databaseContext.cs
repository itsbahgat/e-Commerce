using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Cart.Models;

using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class databaseContext: DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options):base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


    }
}
