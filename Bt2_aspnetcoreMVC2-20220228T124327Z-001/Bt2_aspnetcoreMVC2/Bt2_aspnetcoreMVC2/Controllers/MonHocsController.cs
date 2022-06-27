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
    [Authorize]
    public class MonHocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonHocs
        [Authorize(Roles = "Admin,Teacher,Student")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonHoc.Include(m => m.HocKis);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonHocs/Details/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc
                .Include(m => m.HocKis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHocs/Create
        [Authorize(Roles = "Admin,Teacher")]

        public IActionResult Create()
        {
            ViewData["HocKiId"] = new SelectList(_context.HocKi, "Id", "Id");
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Create([Bind("Id,TenMH,HocKiId")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HocKiId"] = new SelectList(_context.HocKi, "Id", "Id", monHoc.HocKiId);
            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            ViewData["HocKiId"] = new SelectList(_context.HocKi, "Id", "Id", monHoc.HocKiId);
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMH,HocKiId")] MonHoc monHoc)
        {
            if (id != monHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.Id))
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
            ViewData["HocKiId"] = new SelectList(_context.HocKi, "Id", "Id", monHoc.HocKiId);
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHoc
                .Include(m => m.HocKis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monHoc = await _context.MonHoc.FindAsync(id);
            _context.MonHoc.Remove(monHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Any(e => e.Id == id);
        }
    }
}
