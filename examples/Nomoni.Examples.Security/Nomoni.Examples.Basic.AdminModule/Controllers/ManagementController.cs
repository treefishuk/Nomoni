using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nomoni.Examples.Basic.AdminModule.Models;
using Nomoni.Examples.Basic.Shared;

namespace Nomoni.Examples.Basic.AdminModule.Controllers
{

    [Authorize]
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {

            var model = new ManagmentViewModel()
            {
                PageContent = "I'm some page content",
                PageTitle = "Management Page"
            };

            model.AddPageStyles("/css/admin-styles.css");
            model.AddPageStyles("/js/admin-scripts.js");   

            return View(model);
        }
    }
}