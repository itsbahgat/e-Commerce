using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Models;

namespace E_Commerce.Areas.Products.RepoServices
{
    public class ProductRepoService: IProductRepository
    {
        private readonly databaseContext context;

        public ProductRepoService(databaseContext context)
        {
            this.context = context;
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
                return;
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        //public Product GetDetailsByCategory(string category)
        //{
        //    var product = context.Products.FirstOrDefault(a => a.Category.ToLower() == category.ToLower());
        //    if (product == null)
        //        return new Product();
        //    return product;
        //}
        public List<Product> GetProductsByCategory(string category)
        {
            var products = context.Products.Where(a => a.Category.ToLower() == category.ToLower());
            if (products == null)
                return new List<Product>();
            return products.ToList();
        }

        public Product GetDetailsByID(int id)
        {
            var product = context.Products.FirstOrDefault(a => a.Id == id);
            if (product == null)
                return new Product();
            return product;
        }

        public Product GetDetailsByName(string name)
        {
            var product = context.Products.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            if (product == null)
                return new Product();
            return product;
        }

        public void Insert(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(int id, Product product)
        {
            var updatedProduct = context.Products.Find(id);
            if (updatedProduct == null)
                return;
            updatedProduct.Price = product.Price;
            updatedProduct.Category = product.Category;
            // not sure about the list in the views, we need to add or remove image link
            //updatedProduct.ImagesString = product.ImagesString;
            updatedProduct.Images = product.Images;
            context.SaveChanges();
        }
    }
}
