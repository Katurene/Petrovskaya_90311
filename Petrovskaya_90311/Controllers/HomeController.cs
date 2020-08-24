using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Petrovskaya_90311.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Text"] = "Лабораторная работа 2";
            return View();
        }
    }
}
