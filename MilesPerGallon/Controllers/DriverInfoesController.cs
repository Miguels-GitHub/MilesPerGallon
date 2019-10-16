using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilesPerGallon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilesPerGallon.Controllers
{
    public class DriverInfoesController : Controller
    {
        private readonly MPGDatabaseContext _context;

        public DriverInfoesController(MPGDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Search()
        {
            return View(await _context.DriverInfo.ToListAsync());
        }

        // GET: DriverInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DriverInfo.ToListAsync());
        }

        // GET: DriverInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverInfo = await _context.DriverInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverInfo == null)
            {
                return NotFound();
            }

            return View(driverInfo);
        }

        // GET: DriverInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriverInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname,CarModel,MilesDriven,GallonsFilled,FillupDate")] DriverInfo driverInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driverInfo);
        }

        // GET: DriverInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverInfo = await _context.DriverInfo.FindAsync(id);
            if (driverInfo == null)
            {
                return NotFound();
            }
            return View(driverInfo);
        }

        // POST: DriverInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fname,Lname,CarModel,MilesDriven,GallonsFilled,FillupDate")] DriverInfo driverInfo)
        {
            if (id != driverInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverInfoExists(driverInfo.Id))
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
            return View(driverInfo);
        }

        // GET: DriverInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverInfo = await _context.DriverInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverInfo == null)
            {
                return NotFound();
            }

            return View(driverInfo);
        }

        // POST: DriverInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverInfo = await _context.DriverInfo.FindAsync(id);
            _context.DriverInfo.Remove(driverInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverInfoExists(int id)
        {
            return _context.DriverInfo.Any(e => e.Id == id);
        }
    }
}
