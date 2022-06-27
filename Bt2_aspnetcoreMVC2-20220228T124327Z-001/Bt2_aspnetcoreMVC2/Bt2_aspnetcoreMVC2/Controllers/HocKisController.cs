using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bt2_aspnetcoreMVC2.Data;
using Bt2_aspnetcoreMVC2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bt2_aspnetcoreMVC2.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class HocKisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HocKisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HocKis
        public async Task<IActionResult> Index()
        {
            return View(await _context.HocKi.ToListAsync());
        }

        // GET: HocKis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKi = await _context.HocKi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hocKi == null)
            {
                return NotFound();
            }

            return View(hocKi);
        }

        // GET: HocKis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocKis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKi")] HocKi hocKi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocKi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocKi);
        }

        // GET: HocKis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKi = await _context.HocKi.FindAsync(id);
            if (hocKi == null)
            {
                return NotFound();
            }
            return View(hocKi);
        }

        // POST: HocKis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKi")] HocKi hocKi)
        {
            if (id != hocKi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocKi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocKiExists(hocKi.Id))
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
            return View(hocKi);
        }

        // GET: HocKis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKi = await _context.HocKi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hocKi == null)
            {
                return NotFound();
            }

            return View(hocKi);
        }

        // POST: HocKis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hocKi = await _context.HocKi.FindAsync(id);
            _context.HocKi.Remove(hocKi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocKiExists(int id)
        {
            return _context.HocKi.Any(e => e.Id == id);
        }
    }
}
