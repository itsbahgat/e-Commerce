using System.ComponentModel.DataAnnotations;
using E_Commerce.Areas.FavouriteList.Models;
using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.Customers.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }


        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please enter a valid phone number.")]
        public string? PhoneNumber { get; set; }

        public string Address { get; set; }

        // For M:M relationship
        //ICollection<Product>? Products { get; set; }
        public  ICollection<FavouriteItems>? FavouriteItems { get; set; }

        //// Navigation properties for the CartItems class

        //public virtual ICollection<FavouriteItems>? CartItems { get; set; }

        //// Navigation properties for the PreviousPurchases class
        //public virtual ICollection<FavouriteItems>? PreviousPurchases { get; set; }
    }
}
