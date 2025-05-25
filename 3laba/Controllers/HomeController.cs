using System.Diagnostics;
using _3laba.Models;
using Microsoft.AspNetCore.Mvc;
using _3laba.Filters;

namespace _3laba.Controllers
{
    [ArgumentOutOfRangeExceptionFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [PostIndexActionFilter]
        public IActionResult Index(int? id, string name, string department, bool isActive, string date)
        {
            // Получение части данных через Request.Form
            var extraField = Request.Form["extraField"];
            if (id.HasValue)
            {
                ViewBag.Id = id;
                ViewBag.Name = name;
                ViewBag.Department = department;
                ViewBag.IsActive = isActive;
                ViewBag.Date = date;
                ViewBag.ExtraField = extraField;
                return View("Result");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
