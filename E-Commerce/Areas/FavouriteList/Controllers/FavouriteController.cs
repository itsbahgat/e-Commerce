using E_Commerce.Areas.Customers.RepoServices;
using E_Commerce.Areas.FavouriteList.Models;
using E_Commerce.Areas.FavouriteList.RepoServices;
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
        public ActionResult Index(int custId)
        {
            return View(favouritesRepository.GetAll(custId));
        }

        // GET: FavouriteController/Create
        [Route("Favourite/Create")]
        public ActionResult Create()
        {
            ViewBag.Customers = favouritesRepository.GetAllCustomers();
            ViewBag.Products = favouritesRepository.GetAllProducts();
            return View();
        }

        // POST: FavouriteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Favourite/Create")]
        public ActionResult Create(FavouriteItems favourite)
        {
            //ViewBag.Customers = favouritesRepository.GetAllCustomers();
            //ViewBag.Products = favouritesRepository.GetAllProducts();
            try
            {
                favouritesRepository.AddItemToFav(favourite);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Favourite", new { custId = favourite.CustomerId });
            }
            catch
            {
                //Console.WriteLine("err");
                return View();
            }
        }

        // GET: FavouriteController/Delete/5
        [Route("Favourite/Delete/{custId}/{prodId}")]
        public ActionResult Delete(int custId, int prodId)
        {
            return View(favouritesRepository.GetAll(custId).FirstOrDefault(f=>f.ProductId == prodId)) ;
            //return RedirectToAction(nameof(Index));
        }

        // POST: FavouriteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Favourite/Delete/{custId}/{prodId}")]
        public ActionResult Delete(int id, int prodId, FavouriteItems favourite)
        {
            try
            {
                favouritesRepository.RemoveItemFromFav(favourite.CustomerId, favourite.ProductId);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Favourite", new { custId = favourite.CustomerId });
            }
            catch
            {
                return View();
            }
        }
    }
}
