using E_Commerce.Areas.Customers.RepoServices;
using E_Commerce.Areas.FavouriteItems.Models;
using E_Commerce.Areas.FavouriteItems.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.FavouriteList.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouritesRepository favouritesRepository;

        public FavouriteController(IFavouritesRepository favouritesRepository)
        {
            this.favouritesRepository = favouritesRepository;
        }
        // GET: FavouriteController
        [Route("Favourite/{custId}")]
        public ActionResult Index(string custId)
        {
            return View(favouritesRepository.GetAll(custId));
        }
        [Route("Favourite/CreateFav/{custId}/{prodId}")]
        public ActionResult CreateFav(string custId, int prodId)
        {
            ViewBag.Customers = favouritesRepository.GetAllCustomers();
            ViewBag.Products = favouritesRepository.GetAllProducts();
            try
            {
                var favourite = new FavouriteItemsRelation { ProductId = prodId, E_CommerceUserId = custId };
                favouritesRepository.AddItemToFav(favourite);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Product");
                //return RedirectToAction("Index", "Favourite", new { custId = favourite.E_CommerceUserId });
            }
            catch
            {
                //return already added
                return RedirectToAction("Index", "Product");
                //return View();
            }
        }
        [Route("Favourite/DeleteFav/{custId}/{prodId}")]
        public ActionResult DeleteFav(string custId, int prodId)
        {
            try
            {
                favouritesRepository.RemoveItemFromFav(custId, prodId);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Product");
                //return RedirectToAction("Index", "Favourite", new { custId = custId });
            }
            catch
            {
                return RedirectToAction("Index", "Favourite", new { custId = custId });
            }
        }

    }
}
