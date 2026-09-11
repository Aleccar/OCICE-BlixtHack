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
        private readonly ITopicResponseService _topicResponseService;

        public HomeController(ICategoryService categoryService, BlixtHackDbContext context, ITopicService topicService, ITopicResponseService responceService)
        {
            _categoryService = categoryService;
            _topicService = topicService;
            _topicResponseService = responceService;
            _context = context;
        }

        public IActionResult Index()
        {
            var indexTopicsVM = new IndexTopicsVM
            {
                LatestTopics = _topicService.GetRecentTopics(5),
                LatestActiveTopics = _topicService.GetLatestActiveTopics(5),
                MostViewedTopics = _topicService.GetMostViewedTopics(5),
            };

            return View(indexTopicsVM);
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
        public IActionResult Category(int categoryId)
        {
            var topicsVM = new TopicVM
            {
                Topics = _topicService.GetAllTopicsByCategoryId(categoryId),
                CategoryName = _categoryService.GetCategoryNameById(categoryId),
            };

            return View(topicsVM);
        }

        public IActionResult Topic(int topicId)
        {
            var topicResponseVM = new TopicResponseVM
            {
                Topic = _topicService.GetTopicByTopicId(topicId),
                TopicResponses = _topicResponseService.GetAllTopicResponsesByTopicId(topicId),
            };

            _topicService.IncrementViewByTopicId(topicId);
            return View(topicResponseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Topic(TopicResponseVM topicResponseVM)
        {
            if (ModelState.IsValid) {
                _topicResponseService.CreateResponseByTopic(topicResponseVM.TopicResponseCreateDTO);
                return RedirectToAction("Topic", new { topicId = topicResponseVM.TopicResponseCreateDTO.TopicParentId });
            }

            topicResponseVM.Topic = _topicService.GetTopicByTopicId(topicResponseVM.TopicResponseCreateDTO.TopicParentId);
            topicResponseVM.TopicResponses = _topicResponseService.GetAllTopicResponsesByTopicId(topicResponseVM.TopicResponseCreateDTO.TopicParentId);
            return View(topicResponseVM);
        }

        [HttpPost]
        public IActionResult AddTopic(CreateTopicModalVM modelVM)
        {
            if (!ModelState.IsValid) {
                modelVM.Categories = _categoryService.GetAllCategories();
                return PartialView("Components/CreateTopicModal/Default", modelVM);
            }

            var createdTopic = modelVM.CreateTopicDTO;
            var category = _categoryService.GetCategoryById(modelVM.CreateTopicDTO.categoryId);
            var topic = _topicService.CreateTopic(createdTopic, category);
            TempData["success"] = "Lyckades skapa ny tråd!";
            return RedirectToAction("Topic", new { topicId = topic.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}