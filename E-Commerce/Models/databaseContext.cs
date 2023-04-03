using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.FavouriteItems.Models;
using E_Commerce.Areas.Identity.Data;
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
        public DbSet<Product> Products { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<E_CommerceUser> Customers { get; set; }
        public DbSet<FavouriteItemsRelation> Favourites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteItemsRelation>()
            .HasKey(f => new { f.E_CommerceUserId, f.ProductId });

            modelBuilder.Entity<FavouriteItemsRelation>()
                .HasOne(e => e.E_CommerceUser)
                .WithMany(c => c.FavouriteItemsRelation)
                .HasForeignKey(e => e.E_CommerceUserId);

            modelBuilder.Entity<FavouriteItemsRelation>()
                .HasOne(e => e.Product)
                .WithMany(c => c.FavouriteItemsRelation)
                .HasForeignKey(e => e.ProductId);
        }
    }
}
