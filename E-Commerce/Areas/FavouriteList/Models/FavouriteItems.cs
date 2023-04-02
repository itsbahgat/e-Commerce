using E_Commerce.Areas.Customers.Models;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Areas.FavouriteList.Models
{
    public class FavouriteItems
    {
        [ForeignKey("Customer")]
        //[Key]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        //public string CustomerId { get; set; }
        //public virtual E_CommerceUser Customer { get; set; }

        [ForeignKey("Product")]
        // [Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
