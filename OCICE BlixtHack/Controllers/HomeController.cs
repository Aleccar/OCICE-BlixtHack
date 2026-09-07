using ClassLibrary.Data;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using OCICE_BlixtHack.Models;
using System.Diagnostics;

namespace OCICE_BlixtHack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly BlixtHackDbContext _context;
        private readonly ITopicService _topicService;

        public HomeController(ICategoryService categoryService, BlixtHackDbContext context, ITopicService topicService)
        {
            _categoryService = categoryService;
            _topicService = topicService;
            _context = context;
        }
        public IActionResult Index()
        {
            var categoryVM = new CategoriesVM();
            categoryVM.Categories = _categoryService.GetAllCategories();
            return View(categoryVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Categories()
        {
            var categoryVM = new CategoriesVM();
            categoryVM.Categories = _categoryService.GetAllCategories();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult Category(int categoryId) {
            var threadsVM = new TopicVM {
                Topics = _topicService.GetAllTopicsByCategoryId(categoryId),
                CategoryName = _categoryService.GetCategoryNameById(categoryId),
            };

            return View(threadsVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
