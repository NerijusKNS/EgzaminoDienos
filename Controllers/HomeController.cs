using EgzaminoUzduotis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EgzaminoUzduotis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Pagrindinis()
        {
            return View();
        }

        public IActionResult Filmai()
        {
            return View();
        }

        public IActionResult Klientas()
        {
            return View();
        }

        public IActionResult Administratorius()
        {
            return View();
        }

        public IActionResult Apie()
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