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
    public class CauHoiController : Controller
    {
        private readonly TracNghiemContext _context;

        public CauHoiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: CauHoi
        public async Task<IActionResult> Index()
        {
            var tracNghiemContext = _context.TbCauHois.Include(t => t.MaMonHocNavigation).Include(t => t.MaMucDoNavigation);
            return View(await tracNghiemContext.ToListAsync());
        }

        // GET: CauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois
                .Include(t => t.MaMonHocNavigation)
                .Include(t => t.MaMucDoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }

            return View(tbCauHoi);
        }

        // GET: CauHoi/Create
        public IActionResult Create()
        {
            ViewData["MaMonHoc"] = new SelectList(_context.TbMonHocs, "Id", "Id");
            ViewData["MaMucDo"] = new SelectList(_context.TbMucDos, "Id", "Id");
            return View();
        }

        // POST: CauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CauHoi,DapAnA,DapAnB,DapAnC,DapAnD,DapAn,GhiChu,MaMonHoc,MaMucDo")] TbCauHoi tbCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMonHoc"] = new SelectList(_context.TbMonHocs, "Id", "Id", tbCauHoi.MaMonHoc);
            ViewData["MaMucDo"] = new SelectList(_context.TbMucDos, "Id", "Id", tbCauHoi.MaMucDo);
            return View(tbCauHoi);
        }

        // GET: CauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois.FindAsync(id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }
            ViewData["MaMonHoc"] = new SelectList(_context.TbMonHocs, "Id", "Id", tbCauHoi.MaMonHoc);
            ViewData["MaMucDo"] = new SelectList(_context.TbMucDos, "Id", "Id", tbCauHoi.MaMucDo);
            return View(tbCauHoi);
        }

        // POST: CauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CauHoi,DapAnA,DapAnB,DapAnC,DapAnD,DapAn,GhiChu,MaMonHoc,MaMucDo")] TbCauHoi tbCauHoi)
        {
            if (id != tbCauHoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCauHoiExists(tbCauHoi.Id))
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
            ViewData["MaMonHoc"] = new SelectList(_context.TbMonHocs, "Id", "Id", tbCauHoi.MaMonHoc);
            ViewData["MaMucDo"] = new SelectList(_context.TbMucDos, "Id", "Id", tbCauHoi.MaMucDo);
            return View(tbCauHoi);
        }

        // GET: CauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCauHoi = await _context.TbCauHois
                .Include(t => t.MaMonHocNavigation)
                .Include(t => t.MaMucDoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCauHoi == null)
            {
                return NotFound();
            }

            return View(tbCauHoi);
        }

        // POST: CauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCauHoi = await _context.TbCauHois.FindAsync(id);
            if (tbCauHoi != null)
            {
                _context.TbCauHois.Remove(tbCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCauHoiExists(int id)
        {
            return _context.TbCauHois.Any(e => e.Id == id);
        }
    }
}
