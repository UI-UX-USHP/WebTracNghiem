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
    public class MucDoController : Controller
    {
        private readonly TracNghiemContext _context;

        public MucDoController(TracNghiemContext context)
        {
            _context = context;
        }

        // GET: MucDo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbMucDos.ToListAsync());
        }

        // GET: MucDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDo = await _context.TbMucDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMucDo == null)
            {
                return NotFound();
            }

            return View(tbMucDo);
        }

        // GET: MucDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MucDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenMucDo")] TbMucDo tbMucDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMucDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMucDo);
        }

        // GET: MucDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDo = await _context.TbMucDos.FindAsync(id);
            if (tbMucDo == null)
            {
                return NotFound();
            }
            return View(tbMucDo);
        }

        // POST: MucDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenMucDo")] TbMucDo tbMucDo)
        {
            if (id != tbMucDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMucDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMucDoExists(tbMucDo.Id))
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
            return View(tbMucDo);
        }

        // GET: MucDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMucDo = await _context.TbMucDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMucDo == null)
            {
                return NotFound();
            }

            return View(tbMucDo);
        }

        // POST: MucDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMucDo = await _context.TbMucDos.FindAsync(id);
            if (tbMucDo != null)
            {
                _context.TbMucDos.Remove(tbMucDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMucDoExists(int id)
        {
            return _context.TbMucDos.Any(e => e.Id == id);
        }
    }
}
