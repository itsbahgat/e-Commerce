using System.ComponentModel.DataAnnotations;

using E_Commerce.Areas.Products.Models;
namespace E_Commerce.Areas.Customers.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must be numeric")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //public List<int> CartItems { get; set; }

        //public List<int> FavoriteItems { get; set; }

        //public List<int> PreviouslyBoughtItems { get; set; }

        public virtual ICollection<Product> Cart { get; set; }

        public virtual ICollection<Product> Favorites { get; set; }

        public virtual ICollection<Product> PreviousPurchases { get; set; }
    }
}
