using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Model.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class BlogController : Controller
    {


        readonly PortfolioDbContext db;
        public BlogController(PortfolioDbContext db)
        {
            this.db = db;
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            var data = db.BlogPosts.Where(c => c.DeleteByUserId == null).ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.BlogPosts.FirstOrDefault(c => c.Id == id && c.DeleteByUserId == null);
            return View(data);
        }
    }
}
