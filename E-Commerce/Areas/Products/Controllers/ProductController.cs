using E_Commerce.Areas.Admins.RepoServices;
using E_Commerce.Areas.FavouriteItems.RepoServices;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Products.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFavouritesRepository favouritesRepository;

        public ProductController(IProductRepository productRepository, IFavouritesRepository favouritesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
        }
        // GET: ProductController
        [Route("Product")]
        public ActionResult Index()
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetDetailsByID(id));
        }
        [Route("Product/DetailsByName/{name}")]
        public ActionResult DetailsByName(string name)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetDetailsByName(name));
        }

        [Route("Product/DetailsByCategory/{category}")]
        public ActionResult DetailsByCategory(string category)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetDetailsByCategory(category));
        }

        [Route("Product/GetByPriceRange/{sm}/{lg}")]
        public ActionResult GetByPriceRange(int sm, int lg)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetByPriceRange(sm, lg));
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {

            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            ViewBag.products = productRepository.GetAll();
            try
            {
                productRepository.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetDetailsByID(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                productRepository.UpdateProduct(id, product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productRepository.GetDetailsByID(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.admins = productRepository.GetAll();
            try
            {
                productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
