using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IUOSAT.Domain.Contract.Repositories;
using IUOSAT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IUOSAT.Web.UI.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository repoService)
        {
            repository = repoService;

        }
        public ViewResult Comments() => View(repository.GetAll());
        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Comment order = repository.GetById(orderID);
            if (order != null)
            {
                order.MarkShipped = true;
                repository.SaveComment(order);
            }
            return RedirectToAction(nameof(Comment));
        }
        public IActionResult CommentList()
        {
            return View();
        }
    }
}