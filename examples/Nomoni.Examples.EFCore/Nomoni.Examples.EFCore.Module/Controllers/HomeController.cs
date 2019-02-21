using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nomoni.Examples.Security.Module.Models;
using Nomoni.Examples.Security.Shared;

namespace Nomoni.Examples.Security.Module.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BasePageViewModel();

            return View(model);
        }

        public IActionResult About()
        {

            var model = new BasePageViewModel();

            ViewData["Message"] = "Your application description page.";

            return View(model);
        }

        public IActionResult Contact()
        {

            var model = new BasePageViewModel();

            ViewData["Message"] = "Your contact page.";

            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BasePageViewModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
