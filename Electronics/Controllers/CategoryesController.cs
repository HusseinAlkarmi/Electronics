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
    public class CategoryesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoryesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: Categoryes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoryes.ToListAsync());
        }

        // GET: Categoryes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorye = await _context.Categoryes
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categorye == null)
            {
                return NotFound();
            }

            return View(categorye);
        }

        // GET: Categoryes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoryes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Categoryname,Image,ImageFile")] Categorye categorye)
        {
            if (ModelState.IsValid)
            {
                if (categorye.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + categorye.ImageFile.FileName;
                    string extension = Path.GetExtension(categorye.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categorye.ImageFile.CopyToAsync(fileStream);
                    }
                    categorye.Image = fileName;
                    _context.Add(categorye);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            return View(categorye);
        }
        // GET: Categoryes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorye = await _context.Categoryes.FindAsync(id);
            if (categorye == null)
            {
                return NotFound();
            }
            return View(categorye);
        }

        // POST: Categoryes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ImageFile,CategoryId,Categoryname,Image")] Categorye categorye)
        {
            if (id != categorye.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categorye.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + categorye.ImageFile.FileName;
                        string extension = Path.GetExtension(categorye.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await categorye.ImageFile.CopyToAsync(fileStream);
                        }
                        categorye.Image = fileName;
                        _context.Update(categorye);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                }
                
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryeExists(categorye.CategoryId))
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
            return View(categorye);
        }

        // GET: Categoryes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorye = await _context.Categoryes
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categorye == null)
            {
                return NotFound();
            }

            return View(categorye);
        }

        // POST: Categoryes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categorye = await _context.Categoryes.FindAsync(id);
            _context.Categoryes.Remove(categorye);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryeExists(decimal id)
        {
            return _context.Categoryes.Any(e => e.CategoryId == id);
        }

        public IActionResult Customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            var modelContext = _context.Categoryes.ToList();
            return View(modelContext);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Customer(string name)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            var cate = _context.Categoryes.Where(x => x.Categoryname.Contains(name)).ToList();
          
            return View(cate);
        }

    }
}
