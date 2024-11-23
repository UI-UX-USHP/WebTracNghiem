using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TracNghiem.Models;

namespace TracNghiem.Controllers
{
    public class ThanhVienController : Controller
    {
        private readonly TracNghiemContext _context;

        public ThanhVienController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: ThanhVien
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbThanhViens.ToListAsync());
        }
        // GET: ThanhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhVien = await _context.TbThanhViens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbThanhVien == null)
            {
                return NotFound();
            }

            return View(tbThanhVien);
        }

        // GET: ThanhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThanhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSinhVien,Sdt,Email,DiaChi,MatKhau,Lop,NgaySinh,GioiTinh,TaiKhoan,LaGiangVien")] TbThanhVien tbThanhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThanhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbThanhVien);
        }

        // GET: ThanhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhVien = await _context.TbThanhViens.FindAsync(id);
            if (tbThanhVien == null)
            {
                return NotFound();
            }
            return View(tbThanhVien);
        }

        // POST: ThanhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,TenSinhVien,Sdt,Email,DiaChi,MatKhau,Lop,NgaySinh,GioiTinh,TaiKhoan,LaGiangVien")] TbThanhVien tbThanhVien)
        {
            if (id != tbThanhVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThanhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThanhVienExists(tbThanhVien.Id))
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
            return View(tbThanhVien);
        }

        // GET: ThanhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhVien = await _context.TbThanhViens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbThanhVien == null)
            {
                return NotFound();
            }

            return View(tbThanhVien);
        }

        // POST: ThanhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbThanhVien = await _context.TbThanhViens.FindAsync(id);
            if (tbThanhVien != null)
            {
                _context.TbThanhViens.Remove(tbThanhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThanhVienExists(string id)
        {
            return _context.TbThanhViens.Any(e => e.Id == id);
        }
    }
}
