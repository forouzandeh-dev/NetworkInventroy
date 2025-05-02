using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetworkInventory.WebApp.Models;

namespace NetworkInventory.WebApp.Controllers
{
    public class CablesController : Controller
    {
        private readonly InventoryContext _context;

        public CablesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Cables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cables.ToListAsync());
        }

        // GET: Cables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cable = await _context.Cables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cable == null)
            {
                return NotFound();
            }

            return View(cable);
        }

        // GET: Cables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Length,Location,InstallationDate")] Cable cable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cable);
        }

        // GET: Cables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cable = await _context.Cables.FindAsync(id);
            if (cable == null)
            {
                return NotFound();
            }
            return View(cable);
        }

        // POST: Cables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Length,Location,InstallationDate")] Cable cable)
        {
            if (id != cable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CableExists(cable.Id))
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
            return View(cable);
        }

        // GET: Cables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cable = await _context.Cables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cable == null)
            {
                return NotFound();
            }

            return View(cable);
        }

        // POST: Cables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cable = await _context.Cables.FindAsync(id);
            if (cable != null)
            {
                _context.Cables.Remove(cable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CableExists(int id)
        {
            return _context.Cables.Any(e => e.Id == id);
        }
    }
}
