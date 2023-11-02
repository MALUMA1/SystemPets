using Microsoft.AspNetCore.Mvc;
using SysPet.Models;
using System.Diagnostics;

namespace SysPet.Controllers
{
    public class HomeController : Controller
    {
   
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("User");
            ViewBag.User = user;
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