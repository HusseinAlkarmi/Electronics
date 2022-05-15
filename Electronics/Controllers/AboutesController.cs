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
    public class AboutesController : Controller
    {
        private readonly ModelContext _context;

        public AboutesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Aboutes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Aboutes.Include(a => a.Home);
            return View(await modelContext.ToListAsync());
        }

        // GET: Aboutes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboute = await _context.Aboutes
                .Include(a => a.Home)
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboute == null)
            {
                return NotFound();
            }

            return View(aboute);
        }

        // GET: Aboutes/Create
        public IActionResult Create()
        {
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId");
            return View();
        }

        // POST: Aboutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutId,Text1,Image1,Image2,Text3,HomeId")] Aboute aboute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", aboute.HomeId);
            return View(aboute);
        }

        // GET: Aboutes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboute = await _context.Aboutes.FindAsync(id);
            if (aboute == null)
            {
                return NotFound();
            }
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", aboute.HomeId);
            return View(aboute);
        }

        // POST: Aboutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AboutId,Text1,Image1,Image2,Text3,HomeId")] Aboute aboute)
        {
            if (id != aboute.AboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbouteExists(aboute.AboutId))
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
            ViewData["HomeId"] = new SelectList(_context.Homepagees, "HomeId", "HomeId", aboute.HomeId);
            return View(aboute);
        }

        // GET: Aboutes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboute = await _context.Aboutes
                .Include(a => a.Home)
                .FirstOrDefaultAsync(m => m.AboutId == id);
            if (aboute == null)
            {
                return NotFound();
            }

            return View(aboute);
        }

        // POST: Aboutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var aboute = await _context.Aboutes.FindAsync(id);
            _context.Aboutes.Remove(aboute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbouteExists(decimal id)
        {
            return _context.Aboutes.Any(e => e.AboutId == id);
        }

        public IActionResult Customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            var modelContext = _context.Aboutes.Include(a => a.Home);
            return View(modelContext.ToList());
        }
    }
}