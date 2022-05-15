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
    public class ProductesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ProductesController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: Productes
        //public async Task<IActionResult> Index()
        //{
        public IActionResult Index()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "CategoryId", "CategoryId");

            //var modelContext = _context.Productes.Include(p => p.Category);
            //return View(await modelContext.ToListAsync());
            var modelContext = _context.Productes.ToList();
            return View(modelContext);
        }

        // GET: Productes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.Productes
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (producte == null)
            {
                return NotFound();
            }

            return View(producte);
        }

        // GET: Productes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Productes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Quntity,Sale,Cost,Image,CategoryId,ImageFile")] Producte producte)
        {
            if (ModelState.IsValid)
            {
                if (producte.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + producte.ImageFile.FileName;
                    string extension = Path.GetExtension(producte.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await producte.ImageFile.CopyToAsync(fileStream);
                    }
                    producte.Image = fileName;
                    _context.Add(producte);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "CategoryId", "CategoryId", producte.CategoryId);
            return View(producte);
        }

        // GET: Productes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.Productes.FindAsync(id);
            if (producte == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "CategoryId", "CategoryId", producte.CategoryId);
            return View(producte);
        }

        // POST: Productes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ProductId,ProductName,Quntity,Sale,Cost,Image,CategoryId,ImageFile")] Producte producte)
        {
            if (id != producte.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (producte.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + producte.ImageFile.FileName;
                        string extension = Path.GetExtension(producte.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await producte.ImageFile.CopyToAsync(fileStream);
                        }
                        producte.Image = fileName;
                        _context.Update(producte);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducteExists(producte.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categoryes, "CategoryId", "CategoryId", producte.CategoryId);
            return View(producte);
        }

        // GET: Productes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.Productes
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (producte == null)
            {
                return NotFound();
            }

            return View(producte);
        }

        // POST: Productes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var producte = await _context.Productes.FindAsync(id);
            _context.Productes.Remove(producte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducteExists(decimal id)
        {
            return _context.Productes.Any(e => e.ProductId == id);
        }



        public IActionResult Customerpro()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            var modelContext = _context.Productes.Include(p => p.Category);
            return View(modelContext);
        }

        public IActionResult Customer(int id)
        {
            string idd = "id";
            ViewBag.session = HttpContext.Session.GetInt32(idd);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            //var modelContext = _context.Productes.Include(p => p.Category);
            var prod = _context.Productes.Where(x => x.CategoryId == id).ToList();

            return View(prod);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Customer(int id)
        //{
        //    //var modelContext = _context.Productes.Include(p => p.Category);

        //    var prod = _context.Productes.Where(x => x.CategoryId == id ).ToList();

        //    //var Auth2 = _context.Productes.Where(x => x.ProductId == prodId).SingleOrDefault();   , int prodId


        //    //const string prodId = "prodId";
        //    //HttpContext.Session.SetInt32(prodId, (int)prod.);
        //    return View(prod);
        //}
      


        //public IActionResult BuyNow(int prodId)
        //{


        //    var prod2 = _context.Productes.Where(x => x.ProductId == prodId).FirstOrDefault();


        //    return View(prod2);
        //}




        //[HttpPost]
        //public IActionResult Customer(int prodId)
        //{
        //    var Auth2 = _context.Productes.Where(x => x.ProductId == prodId).SingleOrDefault();

        //    return View(Auth2);
        //}
    }
}
