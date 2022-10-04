using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B2C2Week3Demo.Data;
using B2C2Week3Demo.Models;

namespace B2C2Week3Demo.Controllers
{
    public class MandenController : Controller
    {
        private readonly AppDbContext _context;

        public MandenController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Manden
        public async Task<IActionResult> Index()
        {
              return View(await _context.Manden.ToListAsync());
        }

        // GET: Manden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
             
            
            if (id == null || _context.Manden == null)
            {
                return NotFound();
            }

            var mand = _context.Manden.Include(m => m.Fruit).FirstOrDefault(m => m.Id == id);
            if (mand == null)
            {
                return NotFound();
            }

            return View(mand);
        }

        // GET: Manden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Materiaal,Volume,Kleur")] Mand mand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mand);
        }

        // GET: Manden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manden == null)
            {
                return NotFound();
            }

            var mand = await _context.Manden.FindAsync(id);
            if (mand == null)
            {
                return NotFound();
            }
            return View(mand);
        }

        // POST: Manden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Materiaal,Volume,Kleur")] Mand mand)
        {
            if (id != mand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MandExists(mand.Id))
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
            return View(mand);
        }

        // GET: Manden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manden == null)
            {
                return NotFound();
            }

            var mand = await _context.Manden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mand == null)
            {
                return NotFound();
            }

            return View(mand);
        }

        // POST: Manden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manden == null)
            {
                return Problem("Entity set 'AppDbContext.Manden'  is null.");
            }
            var mand = await _context.Manden.FindAsync(id);
            if (mand != null)
            {
                _context.Manden.Remove(mand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MandExists(int id)
        {
          return _context.Manden.Any(e => e.Id == id);
        }
    }
}
