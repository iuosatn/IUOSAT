using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IUOSAT.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        public IActionResult Index()
        {
            return View(_CategoryRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Category());
        }
        public ViewResult Edit(int id)
        {
            var result = _CategoryRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _CategoryRepository.SaveCategory(category);
                TempData["message"] = $"{category.PersianName} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public IActionResult Delete(int id)
        {
            _CategoryRepository.DeleteCategory(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _CategoryRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.CategoryID, text = c.PersianName })) });
        }
    }
}