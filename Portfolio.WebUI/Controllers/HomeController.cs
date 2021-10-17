using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Model.DataContexts;
using Portfolio.WebUI.Model.Entity;
using Portfolio.WebUI.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly PortfolioDbContext db;
        public HomeController(PortfolioDbContext db)
        {
            this.db = db;
        }

        //+
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Services = db.Services.Where(e => e.DeleteByUserId == null).Include(e => e.Icons).ToList();
            vm.Aboutme = db.Aboutme.FirstOrDefault(e => e.DeleteByUserId == null);

           

            return View(vm);
            
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        //+
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contactss.Add(model);
                db.SaveChanges();

                return Json(new
                {
                    error=false,
                    message="Sorgunuz qeyd alindi"
                });
            }
            return Json(new
            {
                error = true,
                message = "Sorgunuz qeyde alinmadi"
            });
        }
    }
}
