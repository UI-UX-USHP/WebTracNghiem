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
    public class KetQuaController : Controller
    {
        private readonly TracNghiemContext _context;

        public KetQuaController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: KetQua
        public async Task<IActionResult> Index()
        {
            var tracNghiemContext = _context.TbKetQuas.Include(t => t.MaDeThiCauHoiNavigation).Include(t => t.MaSinhVienNavigation);
            return View(await tracNghiemContext.ToListAsync());
        }

        // GET: KetQua/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas
                .Include(t => t.MaDeThiCauHoiNavigation)
                .Include(t => t.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbKetQua == null)
            {
                return NotFound();
            }

            return View(tbKetQua);
        }

        // GET: KetQua/Create
        public IActionResult Create()
        {
            ViewData["MaDeThiCauHoi"] = new SelectList(_context.TbDeThiCauHois, "Id", "Id");
            ViewData["MaSinhVien"] = new SelectList(_context.TbThanhViens, "Id", "Id");
            return View();
        }

        // POST: KetQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaSinhVien,DapAn,MaDeThiCauHoi")] TbKetQua tbKetQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKetQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDeThiCauHoi"] = new SelectList(_context.TbDeThiCauHois, "Id", "Id", tbKetQua.MaDeThiCauHoi);
            ViewData["MaSinhVien"] = new SelectList(_context.TbThanhViens, "Id", "Id", tbKetQua.MaSinhVien);
            return View(tbKetQua);
        }

        // GET: KetQua/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas.FindAsync(id);
            if (tbKetQua == null)
            {
                return NotFound();
            }
            ViewData["MaDeThiCauHoi"] = new SelectList(_context.TbDeThiCauHois, "Id", "Id", tbKetQua.MaDeThiCauHoi);
            ViewData["MaSinhVien"] = new SelectList(_context.TbThanhViens, "Id", "Id", tbKetQua.MaSinhVien);
            return View(tbKetQua);
        }

        // POST: KetQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaSinhVien,DapAn,MaDeThiCauHoi")] TbKetQua tbKetQua)
        {
            if (id != tbKetQua.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKetQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKetQuaExists(tbKetQua.Id))
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
            ViewData["MaDeThiCauHoi"] = new SelectList(_context.TbDeThiCauHois, "Id", "Id", tbKetQua.MaDeThiCauHoi);
            ViewData["MaSinhVien"] = new SelectList(_context.TbThanhViens, "Id", "Id", tbKetQua.MaSinhVien);
            return View(tbKetQua);
        }

        // GET: KetQua/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKetQua = await _context.TbKetQuas
                .Include(t => t.MaDeThiCauHoiNavigation)
                .Include(t => t.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbKetQua == null)
            {
                return NotFound();
            }

            return View(tbKetQua);
        }

        // POST: KetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKetQua = await _context.TbKetQuas.FindAsync(id);
            if (tbKetQua != null)
            {
                _context.TbKetQuas.Remove(tbKetQua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKetQuaExists(int id)
        {
            return _context.TbKetQuas.Any(e => e.Id == id);
        }
    }
}
