using E_Commerce.Areas.Admins.Models;
using E_Commerce.Areas.Admins.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace E_Commerce.Areas.Admins.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            ViewBag.admins = adminRepository.GetAll();
            return View(adminRepository.GetAll());
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View(adminRepository.GetDetailsByID(id));
        }

        // GET: AdminController/Details/sara
        public ActionResult Details(string name)
        {
            return View(adminRepository.GetDetailsByName(name));
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.trainees = adminRepository.GetAll();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            ViewBag.admins = adminRepository.GetAll();
            try
            {
                adminRepository.Insert(admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.admins = adminRepository.GetAll();
            return View(adminRepository.GetDetailsByID(id));
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Admin admin)
        {
            ViewBag.admins = adminRepository.GetAll();
            try
            {
                adminRepository.UpdateAdmin(id, admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.admins = adminRepository.GetAll();
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.admins = adminRepository.GetAll();
            try
            {
                adminRepository.DeleteAdmin(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
