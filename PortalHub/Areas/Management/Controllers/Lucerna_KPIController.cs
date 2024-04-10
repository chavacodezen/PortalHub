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
            int employeeNo = 0;
            string firstName = "";
            string lastName = "";
            string departmentName = "";

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
                    departmentName = GetDepartmentNameFromDb(parsedIdDepartment);
                }
            }

            ViewData["employeeNo"] = employeeNo;
            ViewData["userName"] = $"{firstName} {lastName}";
            ViewData["firstName"] = firstName;
            ViewData["lastName"] = lastName;
            ViewData["departmentName"] = departmentName;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lucerna_KPI model)
        {
            int employeeNo = model.EMPLOYEE_NO;
            return View();
        }

        private string GetDepartmentNameFromDb(int idDepartment)
        {
            // Query the database to get the department name based on idDepartment
            // Replace this with your actual database query logic
            // For demonstration, let's assume you have a method to query department name
            return YourDatabaseService.GetDepartmentName(idDepartment);
        }
    }
}
