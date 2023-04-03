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

        //// GET: FavouriteController/Create
        //[Route("Favourite/Create")]
        //public ActionResult Create()
        //{
        //    ViewBag.Customers = favouritesRepository.GetAllCustomers().Distinct();
        //    ViewBag.Products = favouritesRepository.GetAllProducts();
        //    return View();
        //}

        //// POST: FavouriteController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("Favourite/Create")]
        //public ActionResult Create(FavouriteItemsRelation favourite)
        //{
        //    //ViewBag.Customers = favouritesRepository.GetAllCustomers();
        //    //ViewBag.Products = favouritesRepository.GetAllProducts();
        //    try
        //    {
        //        favouritesRepository.AddItemToFav(favourite);
        //        //return RedirectToAction(nameof(Index));
        //        return RedirectToAction("Index", "Favourite", new { custId = favourite.E_CommerceUserId });
        //    }
        //    catch
        //    {
        //        //Console.WriteLine("err");
        //        return View();
        //    }
        //}

        //// GET: FavouriteController/Create
        //[Route("Favourite/Create/{custId}/{prodId}")]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: FavouriteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Favourite/Create/{custId}/{prodId}")]
        public ActionResult Create(string custId, int prodId)
        {
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
                return View();
            }
        }

        // GET: FavouriteController/Delete/5
        [Route("Favourite/Delete/{custId}/{prodId}")]
        public ActionResult Delete(string custId, int prodId)
        {
            return View(favouritesRepository.GetAll(custId).FirstOrDefault(f => f.ProductId == prodId));
            //return RedirectToAction(nameof(Index));
        }

        // POST: FavouriteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Favourite/Delete/{custId}/{prodId}")]
        public ActionResult Delete(string custId, int prodId, FavouriteItemsRelation favourite)
        {
            try
            {
                favouritesRepository.RemoveItemFromFav(favourite.E_CommerceUserId, favourite.ProductId);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Favourite", new { custId = favourite.E_CommerceUserId });
            }
            catch
            {
                return View();
            }
        }
    }
}
