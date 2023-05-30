using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UAINDE.Data;
using UAINDE.Models;

namespace UAINDE.Controllers
{
    public class SearchingCategoriesController : Controller
    {
        private readonly UAINDEContext _context;

        public SearchingCategoriesController(UAINDEContext context)
        {
            _context = context;
        }

        // GET: SearchingCategories
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.SearchingCategories == null)
            {
                return Problem("Entity set 'UAINDEContext.SearchingCategories'  is null.");
            }

            var people = from p in _context.SearchingCategories
                select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.WorkingSphere!.Contains(searchString));
            }

            return View(await people.ToListAsync());
        }

        // GET: SearchingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchingCategories == null)
            {
                return NotFound();
            }

            var searchingCategories = await _context.SearchingCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (searchingCategories == null)
            {
                return NotFound();
            }

            return View(searchingCategories);
        }

        // GET: SearchingCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SearchingCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkingSphere,Speciality,FirstName,LastName,City,WorkExperience,SocialNetworkLink,AdditionalInformation,PhoneNumber,PhotoLink")] SearchingCategories searchingCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchingCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchingCategories);
        }

        // GET: SearchingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchingCategories == null)
            {
                return NotFound();
            }

            var searchingCategories = await _context.SearchingCategories.FindAsync(id);
            if (searchingCategories == null)
            {
                return NotFound();
            }
            return View(searchingCategories);
        }

        // POST: SearchingCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkingSphere,Speciality,FirstName,LastName,City,WorkExperience,SocialNetworkLink,AdditionalInformation,PhoneNumber,PhotoLink")] SearchingCategories searchingCategories)
        {
            if (id != searchingCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchingCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchingCategoriesExists(searchingCategories.Id))
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
            return View(searchingCategories);
        }

        // GET: SearchingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchingCategories == null)
            {
                return NotFound();
            }

            var searchingCategories = await _context.SearchingCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (searchingCategories == null)
            {
                return NotFound();
            }

            return View(searchingCategories);
        }

        // POST: SearchingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchingCategories == null)
            {
                return Problem("Entity set 'UAINDEContext.SearchingCategories'  is null.");
            }
            var searchingCategories = await _context.SearchingCategories.FindAsync(id);
            if (searchingCategories != null)
            {
                _context.SearchingCategories.Remove(searchingCategories);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchingCategoriesExists(int id)
        {
          return (_context.SearchingCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
