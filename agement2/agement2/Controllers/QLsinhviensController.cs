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
    public class QLsinhviensController : Controller
    {
        private readonly agement2Context _context;

        public QLsinhviensController(agement2Context context)
        {
            _context = context;
        }

        // GET: QLsinhviens
        public async Task<IActionResult> Index()
        {
            return View(await _context.QLsinhvien.ToListAsync());
        }

        // GET: QLsinhviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLsinhvien = await _context.QLsinhvien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLsinhvien == null)
            {
                return NotFound();
            }

            return View(qLsinhvien);
        }

        // GET: QLsinhviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLsinhviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phonenumber,Email")] QLsinhvien qLsinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLsinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLsinhvien);
        }

        // GET: QLsinhviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLsinhvien = await _context.QLsinhvien.FindAsync(id);
            if (qLsinhvien == null)
            {
                return NotFound();
            }
            return View(qLsinhvien);
        }

        // POST: QLsinhviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phonenumber,Email")] QLsinhvien qLsinhvien)
        {
            if (id != qLsinhvien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLsinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLsinhvienExists(qLsinhvien.Id))
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
            return View(qLsinhvien);
        }

        // GET: QLsinhviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLsinhvien = await _context.QLsinhvien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLsinhvien == null)
            {
                return NotFound();
            }

            return View(qLsinhvien);
        }

        // POST: QLsinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLsinhvien = await _context.QLsinhvien.FindAsync(id);
            _context.QLsinhvien.Remove(qLsinhvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLsinhvienExists(int id)
        {
            return _context.QLsinhvien.Any(e => e.Id == id);
        }
    }
}
