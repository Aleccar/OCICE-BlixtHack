using ClassLibrary.Data;

namespace ClassLibrary.Services;

public class CategoryService : ICategoryService {
    private readonly BlixtHackDbContext _context;

    public CategoryService(BlixtHackDbContext context) {
        _context = context;
    }

    public IEnumerable<Category> GetAllCategories() {
        var categories = _context.Categories.Select(c => new Category {
            Id = c.Id,
            Title = c.Title,
        });

        return categories;
    }

    public string GetCategoryNameById(int categoryId) {
        return _context.Categories.FirstOrDefault(c => c.Id == categoryId).Title;
    }
}