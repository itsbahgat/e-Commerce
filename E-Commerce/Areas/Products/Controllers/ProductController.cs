using E_Commerce.Areas.Admins.RepoServices;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Products.RepoServices;
using E_Commerce.Interfaces;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace E_Commerce.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IPhotoService photoService;

        public ProductController(IProductRepository productRepository, IPhotoService photoService)
        {
            this.productRepository = productRepository;
            this.photoService = photoService;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            ViewBag.products = productRepository.GetAll();
            return View(productRepository.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productRepository.GetDetailsByID(id));
        }
        public ActionResult DetailsByName(string name)
        {
            return View(productRepository.GetDetailsByName(name));
        }

        public ActionResult DetailsByCategory(string category)
        {
            return View(productRepository.GetDetailsByCategory(category));
        }

        [Route("Admin/product/all")]
        public IActionResult GetAllProductsForAdmin()
        {
            var products = productRepository.GetAll();
            return View(products);
        }



        [Route("Admin/product/create")]
        public ActionResult Create()
        {
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
            ViewBag.admins = productRepository.GetAll();
            return View(productRepository.GetDetailsByID(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Product product)
        {
            ViewBag.admins = productRepository.GetAll();
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
            ViewBag.admins = productRepository.GetAll();
            return View();
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
