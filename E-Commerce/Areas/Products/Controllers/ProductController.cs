using E_Commerce.Areas.Admins.RepoServices;
using E_Commerce.Areas.Products.Models;
using E_Commerce.Areas.Products.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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


        // GET: ProductController/Create
        public ActionResult Create()
        {
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
            ViewBag.admins = productRepository.GetAll();
            return View(productRepository.GetDetailsByID(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
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
