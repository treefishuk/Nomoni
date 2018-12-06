using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nomoni.Examples.Security.Models;

namespace Nomoni.Examples.Security.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordConfirmationModel : RazorBasePageModel
    {
        public void OnGet()
        {

        }
    }
}
