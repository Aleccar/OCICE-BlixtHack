using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OCICE_BlixtHack.Controllers
{
    [Authorize(Roles = "Admin")] //TODO: LÄGG TILL I DELETE-METODER
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
