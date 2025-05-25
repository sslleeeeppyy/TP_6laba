using Microsoft.AspNetCore.Mvc;
using System;
using _3laba.Filters;

namespace _3laba.Controllers
{
    [ArgumentOutOfRangeExceptionFilter]
    public class CustomController : Controller
    {
        [CustomAuthorize]
        public IActionResult Start(int? id)
        {
            if (id == 0)
            {
                // Перенаправление на Index обычного контроллера
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Вывод ошибки и полного URL
                var url = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
                return Content($"Ошибка!\nПолный URL: {url}");
            }
        }
    }
} 