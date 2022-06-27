using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom2ki3.Data;
using Nhom2ki3.Models;

namespace Nhom2ki3.Controllers
{
    [Authorize]
    public class KhoesController : Controller
    {
        private readonly Nhom2ki3Context _context;

        public KhoesController(Nhom2ki3Context context)
        {
            _context = context;
        }

        // GET: Khoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kho.ToListAsync());
        }

        // GET: Khoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // GET: Khoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKho,DiaChi")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kho);
        }

        // GET: Khoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho.FindAsync(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // POST: Khoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKho,DiaChi")] Kho kho)
        {
            if (id != kho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoExists(kho.Id))
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
            return View(kho);
        }

        // GET: Khoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // POST: Khoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kho = await _context.Kho.FindAsync(id);
            _context.Kho.Remove(kho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoExists(int id)
        {
            return _context.Kho.Any(e => e.Id == id);
        }
    }
}
