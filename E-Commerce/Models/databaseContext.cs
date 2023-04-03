using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.FavouriteItems.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.CartNS.Models;

using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class databaseContext: DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options):base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }

       // public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }



    }
}
