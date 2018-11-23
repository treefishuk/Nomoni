using Microsoft.AspNetCore.Mvc;
using Nomoni.Examples.Basic.AdminModule.Models;

namespace Nomoni.Examples.Basic.AdminModule.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {

            var model = new ManagmentViewModel()
            {
                PageContent = "I'm some page content",
                PageTitle = "Management Page"
            };

            return View(model);
        }
    }
}