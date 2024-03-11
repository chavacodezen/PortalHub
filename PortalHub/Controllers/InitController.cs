using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using PortalHub.Models;
using PortalHub.Resources;
using PortalHub.Services.Contract;

namespace PortalHub.Controllers
{
    public class InitController : Controller
    {
        private readonly IUserService _userService;

        public InitController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            // Check if the EmployeeNo already exists in the database
            bool isEmployeeNoExists = await _userService.UserExists(model.EmployeeNo);

            if (isEmployeeNoExists)
            {
                ViewData["Mensaje"] = "Este empleado ya fue registrado. Por favor, revise sus datos.";
                return View();
            }

            // If the EmployeeNo doesn't exist, proceed with user creation
            model.PasswordHash = Utils.EncryptPassword(model.PasswordHash);

            User user_created = await _userService.SaveUser(model);

            if (user_created.IdUser > 0)
                return RedirectToAction("LogIn", "Init");

            ViewData["Mensaje"] = "No se pudo crear el usuario.";

            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(int employeeNo, string password)
        {
            User user_found = await _userService.GetUser(employeeNo, Utils.EncryptPassword(password));

            if (user_found == null)
            {
                ViewData["Mensaje"] = "No se encontró al usuario, verifique sus datos.";
            }
            else
            {
                ClaimsPrincipal claimsPrincipal = await _userService.CreateClaimsPrincipalAsync(user_found);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal,
                    new AuthenticationProperties
                    {
                        AllowRefresh = true
                    }
                );

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
