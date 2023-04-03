using E_Commerce.Areas.FavouriteItems.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Areas.Products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Product description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }


        //public List<string> Images { get; set; }

        // Mapping for images property
        [Column("Images")]
        public string ImagesString
        {get; set; }

        public virtual ICollection<FavouriteItemsRelation> FavouriteItemsRelation { get; set; }


    }
}
