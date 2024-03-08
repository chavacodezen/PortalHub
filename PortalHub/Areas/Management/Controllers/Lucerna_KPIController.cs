using Microsoft.AspNetCore.Mvc;
using PortalHub.Areas.Management.Models;
using PortalHub.Models;
using PortalHub.Resources;
using System.Security.Claims;

namespace PortalHub.Areas.Management.Controllers
{
    [Area("Management")]
    public class Lucerna_KPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string userName = "";

            if (claimUser.Identity.IsAuthenticated)
            {
                userName = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            }

            ViewData["userName"] = userName;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            int employeeNo = model.EmployeeNo;

            ViewData["employeeNo"] = employeeNo;

            return View();
        }
    }
}
