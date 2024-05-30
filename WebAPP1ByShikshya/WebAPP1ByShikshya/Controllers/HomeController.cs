using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPP1ByShikshya.Models;

namespace WebAPP1ByShikshya.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyRazorPage()
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