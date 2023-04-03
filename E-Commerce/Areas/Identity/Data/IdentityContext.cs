using E_Commerce.Areas.FavouriteItems.Models;
﻿using E_Commerce.Areas.CartNS.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_Commerce.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<E_CommerceUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<FavouriteItemsRelation> FavouriteItemsRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FavouriteItemsRelation>()
            .HasKey(ab => new { ab.E_CommerceUserId, ab.ProductId });

        modelBuilder.Entity<FavouriteItemsRelation>()
            .HasOne(ab => ab.E_CommerceUser)
            .WithMany(a => a.FavouriteItemsRelation)
            .HasForeignKey(ab => ab.E_CommerceUserId);

        modelBuilder.Entity<FavouriteItemsRelation>()
            .HasOne(ab => ab.Product)
            .WithMany(b => b.FavouriteItemsRelation)
            .HasForeignKey(ab => ab.ProductId);
    }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<E_CommerceUser> E_CommerceUsers { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Product> Products { get; set; }


}
