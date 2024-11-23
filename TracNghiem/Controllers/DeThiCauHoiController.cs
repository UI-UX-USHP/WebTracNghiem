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
    public class DeThiCauHoiController : Controller
    {
        private readonly TracNghiemContext _context;

        public DeThiCauHoiController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: DeThiCauHoi
        public async Task<IActionResult> Index()
        {
            var tracNghiemContext = _context.TbDeThiCauHois.Include(t => t.MaCauHoiNavigation).Include(t => t.MaDeThiNavigation);
            return View(await tracNghiemContext.ToListAsync());
        }

        // GET: DeThiCauHoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThiCauHoi = await _context.TbDeThiCauHois
                .Include(t => t.MaCauHoiNavigation)
                .Include(t => t.MaDeThiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDeThiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbDeThiCauHoi);
        }

        // GET: DeThiCauHoi/Create
        public IActionResult Create()
        {
            ViewData["MaCauHoi"] = new SelectList(_context.TbCauHois, "Id", "Id");
            ViewData["MaDeThi"] = new SelectList(_context.TbDeThis, "Id", "Id");
            return View();
        }

        // POST: DeThiCauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaDeThi,MaCauHoi")] TbDeThiCauHoi tbDeThiCauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDeThiCauHoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaCauHoi"] = new SelectList(_context.TbCauHois, "Id", "Id", tbDeThiCauHoi.MaCauHoi);
            ViewData["MaDeThi"] = new SelectList(_context.TbDeThis, "Id", "Id", tbDeThiCauHoi.MaDeThi);
            return View(tbDeThiCauHoi);
        }

        // GET: DeThiCauHoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThiCauHoi = await _context.TbDeThiCauHois.FindAsync(id);
            if (tbDeThiCauHoi == null)
            {
                return NotFound();
            }
            ViewData["MaCauHoi"] = new SelectList(_context.TbCauHois, "Id", "Id", tbDeThiCauHoi.MaCauHoi);
            ViewData["MaDeThi"] = new SelectList(_context.TbDeThis, "Id", "Id", tbDeThiCauHoi.MaDeThi);
            return View(tbDeThiCauHoi);
        }

        // POST: DeThiCauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaDeThi,MaCauHoi")] TbDeThiCauHoi tbDeThiCauHoi)
        {
            if (id != tbDeThiCauHoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDeThiCauHoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDeThiCauHoiExists(tbDeThiCauHoi.Id))
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
            ViewData["MaCauHoi"] = new SelectList(_context.TbCauHois, "Id", "Id", tbDeThiCauHoi.MaCauHoi);
            ViewData["MaDeThi"] = new SelectList(_context.TbDeThis, "Id", "Id", tbDeThiCauHoi.MaDeThi);
            return View(tbDeThiCauHoi);
        }

        // GET: DeThiCauHoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeThiCauHoi = await _context.TbDeThiCauHois
                .Include(t => t.MaCauHoiNavigation)
                .Include(t => t.MaDeThiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbDeThiCauHoi == null)
            {
                return NotFound();
            }

            return View(tbDeThiCauHoi);
        }

        // POST: DeThiCauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDeThiCauHoi = await _context.TbDeThiCauHois.FindAsync(id);
            if (tbDeThiCauHoi != null)
            {
                _context.TbDeThiCauHois.Remove(tbDeThiCauHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDeThiCauHoiExists(int id)
        {
            return _context.TbDeThiCauHois.Any(e => e.Id == id);
        }
    }
}
