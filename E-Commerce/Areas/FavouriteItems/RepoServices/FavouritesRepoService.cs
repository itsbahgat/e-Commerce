using E_Commerce.Areas.FavouriteItems.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Areas.FavouriteItems.RepoServices
{
    public class FavouritesRepoService : IFavouritesRepository
    {
        private readonly IdentityContext context;

        public FavouritesRepoService(IdentityContext context)
        {
            this.context = context;
        }
        public void AddItemToFav(FavouriteItemsRelation favourite)
        {
            context.Add(favourite);
            context.SaveChanges();
        }

        public List<FavouriteItemsRelation> GetAll(string custId)
        {
            return context.FavouriteItemsRelations.Where(f => f.E_CommerceUserId == custId).Include(f => f.Product).Include(f => f.E_CommerceUser).ToList();
        }

        public void RemoveItemFromFav(string custId, int prodId)
        {
            var fav = context.FavouriteItemsRelations.FirstOrDefault(f => f.E_CommerceUserId == custId && f.ProductId == prodId);
            if (fav == null)
            {
                return;
            }
            context.FavouriteItemsRelations.Remove(fav);
            context.SaveChanges();
        }

        List<E_CommerceUser> IFavouritesRepository.GetAllCustomers()
        {
            return context.Users.ToList();
        }

        List<Product> IFavouritesRepository.GetAllProducts()
        {
            return context.Products.ToList();
        }
    }
}
