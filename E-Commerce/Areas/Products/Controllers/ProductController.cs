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

        public ProductController(IProductRepository productRepository, IFavouritesRepository favouritesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
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
        [Route("Admin/product/create")]
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
        [Route("Admin/product/create")]
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
                return RedirectToAction("GetAllProductsForAdmin", "Product", "");

            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

           return View(productVM);
        }

        public ActionResult Edit(int id)
        {
            var prods = productRepository.GetAll();
            ViewBag.cats = prods.Select(p => p.Category).Distinct();
            ViewBag.favRepo = favouritesRepository;
            ViewBag.products = productRepository.GetAll();
            var p = productRepository.GetDetailsByID(id);
            EditProductViewModel viewModel = new()
            {
                Id = p.Id,
                Price = p.Price,
                Description = p.Description,
                Category = p.Category,
                Name = p.Name,
                URL = p.ImagesString
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProductViewModel productVM)
        {

            try {
                var imageUrl = productVM.URL;

                if (productVM.Image != null) // if a new image was uploaded
                {
                    var result = await photoService.UploadPhotoAsync(productVM.Image);
                    imageUrl = result.Url.ToString(); // update the image URL
                }
                else // if no new image was uploaded
                {
                    var Product = productRepository.GetDetailsByID(productVM.Id);
                    imageUrl = Product.ImagesString; // set the image URL to the current value
                }

                var product = new Models.Product
                {
                    Id = productVM.Id,
                    Name = productVM.Name,
                    Category = productVM.Category,
                    Price = productVM.Price,
                    Description = productVM.Description,
                    ImagesString = imageUrl
                };

                productRepository.UpdateProduct(productVM.Id, product);
                return RedirectToAction("GetAllProductsForAdmin", "Product", "");
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
                return RedirectToAction("GetAllProductsForAdmin", "Product", "");
            }
            catch
            {
                return View();
            }
        }


        [Route("Admin/product/all")]
        public IActionResult GetAllProductsForAdmin()
        {
            var products = productRepository.GetAll();
            return View(products);
        }

    }
}
