using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using ClassLibrary.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OCICE_BlixtHack.Models;
using System.Security.Claims;

namespace OCICE_BlixtHack.Controllers
{
    public class AccountController : Controller
    {
        private readonly BlixtHackDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public AccountController(BlixtHackDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }
        //public IActionResult UserLogin(LoginDTO ul)
        //{
        //    return View();
        //}
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
            var admin = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);

            if (admin == null || admin.IsAdmin == false)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            var result = _passwordHasher.VerifyHashedPassword(
                admin, admin.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
            var claims = new List<Claim> //TODO:kolla upp
            {
            new Claim(ClaimTypes.NameIdentifier, admin.UserId.ToString()),
            new Claim(ClaimTypes.Name, admin.UserName),
            new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return RedirectToAction("Index", "Admin");
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
