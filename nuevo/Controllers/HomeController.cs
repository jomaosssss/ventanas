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

        // Acci�n por defecto que muestra la vista Index.cshtml
        public IActionResult Index()
        {
            return View();
        }

        // Nueva acci�n que muestra la vista Inicio.cshtml (Dashboard)
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Agendar()
        {
            return View();
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


