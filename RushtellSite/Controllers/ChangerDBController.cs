using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using RushtellSite.Models;

namespace RushtellSite.Controllers
{
    public class ChangerDBController : Controller
    {
        ILogger<ChangerDBController> log;

        public ChangerDBController(ILogger<ChangerDBController> log)
        {
            this.log = log;
        }

        [HttpGet]
        public IActionResult AddPage()
        {
            log.LogError(">>> Произведен переход на страницу добавления");
            return View();
        }

        [HttpPost]
        public IActionResult AddToDB(int Id, string Name, int Deposit, string Type)
        {
            ApiRushtellSiteModel db = new ApiRushtellSiteModel();

            Id = CheckId(Id, db);

            db.AddClient(new Client() { Id = Id, Name = Name, Deposit = Deposit, Type = Type });

            log.LogCritical(">>> Добавлен челобастр");

            return Redirect("~/Home/index");
        }

        [HttpPost]
        public IActionResult DeleteFromDB(int Id)
        {
            ApiRushtellSiteModel db = new ApiRushtellSiteModel();
            var deleteditem = db.GetClients().Where(e => e.Id == Id);
            Client clientForDelete = default;
            bool needdelete = false;
            foreach (var item in deleteditem)
            {
                clientForDelete = item;
                needdelete = true;
            }
            if (needdelete) db.DeleteClient(clientForDelete.Id);
            return Redirect("~/Home/Index");
        }

        private int CheckId (int Id, ApiRushtellSiteModel db)
        {
            var checkId = db.GetClients().Where(e => e.Id == Id);
            bool checknext = false;
            foreach (var item in checkId)
            {
                checknext = true;
            }
            if (checknext)
            {
                int Count = db.GetClients().Count();
                for (int i = 1; i <= Count; i++)
                {
                    bool next = false;
                    var chek = db.GetClients().Where(e => e.Id == i);
                    foreach (var item2 in chek)
                    {
                        next = true;
                    }
                    if (next) continue;
                    else
                    {
                        return Id = i;
                    }
                }
                return Id = Count + 1;
            }
            return Id;
        }
    }
}
