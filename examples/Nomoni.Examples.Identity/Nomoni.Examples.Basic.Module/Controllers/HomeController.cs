using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Nomoni.Examples.Basic.Module.Models;
using Nomoni.Examples.Basic.Shared;

namespace Nomoni.Examples.Basic.Module.Controllers
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
           
            var user = HttpContext.User;
            if (user?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await HttpContext.SignOutAsync();
            }
          
            return RedirectToAction(nameof(Index));

        }

    }
}
