using System.Collections.Generic;
using MyBlog.Models;

namespace MyBlog.Abstractions.DataLayer
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
		Category GetCategory(string name);
		List<Category> SearchCategory(string search);
        Category CreateCategory(Category category);
        bool DeleteCategory(int id);
        Category UpdateCategory(Category category);

    }
}