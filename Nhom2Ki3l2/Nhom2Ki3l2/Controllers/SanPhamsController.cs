﻿using System;
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
    public class SanPhamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        [Authorize(Roles = "Admin,user")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanPham.ToListAsync());
        }

        // GET: SanPhams/Details/5
        [Authorize(Roles = "Admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        [Authorize(Roles = "Admin,user")]

        public IActionResult Create()
        {

            ViewData["KhoId"] = new SelectList(_context.Kho, "Id", "Id");
            ViewData["HoaDonId"] = new SelectList(_context.HoaDon, "Id", "Id");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,user")]

        public async Task<IActionResult> Create([Bind("Id,TenSP,DonGia,MoTa,HinhAnh,TrangThai,SoLuong,IdLoaiSP")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KhoId"] = new SelectList(_context.Kho, "Id", "Id");
            ViewData["HoaDonId"] = new SelectList(_context.HoaDon, "Id", "Id");
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        [Authorize(Roles = "Admin,user")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["KhoId"] = new SelectList(_context.Kho, "Id", "Id");
            ViewData["HoaDonId"] = new SelectList(_context.HoaDon, "Id", "Id");
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,user")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSP,DonGia,MoTa,HinhAnh,TrangThai,SoLuong,IdLoaiSP")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        [Authorize(Roles = "Admin,user")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPham
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,user")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPham.Any(e => e.Id == id);
        }
    }
}
