using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Model.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]

    public class ProjectController : Controller
    {
        readonly PortfolioDbContext db;
        public ProjectController(PortfolioDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Projects.Where(c => c.DeleteByUserId == null).ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.Projects.FirstOrDefault(c => c.Id == id && c.DeleteByUserId==null);
            return View(data);
        }
    }
}
