using Microsoft.AspNetCore.Mvc.RazorPages;
using Nomoni.Examples.Security.Shared;
using System.Collections.Generic;

namespace Nomoni.Examples.Security.Models
{
    public class RazorBasePageModel : PageModel, IBasePageViewModel
    {
        public RazorBasePageModel()
        {
            MenuItems = new List<MenuItem>();
            PageScripts = new List<string>();
            PageStyles = new List<string>();
            this.PopulateMenu();
        }

        public IEnumerable<MenuItem> MenuItems { get; set; }
        public List<string> PageScripts { get; set; }
        public List<string> PageStyles { get; set; }
        public string PageTitle { get; set; }
    }
}
