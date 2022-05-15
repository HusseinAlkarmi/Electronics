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
    public class ContactesController : Controller
    {
        private readonly ModelContext _context;

        public ContactesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Contactes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Contactes.Include(c => c.Home);
            return View(await modelContext.ToListAsync());
        }

        // GET: Contactes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacte = await _context.Contactes
                .Include(c => c.Home)
                .FirstOrDefaultAsync(m => m.ContId == id);
            if (contacte == null)
            {
                return NotFound();
            }

            return View(contacte);
        }

        // GET: Contactes/Create
        public IActionResult Create()
        {
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId");
            return View();
        }

        // POST: Contactes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContId,Name,Age,Email,Phone,HomeId")] Contacte contacte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", contacte.HomeId);
            return View(contacte);
        }

        // GET: Contactes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacte = await _context.Contactes.FindAsync(id);
            if (contacte == null)
            {
                return NotFound();
            }
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", contacte.HomeId);
            return View(contacte);
        }

        // POST: Contactes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ContId,Name,Age,Email,Phone,HomeId")] Contacte contacte)
        {
            if (id != contacte.ContId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContacteExists(contacte.ContId))
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
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", contacte.HomeId);
            return View(contacte);
        }

        // GET: Contactes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacte = await _context.Contactes
                .Include(c => c.Home)
                .FirstOrDefaultAsync(m => m.ContId == id);
            if (contacte == null)
            {
                return NotFound();
            }

            return View(contacte);
        }

        // POST: Contactes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var contacte = await _context.Contactes.FindAsync(id);
            _context.Contactes.Remove(contacte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContacteExists(decimal id)
        {
            return _context.Contactes.Any(e => e.ContId == id);
        }

        public IActionResult Customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            //ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId");
            return View();
        }

        // POST: Contactes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Customer([Bind("ContId,Name,Age,Email,Phone,HomeId")] Contacte contacte)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            if (ModelState.IsValid)
            {
                if (contacte.Email != null)
                {
                    _context.Add(contacte);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("customer", "homepagees");
                }
            }
            //ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", contacte.HomeId);
            return View("Customer");
        }
    }
}
