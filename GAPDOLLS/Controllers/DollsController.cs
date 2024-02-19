﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAPDOLLS.Data;
using GAPDOLLS.Models;

namespace GAPDOLLS.Controllers
{
    public class DollsController : Controller
    {
        private readonly GAPDOLLSContext _context;

        public DollsController(GAPDOLLSContext context)
        {
            _context = context;
        }

        // GET: Dolls
        // GET: Movies
        public async Task<IActionResult> Index(string DollSkinTone, string searchString)
        {
            if (_context.Dolls == null)
            {
                return Problem("Entity set 'GAPDOLLSContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Dolls
                                            orderby m.SkinTone
                                            select m.SkinTone;
            var movies = from m in _context.Dolls
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Material!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DollSkinTone))
            {
                movies = movies.Where(x => x.SkinTone == DollSkinTone);
            }

            var movieGenreVM = new DollSkinToneViewModel
            {
                SkinTone = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Dolls = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Dolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolls = await _context.Dolls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dolls == null)
            {
                return NotFound();
            }

            return View(dolls);
        }

        // GET: Dolls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Material,Color,ManufactureDate,Articulation,Price,Rating,Size,EyeColor,SkinTone,Outfit,Accessories,Washability")] Dolls dolls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dolls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dolls);
        }

        // GET: Dolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolls = await _context.Dolls.FindAsync(id);
            if (dolls == null)
            {
                return NotFound();
            }
            return View(dolls);
        }

        // POST: Dolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Material,Color,ManufactureDate,Articulation,Price,Rating,Size,EyeColor,SkinTone,Outfit,Accessories,Washability")] Dolls dolls)
        {
            if (id != dolls.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dolls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollsExists(dolls.Id))
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
            return View(dolls);
        }

        // GET: Dolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolls = await _context.Dolls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dolls == null)
            {
                return NotFound();
            }

            return View(dolls);
        }

        // POST: Dolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dolls = await _context.Dolls.FindAsync(id);
            if (dolls != null)
            {
                _context.Dolls.Remove(dolls);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollsExists(int id)
        {
            return _context.Dolls.Any(e => e.Id == id);
        }
    }
}
