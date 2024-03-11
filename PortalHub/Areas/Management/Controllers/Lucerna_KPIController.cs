using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PortalHub.Areas.Management.Models;
using PortalHub.Models;
using PortalHub.Resources;

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
            string firstName = "";
            string lastName = "";
            int employeeNo = 0;
            int idDepartment = 0;

            if (claimUser.Identity.IsAuthenticated)
            {
                firstName = claimUser.Claims.Where(c => c.Type == "FirstName").Select(c => c.Value).SingleOrDefault();
                lastName = claimUser.Claims.Where(c => c.Type == "LastName").Select(c => c.Value).SingleOrDefault();

                string employeeNoClaim = claimUser.Claims.Where(c => c.Type == "EmployeeNo").Select(c => c.Value).SingleOrDefault();
                if (!string.IsNullOrEmpty(employeeNoClaim) && int.TryParse(employeeNoClaim, out int parsedEmployeeNo))
                {
                    employeeNo = parsedEmployeeNo;
                }

                string idDepartmentClaim = claimUser.Claims.Where(c => c.Type == "IdDepartment").Select(c => c.Value).SingleOrDefault();
                if (!string.IsNullOrEmpty(idDepartmentClaim) && int.TryParse(idDepartmentClaim, out int parsedIdDepartment))
                {
                    idDepartment = parsedIdDepartment;
                }
            }

            ViewData["userName"] = $"{firstName} {lastName}";
            ViewData["employeeNo"] = employeeNo;
            ViewData["idDepartment"] = idDepartment;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lucerna_KPI model)
        {
            int employeeNo = model.EMPLOYEE_NO;
            return View();
        }
    }
}
