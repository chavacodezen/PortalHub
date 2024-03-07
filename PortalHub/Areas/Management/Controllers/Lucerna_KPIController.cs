using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
