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
    public class SanPhamKhoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamKhoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SanPhamKhoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanPhamKho.ToListAsync());
        }

        // GET: SanPhamKhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamKho = await _context.SanPhamKho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPhamKho == null)
            {
                return NotFound();
            }

            return View(sanPhamKho);
        }

        // GET: SanPhamKhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPhamKhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSP,IdKho,SoLuong")] SanPhamKho sanPhamKho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamKho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPhamKho);
        }

        // GET: SanPhamKhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamKho = await _context.SanPhamKho.FindAsync(id);
            if (sanPhamKho == null)
            {
                return NotFound();
            }
            return View(sanPhamKho);
        }

        // POST: SanPhamKhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdSP,IdKho,SoLuong")] SanPhamKho sanPhamKho)
        {
            if (id != sanPhamKho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamKho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamKhoExists(sanPhamKho.Id))
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
            return View(sanPhamKho);
        }

        // GET: SanPhamKhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamKho = await _context.SanPhamKho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPhamKho == null)
            {
                return NotFound();
            }

            return View(sanPhamKho);
        }

        // POST: SanPhamKhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamKho = await _context.SanPhamKho.FindAsync(id);
            _context.SanPhamKho.Remove(sanPhamKho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamKhoExists(int id)
        {
            return _context.SanPhamKho.Any(e => e.Id == id);
        }
    }
}
