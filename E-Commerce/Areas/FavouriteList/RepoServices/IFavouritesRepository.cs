using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.FavouriteList.Models;
using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.FavouriteList.RepoServices
{
    public interface IFavouritesRepository
    {
        public List<FavouriteItems> GetAll(int custId);
        public void AddItemToFav(FavouriteItems favourite);
        //public void AddItemToFav(int custId, int prodId);
        public void RemoveItemFromFav(int custId, int prodId);

        public List<Product> GetAllProducts();
        public List<Customer> GetAllCustomers();
    }
}
