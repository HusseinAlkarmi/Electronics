using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronics.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Electronics.Controllers
{
    public class HomepageesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomepageesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        // GET: Homepagees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Homepagees.ToListAsync());
        }

        // GET: Homepagees/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepagee = await _context.Homepagees
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (homepagee == null)
            {
                return NotFound();
            }

            return View(homepagee);
        }

        // GET: Homepagees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Homepagees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageFile,HomeId,Image1,Image2,Image3,Text1,Text2,Image4,Text3,Text4,Text5,Text6,Image5,Image6,Image7,Text7")] Homepagee homepagee)
        {
            if (ModelState.IsValid)
            {
                if (homepagee.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + homepagee.ImageFile.FileName;
                    string extension = Path.GetExtension(homepagee.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await homepagee.ImageFile.CopyToAsync(fileStream);
                    }
                    homepagee.Image1 = fileName;
                    _context.Add(homepagee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            return View(homepagee);
        }

        // GET: Homepagees/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepagee = await _context.Homepagees.FindAsync(id);
            if (homepagee == null)
            {
                return NotFound();
            }
            return View(homepagee);
        }

        // POST: Homepagees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ImageFile,HomeId,Image1,Image2,Image3,Text1,Text2,Image4,Text3,Text4,Text5,Text6,Image5,Image6,Image7,Text7")] Homepagee homepagee)
        {
            if (id != homepagee.HomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (homepagee.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + homepagee.ImageFile.FileName;
                        string extension = Path.GetExtension(homepagee.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await homepagee.ImageFile.CopyToAsync(fileStream);
                        }
                        homepagee.Image1 = fileName;
                        _context.Update(homepagee);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomepageeExists(homepagee.HomeId))
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
            return View(homepagee);
        }

        // GET: Homepagees/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homepagee = await _context.Homepagees
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (homepagee == null)
            {
                return NotFound();
            }

            return View(homepagee);
        }

        // POST: Homepagees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var homepagee = await _context.Homepagees.FindAsync(id);
            _context.Homepagees.Remove(homepagee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomepageeExists(decimal id)
        {
            return _context.Homepagees.Any(e => e.HomeId == id);
        }

        public IActionResult customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");

            var modelContext = _context.Categoryes.ToList();
            var modelContext2 = _context.Productes.Include(p => p.Category);
            var homePage = _context.Homepagees.ToList();

            var model = new Tuple<IEnumerable<Electronics.Models.Categorye>, IEnumerable<Electronics.Models.Producte>, IEnumerable<Electronics.Models.Homepagee>>(modelContext, modelContext2, homePage);

            return View(model);
        }
    }
}
