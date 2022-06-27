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
    public class DiemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diems
        [Authorize(Roles = "Admin,Teacher,Student")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Diem.Include(d => d.MonHocs).Include(d => d.SinhViens);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Diems/Details/5
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem
                .Include(d => d.MonHocs)
                .Include(d => d.SinhViens)
                .FirstOrDefaultAsync(m => m.id == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // GET: Diems/Create
        [Authorize(Roles = "Admin,Teachert")]
        public IActionResult Create()
        {
            ViewData["MonHocId"] = new SelectList(_context.MonHoc, "Id", "Id");
            ViewData["SinhVienId"] = new SelectList(_context.SinhVien, "Id", "Id");
            return View();
        }

        // POST: Diems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> Create([Bind("id,SinhVienId,MonHocId,DiemLT,DiemTH,DiemBT")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonHocId"] = new SelectList(_context.MonHoc, "Id", "Id", diem.MonHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhVien, "Id", "Id", diem.SinhVienId);
            return View(diem);
        }

        // GET: Diems/Edit/5
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }
            ViewData["MonHocId"] = new SelectList(_context.MonHoc, "Id", "Id", diem.MonHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhVien, "Id", "Id", diem.SinhVienId);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> Edit(int id, [Bind("id,SinhVienId,MonHocId,DiemLT,DiemTH,DiemBT")] Diem diem)
        {
            if (id != diem.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemExists(diem.id))
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
            ViewData["MonHocId"] = new SelectList(_context.MonHoc, "Id", "Id", diem.MonHocId);
            ViewData["SinhVienId"] = new SelectList(_context.SinhVien, "Id", "Id", diem.SinhVienId);
            return View(diem);
        }

        // GET: Diems/Delete/5
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diem = await _context.Diem
                .Include(d => d.MonHocs)
                .Include(d => d.SinhViens)
                .FirstOrDefaultAsync(m => m.id == id);
            if (diem == null)
            {
                return NotFound();
            }

            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teachert")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diem = await _context.Diem.FindAsync(id);
            _context.Diem.Remove(diem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemExists(int id)
        {
            return _context.Diem.Any(e => e.id == id);
        }
    }
}
