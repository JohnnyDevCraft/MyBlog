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
	public class CategoryController : Controller
	{
		IRepoFactory db;

		public CategoryController(IRepoFactory factory)
		{
			db = factory;
		}

		public IActionResult Index()
		{
			var models = db.GetCategoryRepo().GetAllCategories();
			return View(models);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var model = new Category();
			return View(model);
		}

		[HttpPost]
		public IActionResult Create([Bind("Name,Description")] Category model)
		{
			if (ModelState.IsValid)
			{
				if(!db.GetCategoryRepo().SearchCategory(model.Name).Any())
				db.GetCategoryRepo().CreateCategory(model);
				return RedirectToAction("Index");
			}

			return View(model);
		}
	}
}
