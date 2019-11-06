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
    public class SkillController : Controller
    {
        private readonly ISkillRepository _SkillController;

        public SkillController(ISkillRepository SkillController)
        {
            _SkillController = SkillController;
        }
        public IActionResult Index()
        {
            return View(_SkillController.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Skill());
        }
        public ViewResult Edit(int id)
        {
            var result = _SkillController.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Skill skill)
        {

            if (ModelState.IsValid)
            {
                _SkillController.SaveSkill(skill);
                TempData["message"] = $"{skill.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(skill);
            }
        }
        public IActionResult Delete(int id)
        {
            _SkillController.DeleteSkill(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _SkillController.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.SkillID, text = c.Name })) });
        }
    }
}