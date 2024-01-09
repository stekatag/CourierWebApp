using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourierWebApp.Data;
using CourierWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CourierWebApp.Controllers
{
    [Authorize]
    public class UnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unit.ToListAsync());
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,Unit")] Units units)
        {
            if (ModelState.IsValid)
            {
                _context.Add(units);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(units);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Unit.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }
            return View(units);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("UnitId,Unit")] Units units)
        {
            if (id != units.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(units);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsExists(units.UnitId))
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
            return View(units);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = await _context.Unit
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (units == null)
            {
                return NotFound();
            }

            return View(units);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var units = await _context.Unit.FindAsync(id);
            if(units != null)
            {
                // Check if the customer is associated with any deliveries
                var hasDeliveries = _context.Delivery.Any(d => d.UnitId == id);
                if (hasDeliveries)
                {
                    // If there are deliveries, do not delete the customer
                    // Instead, return a view with a message indicating the issue
                    TempData["ErrorMessage"] = "You can't delete this unit as there are existing deliveries associated with this unit.";
                    return View("Delete", units);
                }

                _context.Unit.Remove(units);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsExists(int? id)
        {
            return _context.Unit.Any(e => e.UnitId == id);
        }
    }
}
