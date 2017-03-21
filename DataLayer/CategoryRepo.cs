using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyBlog.Abstractions.DataLayer;
using MyBlog.Models;

namespace MyBlog.DataLayer
{
    public class CategoryRepo : ICategoryRepo
    {
        AppDbContext db;
        public CategoryRepo(AppDbContext context)
        {
            db = context;
        }
        public Category CreateCategory(Category category)
        {
            db.Categories.Attach(category);
            db.Entry<Category>(category).State = EntityState.Added;
            db.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int id)
        {
            var cat = db.Categories.Find(id);
            db.Entry<Category>(cat).State = EntityState.Deleted;
            db.SaveChanges();
            return true;

        }

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

		public Category GetCategory(string name)
		{
			return db.Categories.FirstOrDefault(c => c.Name == name);
		}

		public List<Category> SearchCategory(string search)
		{
			return db.Categories.Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
		}

		public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public Category UpdateCategory(Category category)
        {
            db.Categories.Attach(category);
            db.Entry<Category>(category).State = EntityState.Modified;
            db.SaveChanges();
            return category;
        }
    }
}