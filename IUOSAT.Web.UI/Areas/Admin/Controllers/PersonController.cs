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
    public class PersonController : Controller
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonController(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }
        public IActionResult Index()
        {
            return View(_PersonRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View("Edit", new Person());
        }
        public ViewResult Edit(int id)
        {
            var result = _PersonRepository.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Person person, IFormFile files)
        {
            if (files?.Length > 0)
            {


                using (var ms = new MemoryStream())
                {
                    files.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    person.Image = fileBytes;
                }


            }
            if (ModelState.IsValid)
            {
                _PersonRepository.SavePerson(person);
                TempData["message"] = $"{person.PersianFullName} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }
        public IActionResult Delete(int id)
        {
            _PersonRepository.DeletePerson(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
        public IActionResult Find(string term)
        {
            var result = _PersonRepository.Find(term);

            return Json(new { results = (result.Select(c => new { id = c.PersonID, text = c.PersianFullName })) });
        }
    }
}