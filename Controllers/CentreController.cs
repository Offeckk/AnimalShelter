using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class CentreController : Controller
    {
        private const string AdoptionCentreString = "Adoption Centre";
        private const string CleansingCentreString = "Cleansing Centre";

        private readonly animal_shelterContext _context;

        public CentreController(animal_shelterContext context)
        {
            _context = context;
        }

        // GET: Centres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Centres.ToListAsync());
        }

        // GET: Centres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centre = await _context.Centres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centre == null)
            {
                return NotFound();
            }

            
            return View(centre);
        }

        // GET: Centres/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new List<SelectListItem> { new SelectListItem { Text = AdoptionCentreString, Value = AdoptionCentreString }, new SelectListItem { Text = CleansingCentreString, Value = CleansingCentreString } };
                return View();
        }

        // POST: Centres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] Centre centre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new List<SelectListItem> { new SelectListItem { Text = AdoptionCentreString, Value = AdoptionCentreString }, new SelectListItem { Text = CleansingCentreString, Value = CleansingCentreString } };
            return View(centre);
        }

        // GET: Centres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centre = await _context.Centres.FindAsync(id);
            if (centre == null)
            {
                return NotFound();
            }
            return View(centre);
        }

        // POST: Centres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] Centre centre)
        {
            if (id != centre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentreExists(centre.Id))
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
            return View(centre);
        }

        // GET: Centres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centre = await _context.Centres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centre == null)
            {
                return NotFound();
            }

            return View(centre);
        }

        // POST: Centres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centre = await _context.Centres.FindAsync(id);
            _context.Centres.Remove(centre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentreExists(int id)
        {
            return _context.Centres.Any(e => e.Id == id);
        }
    }
}
