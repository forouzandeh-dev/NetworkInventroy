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
    public class DevicesController : Controller
    {
        private readonly InventoryContext _context;

        public DevicesController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index(string searchString, string type)
        {
            ViewBag.DeviceCategories = await _context.DeviceCategories.ToListAsync();
            ViewBag.ConnectivityItemTypes = await _context.ConnectivityItems
               .Select(ci => ci.ItemType)
               .Distinct()
               .ToListAsync();

            ViewData["CurrentFilter"]=searchString;
            var devices = _context.Devices.Include(d => d.DeviceCategory).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d=>d.Name!=null&& d.Name.Contains(searchString)||
                d.DeviceCategory!=null&&d.DeviceCategory.Name.Contains(searchString)||
                d.location.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(type))
            { 
                devices = devices.Where(d=> d.DeviceCategory!= null && d.DeviceCategory.Name!=null&& d.DeviceCategory.Name.ToLower()== type.ToLower());
            
            }
            ViewData["CurrentFilter"] = searchString;
            return View(await devices.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.DeviceCategories = await _context.DeviceCategories.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {

            ViewBag.DeviceCategoryId = new SelectList(_context.DeviceCategories, "Id", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DeviceCategoryId,location,InstallationDate")] Device devices)
        {

            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                _context.Add(devices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DeviceCategoryId= new SelectList(_context.DeviceCategories, "Id", "Name",devices.DeviceCategoryId);
            return View(devices);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            

            if (id == null)
            {
                
                return NotFound();
            }

            var devices = await _context.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            ViewBag.DeviceCategoryId = new SelectList(_context.DeviceCategories, "Id", "Name", devices.DeviceCategoryId);
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DeviceCategoryId,location,InstallationDate")] Device devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicesExists(devices.Id))
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
            ViewBag.DeviceCategoryId = new SelectList(_context.DeviceCategories, "Id", "Name", devices.DeviceCategoryId);
            return View(devices);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.DeviceCategories = await _context.DeviceCategories.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devices = await _context.Devices.FindAsync(id);
            if (devices != null)
            {
                _context.Devices.Remove(devices);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicesExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }
    }
}
