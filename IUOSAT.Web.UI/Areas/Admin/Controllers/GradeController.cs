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
    public class GradeController : Controller
    {
        private readonly IGradeRepository _GradeRepository;

        public GradeController(IGradeRepository GradeRepository)
        {
            _GradeRepository = GradeRepository;
        }
        public IActionResult Index()
        {
            return View(_GradeRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Person());
        }
        public ViewResult Edit(int id)
        {
            var result = _GradeRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Grade grade)
        {
           
            if (ModelState.IsValid)
            {
                _GradeRepository.SaveGrade(grade);
                TempData["message"] = $"{grade.PersianName} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(grade);
            }
        }
        public IActionResult Delete(int id)
        {
            _GradeRepository.DeleteGrade(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _GradeRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.GradeID, text = c.PersianName })) });
        }
    }
}