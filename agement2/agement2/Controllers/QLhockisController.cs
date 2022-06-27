#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agement2.Data;
using agement2.Models;

namespace agement2.Controllers
{
    public class QLhockisController : Controller
    {
        private readonly agement2Context _context;

        public QLhockisController(agement2Context context)
        {
            _context = context;
        }

        // GET: QLhockis
        public async Task<IActionResult> Index()
        {
            return View(await _context.QLhocki.ToListAsync());
        }

        // GET: QLhockis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLhocki = await _context.QLhocki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLhocki == null)
            {
                return NotFound();
            }

            return View(qLhocki);
        }

        // GET: QLhockis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLhockis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] QLhocki qLhocki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLhocki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLhocki);
        }

        // GET: QLhockis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLhocki = await _context.QLhocki.FindAsync(id);
            if (qLhocki == null)
            {
                return NotFound();
            }
            return View(qLhocki);
        }

        // POST: QLhockis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] QLhocki qLhocki)
        {
            if (id != qLhocki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLhocki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLhockiExists(qLhocki.Id))
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
            return View(qLhocki);
        }

        // GET: QLhockis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLhocki = await _context.QLhocki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLhocki == null)
            {
                return NotFound();
            }

            return View(qLhocki);
        }

        // POST: QLhockis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLhocki = await _context.QLhocki.FindAsync(id);
            _context.QLhocki.Remove(qLhocki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLhockiExists(int id)
        {
            return _context.QLhocki.Any(e => e.Id == id);
        }
    }
}
