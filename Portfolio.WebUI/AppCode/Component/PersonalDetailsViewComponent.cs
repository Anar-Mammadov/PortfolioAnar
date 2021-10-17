using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Model.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.AppCode.Component
{
    public class PersonalDetailsViewComponent : ViewComponent
    {
        readonly PortfolioDbContext db;
        public PersonalDetailsViewComponent(PortfolioDbContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            var data = db.Aboutme.FirstOrDefault();
            return View(data);
        }
    }
}
