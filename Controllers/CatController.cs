﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class CatController : Controller
    {
        private readonly animal_shelterContext _context;

        public CatController(animal_shelterContext context)
        {
            _context = context;
        }

        // GET: Cat
        public async Task<IActionResult> Index()
        {
            var animal_shelterContext = _context.Cats.Include(c => c.Centre);
            return View(await animal_shelterContext.ToListAsync());
        }

        // GET: Cat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Centre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cat/Create
        public IActionResult Create()
        {
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Name");
            return View();
        }

        // POST: Cat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Breed,IntelligenceCoefficient,Cleansed,CentreId")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Name", cat.CentreId);
            return View(cat);
        }

        // GET: Cat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Name", cat.CentreId);
            return View(cat);
        }

        // POST: Cat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Breed,IntelligenceCoefficient,Cleansed,CentreId")] Cat cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.Id))
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
            ViewData["CentreId"] = new SelectList(_context.Centres, "Id", "Name", cat.CentreId);
            return View(cat);
        }

        // GET: Cat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats
                .Include(c => c.Centre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cats.FindAsync(id);
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}