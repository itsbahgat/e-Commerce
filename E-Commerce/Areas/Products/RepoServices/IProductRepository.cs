using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.Products.RepoServices
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetDetailsByID(int id);
        public Product GetDetailsByName(string name);
        public List<Product> GetDetailsByCategory(string category);
        public void Insert(Product product);
        public void UpdateProduct(int id, Product admin);
        public void DeleteProduct(int id);
    }
}
