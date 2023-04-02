using E_Commerce.Areas.Customers.RepoServices;
using E_Commerce.Areas.Identity.Data;
using E_Commerce.Areas.Products.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Areas.Customers.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        // GET: CustomerController
        [Route("Customer")]
        public ActionResult Index()
        {
            return View(customerRepository.GetAll());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string id)
        {
            return View(customerRepository.GetDetailsByID(id));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.customers = customerRepository.GetAll();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(E_CommerceUser customer)
        {
            ViewBag.customers = customerRepository.GetAll();
            try
            {
                customerRepository.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.customers = customerRepository.GetAll();
            return View(customerRepository.GetDetailsByID(id));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, E_CommerceUser customer)
        {
            ViewBag.customers = customerRepository.GetAll();
            try
            {
                customerRepository.UpdateCustomer(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
