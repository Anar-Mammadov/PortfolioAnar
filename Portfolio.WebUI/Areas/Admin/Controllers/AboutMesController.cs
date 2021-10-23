using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Model.DataContexts;
using Portfolio.WebUI.Model.Entity;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMesController : Controller
    {
        private readonly PortfolioDbContext _context;

        public AboutMesController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AboutMes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aboutme.ToListAsync());
        }

        // GET: Admin/AboutMes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.Aboutme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutMes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location,Degree,Email,Phone,Age,Experience,CareerLevel,Fax,Website,Title,Description,Id,CreatedByUserId,CreatedData,DeleteByUserId,DeletedData")] AboutMe aboutMe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.Aboutme.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: Admin/AboutMes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Location,Degree,Email,Phone,Age,Experience,CareerLevel,Fax,Website,Title,Description,Id,CreatedByUserId,CreatedData,DeleteByUserId,DeletedData")] AboutMe aboutMe)
        {
            if (id != aboutMe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutMe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: Admin/AboutMes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.Aboutme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: Admin/AboutMes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutMe = await _context.Aboutme.FindAsync(id);
            _context.Aboutme.Remove(aboutMe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(int id)
        {
            return _context.Aboutme.Any(e => e.Id == id);
        }
    }
}
