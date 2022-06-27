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
    public class QLmonhocsController : Controller
    {
        private readonly agement2Context _context;

        public QLmonhocsController(agement2Context context)
        {
            _context = context;
        }

        // GET: QLmonhocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.QLmonhoc.ToListAsync());
        }

        // GET: QLmonhocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLmonhoc = await _context.QLmonhoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLmonhoc == null)
            {
                return NotFound();
            }

            return View(qLmonhoc);
        }

        // GET: QLmonhocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLmonhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Semester")] QLmonhoc qLmonhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLmonhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLmonhoc);
        }

        // GET: QLmonhocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLmonhoc = await _context.QLmonhoc.FindAsync(id);
            if (qLmonhoc == null)
            {
                return NotFound();
            }
            return View(qLmonhoc);
        }

        // POST: QLmonhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Semester")] QLmonhoc qLmonhoc)
        {
            if (id != qLmonhoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLmonhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLmonhocExists(qLmonhoc.Id))
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
            return View(qLmonhoc);
        }

        // GET: QLmonhocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLmonhoc = await _context.QLmonhoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLmonhoc == null)
            {
                return NotFound();
            }

            return View(qLmonhoc);
        }

        // POST: QLmonhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLmonhoc = await _context.QLmonhoc.FindAsync(id);
            _context.QLmonhoc.Remove(qLmonhoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLmonhocExists(int id)
        {
            return _context.QLmonhoc.Any(e => e.Id == id);
        }
    }
}
