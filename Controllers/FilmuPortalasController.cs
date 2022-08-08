using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgzaminoUzduotis.Data;
using EgzaminoUzduotis.Models;

namespace EgzaminoUzduotis.Controllers
{
    public class FilmuPortalasController : Controller
    {
        private readonly EgzaminoUzduotisContext _context;

        public FilmuPortalasController(EgzaminoUzduotisContext context)
        {
            _context = context;
        }

        // GET: FilmuPortalas
        public async Task<IActionResult> Index()
        {
              return _context.FilmuPortalas != null ? 
                          View(await _context.FilmuPortalas.ToListAsync()) :
                          Problem("Entity set 'EgzaminoUzduotisContext.FilmuPortalas'  is null.");
        }

        // GET: FilmuPortalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmuPortalas == null)
            {
                return NotFound();
            }

            var filmuPortalas = await _context.FilmuPortalas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmuPortalas == null)
            {
                return NotFound();
            }

            return View(filmuPortalas);
        }

        // GET: FilmuPortalas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmuPortalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] FilmuPortalas filmuPortalas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmuPortalas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmuPortalas);
        }

        // GET: FilmuPortalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmuPortalas == null)
            {
                return NotFound();
            }

            var filmuPortalas = await _context.FilmuPortalas.FindAsync(id);
            if (filmuPortalas == null)
            {
                return NotFound();
            }
            return View(filmuPortalas);
        }

        // POST: FilmuPortalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] FilmuPortalas filmuPortalas)
        {
            if (id != filmuPortalas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmuPortalas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmuPortalasExists(filmuPortalas.Id))
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
            return View(filmuPortalas);
        }

        // GET: FilmuPortalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmuPortalas == null)
            {
                return NotFound();
            }

            var filmuPortalas = await _context.FilmuPortalas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmuPortalas == null)
            {
                return NotFound();
            }

            return View(filmuPortalas);
        }

        // POST: FilmuPortalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmuPortalas == null)
            {
                return Problem("Entity set 'EgzaminoUzduotisContext.FilmuPortalas'  is null.");
            }
            var filmuPortalas = await _context.FilmuPortalas.FindAsync(id);
            if (filmuPortalas != null)
            {
                _context.FilmuPortalas.Remove(filmuPortalas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmuPortalasExists(int id)
        {
          return (_context.FilmuPortalas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
