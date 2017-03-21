using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Abstractions.DataLayer;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        IRepoFactory db;

        public BlogController(IRepoFactory factory)
        {
            db = factory;
        }
        public IActionResult Index()
        {
            var models = db.GetBlogEntryRepo().GetAllBlogEntries();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
          var model = new BlogEntry();
          return View(model);
        }

        [HttpPost]
        public IActionResult Create([Bind("Title,Description")]BlogEntry blog)
        {
			try
			{
				if (ModelState.IsValid)
				{
					db.GetBlogEntryRepo().CreateEntry(blog);
					return RedirectToAction("Index");
				}
				else
				{

				}
			}
			catch (DbUpdateException ex)
			{
				ModelState.AddModelError("", "Unable To Save New Record!");
			}
				
  

		  return View(blog);
        }
    }
}
