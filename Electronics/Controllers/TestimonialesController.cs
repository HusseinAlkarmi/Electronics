using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics.Models;
using Microsoft.AspNetCore.Http;

namespace Electronics.Controllers
{
    public class TestimonialesController : Controller
    {
        private readonly ModelContext _context;

        public TestimonialesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Testimoniales
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Testimoniales.Include(t => t.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Testimoniales/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoniale = await _context.Testimoniales
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (testimoniale == null)
            {
                return NotFound();
            }

            return View(testimoniale);
        }

        // GET: Testimoniales/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            return View();
        }

        // POST: Testimoniales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestimonialId,TestimonialText,UserId")] Testimoniale testimoniale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testimoniale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", testimoniale.UserId);
            return View(testimoniale);
        }

        // GET: Testimoniales/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoniale = await _context.Testimoniales.FindAsync(id);
            if (testimoniale == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", testimoniale.UserId);
            return View(testimoniale);
        }

        // POST: Testimoniales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TestimonialId,TestimonialText,UserId")] Testimoniale testimoniale)
        {
            if (id != testimoniale.TestimonialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimoniale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialeExists(testimoniale.TestimonialId))
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
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", testimoniale.UserId);
            return View(testimoniale);
        }

        // GET: Testimoniales/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoniale = await _context.Testimoniales
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TestimonialId == id);
            if (testimoniale == null)
            {
                return NotFound();
            }

            return View(testimoniale);
        }

        // POST: Testimoniales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var testimoniale = await _context.Testimoniales.FindAsync(id);
            _context.Testimoniales.Remove(testimoniale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialeExists(decimal id)
        {
            return _context.Testimoniales.Any(e => e.TestimonialId == id);
        }

       
        public IActionResult customerTesti()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            return View();
        }

        // POST: Testimoniales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> customerTesti([Bind("TestimonialId,TestimonialText,UserId")] Testimoniale testimoniale)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            if (ModelState.IsValid)
            {
               
                _context.Add(testimoniale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", testimoniale.UserId);
            return View(testimoniale);
        }
    }
}
