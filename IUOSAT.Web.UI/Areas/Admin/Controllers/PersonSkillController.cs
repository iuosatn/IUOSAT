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
    public class PersonSkillController : Controller
    {
        private readonly IPersonSkillRepository _PersonSkillRepository;

        public PersonSkillController(IPersonSkillRepository PersonSkillRepository)
        {
            _PersonSkillRepository = PersonSkillRepository;
        }
        public IActionResult Index()
        {
            return View(_PersonSkillRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new PersonSkill());
        }
        public ViewResult Edit(int id)
        {
            var result = _PersonSkillRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(PersonSkill PersonSkill)
        {
          
            if (ModelState.IsValid)
            {
                _PersonSkillRepository.SavePersonSkill(PersonSkill);
                TempData["message"] = $"{PersonSkill.Skill} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(PersonSkill);
            }
        }
        public IActionResult Delete(int id)
        {
            _PersonSkillRepository.DeletePersonSkill(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
     
    }
}