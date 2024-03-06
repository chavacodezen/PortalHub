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
            // Check if the Badge already exists in the database
            bool isBadgeExists = await _userService.UserExists(model.Badge);

            if (isBadgeExists)
            {
                ViewData["Mensaje"] = "Este empleado ya fue registrado. Por favor, revise sus datos.";
                return View();
            }

            // If the Badge doesn't exist, proceed with user creation
            model.PasswordHash = Utils.EncryptPassword(model.PasswordHash);

            User user_created = await _userService.SaveUser(model);

            if (user_created.Id > 0)
                return RedirectToAction("LogIn", "Init");

            ViewData["Mensaje"] = "No se pudo crear el usuario.";

            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string badge, string password)
        {
            User user_found = await _userService.GetUser(badge, Utils.EncryptPassword(password));

            if (user_found == null)
            {
                ViewData["Mensaje"] = "No se encontró al usuario, verifique sus datos.";
            }
            else
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user_found.Name ?? "UnknownUser")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}
