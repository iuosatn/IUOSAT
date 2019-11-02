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
    public class CourceController : Controller
    {
        private readonly ICourceRepository _CourceRepository;

        public CourceController(ICourceRepository courceRepository)
        {
            _CourceRepository = courceRepository;
        }
        public IActionResult Index()
        {
            return View(_CourceRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Cource());
        }
        public ViewResult Edit(int id)
        {
            var result = _CourceRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Cource cource)
        {
         
            if (ModelState.IsValid)
            {
                _CourceRepository.SaveCource(cource);
                TempData["message"] = $"{cource.PersianName} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(cource);
            }
        }
        public IActionResult Delete(int id)
        {
            _CourceRepository.DeleteCource(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _CourceRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.CourceID, text = c.PersianName })) });
        }
    }
}