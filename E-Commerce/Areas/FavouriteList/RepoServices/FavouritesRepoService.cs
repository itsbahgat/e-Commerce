using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.FavouriteList.Models;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Areas.FavouriteList.RepoServices
{
    public class FavouritesRepoService : IFavouritesRepository
    {
        private readonly databaseContext context;

        public FavouritesRepoService(databaseContext context)
        {
            this.context = context;
        }
        public void AddItemToFav(FavouriteItems favourite)
        {
            context.Add(favourite);
            context.SaveChanges();
        }

        public List<FavouriteItems> GetAll(int custId)
        {
            return context.Favourites.Where(f=>f.CustomerId == custId).Include(f=>f.Product).Include(f=>f.Customer).ToList();
        }

        public void RemoveItemFromFav(int custId, int prodId)
        {
            var fav = context.Favourites.FirstOrDefault(f => f.CustomerId == custId && f.ProductId == prodId);
            if(fav == null)
            {
                return;
            }
            context.Favourites.Remove(fav);
            context.SaveChanges();
        }

        List<Customer> IFavouritesRepository.GetAllCustomers()
        {
            return context.Customers.ToList();
        }

        List<Product> IFavouritesRepository.GetAllProducts()
        {
            return context.Products.ToList();
        }
    }
}
