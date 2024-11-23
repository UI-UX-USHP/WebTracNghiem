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
    public class MonHocController : Controller
    {
        private readonly TracNghiemContext _context;

        public MonHocController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: MonHoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbMonHocs.ToListAsync());
        }

        // GET: MonHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }

            return View(tbMonHoc);
        }

        // GET: MonHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenMonHoc")] TbMonHoc tbMonHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMonHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMonHoc);
        }

        // GET: MonHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs.FindAsync(id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }
            return View(tbMonHoc);
        }

        // POST: MonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMonHoc")] TbMonHoc tbMonHoc)
        {
            if (id != tbMonHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMonHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMonHocExists(tbMonHoc.Id))
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
            return View(tbMonHoc);
        }

        // GET: MonHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMonHoc = await _context.TbMonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMonHoc == null)
            {
                return NotFound();
            }

            return View(tbMonHoc);
        }

        // POST: MonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMonHoc = await _context.TbMonHocs.FindAsync(id);
            if (tbMonHoc != null)
            {
                _context.TbMonHocs.Remove(tbMonHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMonHocExists(int id)
        {
            return _context.TbMonHocs.Any(e => e.Id == id);
        }
    }
}
