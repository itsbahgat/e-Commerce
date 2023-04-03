using E_Commerce.Areas.Admins.RepoServices;
using E_Commerce.Areas.FavouriteItems.RepoServices;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Products.RepoServices;
using E_Commerce.Interfaces;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace E_Commerce.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFavouritesRepository favouritesRepository;
        private readonly IPhotoService photoService;

        
        public ProductController(IProductRepository productRepository, IPhotoService photoService , IFavouritesRepository favouritesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.photoService = photoService;
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
            CreateProductViewModel viewModel = new CreateProductViewModel();
            return View(viewModel);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel productVM)
        {

            if (ModelState.IsValid)
            {
                var result = await photoService.UploadPhotoAsync(productVM.Image);

                var product = new Models.Product
                {
                    Name = productVM.Name,
                    Category = productVM.Category,
                    Price = productVM.Price,
                    Description = productVM.Description,
                    ImagesString = result.Url.ToString(),
                   
                };
                productRepository.Insert(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

           return View(productVM);
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
        public ActionResult Edit(int id, Models.Product product)
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
