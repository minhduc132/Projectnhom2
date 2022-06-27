using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom2Ki3l2.Data;
using Nhom2Ki3l2.Models;

namespace Nhom2Ki3l2.Controllers
{
    [Authorize]
    public class NhaMaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhaMaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NhaMays
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaMay.ToListAsync());
        }

        // GET: NhaMays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaMay = await _context.NhaMay
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaMay == null)
            {
                return NotFound();
            }

            return View(nhaMay);
        }

        // GET: NhaMays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaMays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNhaMay,DiaChi")] NhaMay nhaMay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaMay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaMay);
        }

        // GET: NhaMays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaMay = await _context.NhaMay.FindAsync(id);
            if (nhaMay == null)
            {
                return NotFound();
            }
            return View(nhaMay);
        }

        // POST: NhaMays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNhaMay,DiaChi")] NhaMay nhaMay)
        {
            if (id != nhaMay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaMay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaMayExists(nhaMay.Id))
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
            return View(nhaMay);
        }

        // GET: NhaMays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaMay = await _context.NhaMay
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhaMay == null)
            {
                return NotFound();
            }

            return View(nhaMay);
        }

        // POST: NhaMays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaMay = await _context.NhaMay.FindAsync(id);
            _context.NhaMay.Remove(nhaMay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaMayExists(int id)
        {
            return _context.NhaMay.Any(e => e.Id == id);
        }
    }
}
