using Microsoft.AspNetCore.Mvc;
using OCICE_BlixtHack.Models;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace OCICE_BlixtHack.Viewcomponents
{
    public class CategoriesSidebarViewComponent : ViewComponent
    {
        private readonly BlixtHackDbContext _context;

        public CategoriesSidebarViewComponent(BlixtHackDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .ToListAsync();

            var model = new CategoriesVM
            {
                Categories = categories
            };

            return View(model);
        }
    }
}
