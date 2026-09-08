using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using OCICE_BlixtHack.Models;

namespace OCICE_BlixtHack.Viewcomponents;

public class CreateTopicModalViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CreateTopicModalViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var vm = new CreateTopicModalVM
        {
            Categories = _categoryService.GetAllCategories(),
        };

        return View(vm);
    }
}