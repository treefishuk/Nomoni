using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nomoni.Mvc.Registration
{
   public  interface IConfigureApplicationBuilder
    {

        int Priority { get; }

        void Execute(IApplicationBuilder applicationBuilder);

    }
}
