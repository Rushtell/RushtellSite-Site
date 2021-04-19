using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace RushtellSite.Components
{
    public class Auth : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
