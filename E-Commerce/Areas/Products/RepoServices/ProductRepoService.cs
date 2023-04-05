using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Models;

namespace E_Commerce.Areas.Products.RepoServices
{
    public class ProductRepoService: IProductRepository
    {
        private readonly IdentityContext context;

        public ProductRepoService(IdentityContext context)
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


        public List<Models.Product> GetDetailsByCategory(string category)
        {
            var products = context.Products.Where(a => a.Category.ToLower() == category.ToLower()).ToList();
            if (products == null)
                return new List<Models.Product>();
            return products;
        }

        public Models.Product GetDetailsByID(int id)
        {
            var product = context.Products.FirstOrDefault(a => a.Id == id);
            if (product == null)
                return new Models.Product();
            return product;
        }

        public Models.Product GetDetailsByName(string name)
        {
            var product = context.Products.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            if (product == null)
                return new Models.Product();
            return product;
        }

        public void Insert(Models.Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(int id, Models.Product product)
        {
            var updatedProduct = context.Products.Find(id);
            if (updatedProduct == null)
                return;
            updatedProduct.Price = product.Price;
            updatedProduct.Category = product.Category;
            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            // not sure about the list in the views, we need to add or remove image link
            updatedProduct.ImagesString = product.ImagesString;
            //updatedProduct.Images = product.Images;
            context.SaveChanges();
            
        }

        List<Models.Product> IProductRepository.GetAll()
        {
            return context.Products.ToList();
        }

        List<Models.Product> IProductRepository.GetByPriceRange(int sm, int lg)
        {
            var products = context.Products.Where(a => a.Price >= sm && a.Price <= lg).ToList();
            if (products == null)
                return new List<Models.Product>();
            return products;
        }

        List<Models.Product> IProductRepository.GetDetailsByCategory(string category)
        {
            var products = context.Products.Where(a => a.Category.ToLower() == category.ToLower()).ToList();
            if (products == null)
                return new List<Models.Product>();
            return products;
        }
    }
}
