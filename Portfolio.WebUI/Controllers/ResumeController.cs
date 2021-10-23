using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Model.DataContexts;
using Portfolio.WebUI.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]

    public class ResumeController : Controller
    {
        readonly PortfolioDbContext db;
        public ResumeController(PortfolioDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var vm = new ResumeViewModel();
            vm.Education = db.Educations.Where(e => e.DeleteByUserId == null).ToList();

            vm.Experience = db.Experiences.Where(e => e.DeleteByUserId == null).ToList();
            vm.Bios = db.Bios.FirstOrDefault(e => e.DeleteByUserId == null);
            vm.Skills = db.Skills.Where(e => e.DeleteByUserId == null).ToList();

            return View(vm);
        }

    }
}
