using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using E_Commerce.Services;
using Microsoft.Extensions.DependencyInjection;
using E_Commerce.Models;
using E_Commerce.Areas.Products.RepoServices;
using E_Commerce.Interfaces;
using E_Commerce.Areas.Admins.RepoServices;

namespace E_Commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");
            var connectionStringDB = builder.Configuration.GetConnectionString("DbContextConnection") ?? throw new InvalidOperationException("Connection string 'DbContextConnection' not found.");

            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<databaseContext>(op => op.UseSqlServer(connectionStringDB));

            builder.Services.AddDefaultIdentity<E_CommerceUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddTransient<IPhotoService, PhotoService>();


            builder.Services.AddTransient<IProductRepository, ProductRepoService>();
            builder.Services.AddTransient<IAdminRepository, AdminRepoService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                    name: "adminProducts",
                    pattern: "Admin/product/all",
                    defaults: new { controller = "Product", action = "GetAllProductsForAdmin" });

            app.MapControllerRoute(
                    name: "adminProducts",
                    pattern: "Admin/product/create",
                    defaults: new { controller = "Product", action = "Create" });


            app.Run();
        }
    }
}