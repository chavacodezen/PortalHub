using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalHub.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace PortalHub.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string firstName = "";
            string lastName = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                firstName = claimUser.Claims.Where(c => c.Type == "FirstName").Select(c => c.Value).SingleOrDefault();
                lastName = claimUser.Claims.Where(c => c.Type == "LastName").Select(c => c.Value).SingleOrDefault();
            }

            ViewData["userName"] = $"{firstName} {lastName}";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("LogIn", "Init");
        }
    }
}
