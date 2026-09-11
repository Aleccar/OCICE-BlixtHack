using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using ClassLibrary.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OCICE_BlixtHack.Models;
using System.Security.Claims;

namespace OCICE_BlixtHack.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlixtHackDbContext _context;
        private readonly ILogger<AccountController> _logger;
        public AccountController(BlixtHackDbContext context)
        {
            _context = context;
        }
        public IActionResult UserLogin(LoginDTO ul)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var adminTest = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);

            if (adminTest == null || adminTest.IsAdmin == false)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            if (adminTest.Password != model.Password)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            var claims = new List<Claim> //TODO:kolla upp 
            {
            new Claim(ClaimTypes.NameIdentifier, adminTest.UserId.ToString()),
            new Claim(ClaimTypes.Name, adminTest.UserName),
            new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction("Index", "Home"); //TODO: skickar med Role: "Admin"
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
