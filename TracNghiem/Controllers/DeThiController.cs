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
    public class DeThiController : Controller
    {
        private readonly TracNghiemContext _context;

        public DeThiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: DeThi
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbDeThis.ToListAsync());
        }

        // GET: DeThi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThi = await _context.TbDeThis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDeThi == null)
            {
                return NotFound();
            }

            return View(tbDeThi);
        }

        // GET: DeThi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeThi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayThi,ThoiGianThi,TenDeThi,SoLuongCauKho,SoLuongCauHoi")] TbDeThi tbDeThi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDeThi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbDeThi);
        }

        // GET: DeThi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThi = await _context.TbDeThis.FindAsync(id);
            if (tbDeThi == null)
            {
                return NotFound();
            }
            return View(tbDeThi);
        }

        // POST: DeThi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayThi,ThoiGianThi,TenDeThi,SoLuongCauKho,SoLuongCauHoi")] TbDeThi tbDeThi)
        {
            if (id != tbDeThi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDeThi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDeThiExists(tbDeThi.Id))
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
            return View(tbDeThi);
        }

        // GET: DeThi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThi = await _context.TbDeThis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDeThi == null)
            {
                return NotFound();
            }

            return View(tbDeThi);
        }

        // POST: DeThi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDeThi = await _context.TbDeThis.FindAsync(id);
            if (tbDeThi != null)
            {
                _context.TbDeThis.Remove(tbDeThi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDeThiExists(int id)
        {
            return _context.TbDeThis.Any(e => e.Id == id);
        }
    }
}
