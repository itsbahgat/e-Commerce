
using E_Commerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace E_Commerce.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<E_CommerceUser> _userManager;

        public AdminController(UserManager<E_CommerceUser> userManager)
        {
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Customers()
        {
            var customers = await _userManager.GetUsersInRoleAsync("User");
            return View(customers);
        }
    }
}
