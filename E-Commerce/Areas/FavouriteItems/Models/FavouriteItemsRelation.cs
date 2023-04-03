using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.Models;

namespace E_Commerce.Areas.FavouriteItems.Models
{
    public class FavouriteItemsRelation
    {
        public string E_CommerceUserId { get; set; }
        public E_CommerceUser E_CommerceUser { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
