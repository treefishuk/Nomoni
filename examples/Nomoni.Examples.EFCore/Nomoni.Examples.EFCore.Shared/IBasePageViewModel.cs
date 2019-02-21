using System.Collections.Generic;

namespace Nomoni.Examples.Security.Shared
{
    public interface IBasePageViewModel
    {
        IEnumerable<MenuItem> MenuItems { get; set; }
        List<string> PageScripts { get; set; }
        List<string> PageStyles { get; set; }
        string PageTitle { get; set; }
    }
}