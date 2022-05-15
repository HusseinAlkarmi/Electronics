using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics.Models;

namespace Electronics.Controllers
{
    public class ReviewesController : Controller
    {
        private readonly ModelContext _context;

        public ReviewesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Reviewes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Reviewes.Include(r => r.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Reviewes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewe = await _context.Reviewes
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviewe == null)
            {
                return NotFound();
            }

            return View(reviewe);
        }

        // GET: Reviewes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            return View();
        }

        // POST: Reviewes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,UserId,Rating,Message")] Reviewe reviewe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", reviewe.UserId);
            return View(reviewe);
        }

        // GET: Reviewes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewe = await _context.Reviewes.FindAsync(id);
            if (reviewe == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", reviewe.UserId);
            return View(reviewe);
        }

        // POST: Reviewes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ReviewId,UserId,Rating,Message")] Reviewe reviewe)
        {
            if (id != reviewe.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevieweExists(reviewe.ReviewId))
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
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", reviewe.UserId);
            return View(reviewe);
        }

        // GET: Reviewes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewe = await _context.Reviewes
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviewe == null)
            {
                return NotFound();
            }

            return View(reviewe);
        }

        // POST: Reviewes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var reviewe = await _context.Reviewes.FindAsync(id);
            _context.Reviewes.Remove(reviewe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevieweExists(decimal id)
        {
            return _context.Reviewes.Any(e => e.ReviewId == id);
        }
    }
}
