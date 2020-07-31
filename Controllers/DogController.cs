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
    public class DogController : Controller
    {
        private const string AdoptionCentreString = "Adoption Centre";

        private readonly animal_shelterContext _context;

        public DogController(animal_shelterContext context)
        {
            _context = context;
        }

        // GET: Dog
        public async Task<IActionResult> Index()
        {
            var animal_shelterContext = _context.Dogs.Include(d => d.Centre);
            return View(await animal_shelterContext.ToListAsync());
        }

        // GET: Dog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Centre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // GET: Dog/Create
        public IActionResult Register()
        {
            ViewData["Cleansed"] = new List<SelectListItem> { new SelectListItem { Text = "Yes", Value = "1" }, new SelectListItem { Text = "No", Value = "0" } };
            ViewData["CentreId"] = new SelectList(_context.Centres.Where(c => c.Type == AdoptionCentreString), "Id", "Name");
            return View();
        }

        // POST: Dog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Breed,Cleansed,CentreId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cleansed"] = new List<SelectListItem> { new SelectListItem { Text = "Yes", Value = "1" }, new SelectListItem { Text = "No", Value = "0" } };
            ViewData["CentreId"] = new SelectList(_context.Centres.Where(c => c.Type == AdoptionCentreString), "Id", "Name", dog.CentreId);
            return View(dog);
        }

        // GET: Dog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            ViewData["Cleansed"] = new List<SelectListItem> { new SelectListItem { Text = "Yes", Value = "1" }, new SelectListItem { Text = "No", Value = "0" } };
            ViewData["CentreId"] = new SelectList(_context.Centres.Where(c => c.Type == AdoptionCentreString), "Id", "Name", dog.CentreId);
            return View(dog);
        }

        // POST: Dog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Breed,Cleansed,CentreId")] Dog dog)
        {
            if (id != dog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogExists(dog.Id))
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
            ViewData["CentreId"] = new SelectList(_context.Centres.Where(c => c.Type==AdoptionCentreString), "Id", "Name", dog.CentreId);
            return View(dog);
        }

        // GET: Dog/Delete/5
        public async Task<IActionResult> Adopt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Centre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: Dog/Delete/5
        [HttpPost, ActionName("Adopt")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdoptConfirmed(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            var centre = _context.Centres.FirstOrDefault(d => d.Id == dog.CentreId);

            if (centre.Type == AdoptionCentreString && dog.Cleansed == 1)
            {
                _context.Dogs.Remove(dog);
                await _context.SaveChangesAsync();
                TempData["Error"] = null;
            }
            else
            {
                TempData["Error"] = "Animal must be cleansed and it must be in adoption center!";
                return View(dog);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }
    }
}
