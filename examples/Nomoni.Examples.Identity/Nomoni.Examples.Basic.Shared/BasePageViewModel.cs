using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Examples.Basic.Shared
{
    public class BasePageViewModel
    {
        public BasePageViewModel()
        {
            PageScripts = new List<string>();
            PageStyles = new List<string>();
            this.PopulateMenu();
        }

        public string PageTitle { get; set; }

        public List<string> PageScripts { get; set; }

        public List<string> PageStyles { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }


    }
}
