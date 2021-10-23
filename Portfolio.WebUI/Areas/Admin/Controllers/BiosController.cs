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
    public class BiosController : Controller
    {
        private readonly PortfolioDbContext _context;

        public BiosController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Bios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bios.ToListAsync());
        }

        // GET: Admin/Bios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // GET: Admin/Bios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Bios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,Id,CreatedByUserId,CreatedData,DeleteByUserId,DeletedData")] Bio bio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bio);
        }

        // GET: Admin/Bios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios.FindAsync(id);
            if (bio == null)
            {
                return NotFound();
            }
            return View(bio);
        }

        // POST: Admin/Bios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Content,Id,CreatedByUserId,CreatedData,DeleteByUserId,DeletedData")] Bio bio)
        {
            if (id != bio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioExists(bio.Id))
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
            return View(bio);
        }

        // GET: Admin/Bios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // POST: Admin/Bios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bio = await _context.Bios.FindAsync(id);
            _context.Bios.Remove(bio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioExists(int id)
        {
            return _context.Bios.Any(e => e.Id == id);
        }
    }
}
