using E_Commerce.Areas.CartNS.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<E_CommerceUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<E_CommerceUser> E_CommerceUsers { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Product> Products { get; set; }


}
