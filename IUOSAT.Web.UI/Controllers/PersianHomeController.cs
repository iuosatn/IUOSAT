using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IUOSAT.Web.UI.Controllers
{
    public class PersianHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}