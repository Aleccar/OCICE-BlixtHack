using ClassLibrary.Data.Models;

namespace ClassLibrary.Services;

public interface ICategoryService {
    IEnumerable<Category> GetAllCategories();
    string GetCategoryNameById(int categoryId);
    Category GetCategoryById(int id);
}