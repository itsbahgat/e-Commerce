using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class databaseContext: DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options):base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FavouriteItems> Favourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteItems>()
            .HasKey(f => new { f.CustomerId, f.ProductId });


            modelBuilder.Entity<FavouriteItems>()
                .HasOne(e => e.Customer)
                .WithMany(c => c.FavouriteItems)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<FavouriteItems>()
                .HasOne(e => e.Product)
                .WithMany(c => c.FavouriteItems)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
