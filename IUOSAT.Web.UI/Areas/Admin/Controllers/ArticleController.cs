using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IUOSAT.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _ArticleRepository;

        public ArticleController(IArticleRepository ArticleRepository)
        {
            _ArticleRepository = ArticleRepository;
        }
        public IActionResult Index()
        {
            return View(_ArticleRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Article());
        }
        public ViewResult Edit(int id)
        {
            var result = _ArticleRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Article Article)
        {
            
            if (ModelState.IsValid)
            {
                _ArticleRepository.SaveArticle(Article);
                TempData["message"] = $"{Article.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(Article);
            }
        }
        public IActionResult Delete(int id)
        {
            _ArticleRepository.DeleteArticle(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _ArticleRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.ArticleID, text = c.Name })) });
        }
    }
}