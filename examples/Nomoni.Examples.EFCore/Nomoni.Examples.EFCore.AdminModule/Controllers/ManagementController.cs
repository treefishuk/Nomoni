using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nomoni.Examples.Security.AdminModule.Models;
using Nomoni.Examples.Security.Shared;

namespace Nomoni.Examples.Security.AdminModule.Controllers
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