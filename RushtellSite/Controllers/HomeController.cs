using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using RushtellSite.Models;

namespace RushtellSite.Controllers
{
    public class HomeController : Controller
    {
        ILogger log;

        ApiRushtellSiteModel api;

        public HomeController(ILoggerFactory log)
        {
            this.log = log.CreateLogger("<><><>MyNewLogger<><><>");
            api = new ApiRushtellSiteModel();
        }

        [HttpGet]
        public IActionResult Index()
        {
            log.LogInformation("Загружена страница с таблицей из базы данных");
            ViewBag.timerA = SiteStartedTimer.a;
            ViewBag.Clients = api.GetClients().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult mainpage()
        {
            log.LogInformation("Загружена главная страница");
            if (SiteStartedTimer.a == 0)
            {
                SiteStartedTimer timer = new SiteStartedTimer();
            }
            return Redirect("~/Home/Index");
        }
    }
}
