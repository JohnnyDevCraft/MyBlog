using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGetAttribute]
        public IActionResult Create()
        {
          var model = new BlogEntry();
          return View(model);
        }
    }
}
