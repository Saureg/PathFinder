using Microsoft.AspNetCore.Mvc;

namespace PathFinder.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            ViewData["Title"] = "Главная";
            return View();
        }
    }
}