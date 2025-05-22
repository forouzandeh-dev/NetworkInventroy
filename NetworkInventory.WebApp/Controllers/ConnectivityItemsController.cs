using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetworkInventory.WebApp.Models;

namespace NetworkInventory.WebApp.Controllers
{
    public class ConnectivityItemsController : Controller
    {
        private readonly InventoryContext _context;

        public ConnectivityItemsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: ConnectivityItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConnectivityItems.ToListAsync());
        }

        // GET: ConnectivityItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectivityItem = await _context.ConnectivityItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connectivityItem == null)
            {
                return NotFound();
            }

            return View(connectivityItem);
        }

        // GET: ConnectivityItems/Create
        public IActionResult Create()
        {
            ViewBag.ItemTypes= new List<string> { "Cable","Keystone","Faceplate", "Fiber", "SFP"};
            return View();
        }

        // POST: ConnectivityItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ItemType,Length,CableType,KeystoneCategory,PortCount,Location,InstallationDate")] ConnectivityItem connectivityItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connectivityItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(connectivityItem);
        }

        // GET: ConnectivityItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectivityItem = await _context.ConnectivityItems.FindAsync(id);
            if (connectivityItem == null)
            {
                return NotFound();
            }
            ViewBag.ItemTypes= new List<string> { "Cable", "Keystone", "Faceplate", "Fiber", "SFP" };
            return View(connectivityItem);
        }

        // POST: ConnectivityItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ItemType,Length,CableType,KeystoneCategory,PortCount,Location,InstallationDate")] ConnectivityItem connectivityItem)
        {
            if (id != connectivityItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connectivityItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectivityItemExists(connectivityItem.Id))
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
            return View(connectivityItem);
        }

        // GET: ConnectivityItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectivityItem = await _context.ConnectivityItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connectivityItem == null)
            {
                return NotFound();
            }

            return View(connectivityItem);
        }

        // POST: ConnectivityItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var connectivityItem = await _context.ConnectivityItems.FindAsync(id);
            if (connectivityItem != null)
            {
                _context.ConnectivityItems.Remove(connectivityItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectivityItemExists(int id)
        {
            return _context.ConnectivityItems.Any(e => e.Id == id);
        }
    }
}
