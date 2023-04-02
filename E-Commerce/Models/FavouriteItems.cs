using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class FavouriteItems
    {
        [ForeignKey("E_CommerceUser")]
        //[Key]
        public int CustomerId { get; set; }
        public virtual E_CommerceUser Customer { get; set; }

        [ForeignKey("Product")]
       // [Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
