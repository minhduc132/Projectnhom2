using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using agment3.Data;
using agment3.Models;

namespace agment3.Controllers
{
    public class QlhockisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QlhockisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Qlhockis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qlhocki.ToListAsync());
        }

        // GET: Qlhockis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlhocki = await _context.Qlhocki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qlhocki == null)
            {
                return NotFound();
            }

            return View(qlhocki);
        }

        // GET: Qlhockis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qlhockis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Qlhocki qlhocki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qlhocki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qlhocki);
        }

        // GET: Qlhockis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlhocki = await _context.Qlhocki.FindAsync(id);
            if (qlhocki == null)
            {
                return NotFound();
            }
            return View(qlhocki);
        }

        // POST: Qlhockis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Qlhocki qlhocki)
        {
            if (id != qlhocki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qlhocki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QlhockiExists(qlhocki.Id))
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
            return View(qlhocki);
        }

        // GET: Qlhockis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlhocki = await _context.Qlhocki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qlhocki == null)
            {
                return NotFound();
            }

            return View(qlhocki);
        }

        // POST: Qlhockis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qlhocki = await _context.Qlhocki.FindAsync(id);
            _context.Qlhocki.Remove(qlhocki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QlhockiExists(int id)
        {
            return _context.Qlhocki.Any(e => e.Id == id);
        }
    }
}
