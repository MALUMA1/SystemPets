using Microsoft.AspNetCore.Mvc;
using SysPet.Exception;
using SysPet.Models;
using System.Diagnostics;

namespace SysPet.Controllers
{
    [ServiceFilter(typeof(ManageExceptionFilter))]
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
            var model = new ErrorViewModel
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View();
        }
    }
}