using E_Commerce.Areas.FavouriteItems.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.FavouriteItems.RepoServices
{
    public interface IFavouritesRepository
    {
        public List<FavouriteItemsRelation> GetAll(string custId);
        public void AddItemToFav(FavouriteItemsRelation favourite);
        //public void AddItemToFav(int custId, int prodId);
        public void RemoveItemFromFav(string custId, int prodId);

        public List<Product> GetAllProducts();
        public List<E_CommerceUser> GetAllCustomers();
    }
}
