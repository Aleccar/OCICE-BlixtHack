using ClassLibrary.Data;

namespace ClassLibrary.Services;

public interface ICategoryService {
    IEnumerable<Category> GetAllCategories();
    string GetCategoryNameById(int categoryId);
}