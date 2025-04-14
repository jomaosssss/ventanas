using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using nuevo.Models;

namespace nuevo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción por defecto que muestra la vista Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // Nueva acción que muestra la vista Inicio.cshtml (Dashboard)
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Agendar()
        {
            return View();
        }

        public IActionResult AgendarMC()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MCCFEmatico()
        {
            return PartialView("MCCFEmatico");
        }

        public IActionResult MCCFEturno()
        {
            return PartialView("MCCFEturno");
        }

        public IActionResult MCCFEcam()
        {
            return PartialView("MCCFEcam");
        }

        public IActionResult MCPC()
        {
            return PartialView("MCPC");
        }

        public IActionResult MCLaptop()
        {
            return PartialView("MCLaptop");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


