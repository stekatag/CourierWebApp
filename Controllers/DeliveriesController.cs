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
    public class DeliveriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Delivery.Include(d => d.Customer).Include(d => d.Item).Include(d => d.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET Deliveries/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST Deliveries/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            var deliveries = await _context.Delivery
                .Include(d => d.Customer)
                .Include(d => d.Unit)
                .Include(d => d.DeliveryItems) // Include the join table data
                .ThenInclude(di => di.Item) // Then include the Item data from the join table
                .Where(d => d.DeliveryItems.Any(di => di.Item.Name.Contains(SearchPhrase)
                                                    || di.Item.Description.Contains(SearchPhrase)))
                .ToListAsync();

            return View("Index", deliveries);
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Delivery
                .Include(d => d.Customer)
                .Include(d => d.Item)
                .Include(d => d.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerEmail");
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name");
            ViewData["UnitId"] = new SelectList(_context.Unit, "UnitId", "Unit");
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,ItemId,UnitId,Quantity,Price,Date")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delivery);
                await _context.SaveChangesAsync();

                // Assuming ItemId is the ID of the selected item for this delivery
                var deliveryItem = new DeliveryItem
                {
                    DeliveryId = delivery.Id,
                    ItemId = delivery.ItemId
                };

                _context.DeliveryItem.Add(deliveryItem);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerEmail", delivery.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", delivery.ItemId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "UnitId", "Unit", delivery.UnitId);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerEmail", delivery.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", delivery.ItemId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "UnitId", "Unit", delivery.UnitId);
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,ItemId,UnitId,Quantity,Price,Date")] Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerEmail", delivery.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", delivery.ItemId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "UnitId", "Unit", delivery.UnitId);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Delivery
                .Include(d => d.Customer)
                .Include(d => d.Item)
                .Include(d => d.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delivery = await _context.Delivery
                .Include(d => d.DeliveryItems) // Include the related DeliveryItems
                .FirstOrDefaultAsync(d => d.Id == id);

            if (delivery != null)
            {
                // Remove related DeliveryItem records first
                _context.DeliveryItem.RemoveRange(delivery.DeliveryItems);

                // Now remove the Delivery record
                _context.Delivery.Remove(delivery);

                // Save the changes to the database
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(int id)
        {
            return _context.Delivery.Any(e => e.Id == id);
        }
    }
}
