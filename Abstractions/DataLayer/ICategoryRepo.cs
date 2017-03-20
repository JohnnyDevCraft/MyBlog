using System.Collections.Generic;
using MyBlog.Models;

namespace MyBlog.Abstractions.DataLayer
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        Category CreateCategory(Category category);
        bool DeleteCategory(int id);
        Category UpdateCategory(Category category);

    }
}