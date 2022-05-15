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
    public class OrderesController : Controller
    {
        private readonly ModelContext _context;

        public OrderesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Orderes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Orderes.Include(o => o.Product).Include(o => o.User);
            return View(await modelContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DateTime fDate, DateTime sDate)
        {
            var order = _context.Orderes.Where(x => x.OrdersDate > fDate && x.OrdersDate < sDate).ToList();
            return View(order);
        }

        // GET: Orderes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordere = await _context.Orderes
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordere == null)
            {
                return NotFound();
            }

            return View(ordere);
        }

        // GET: Orderes/Create
        public IActionResult Create()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);


            ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId");
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            return View();
        }

        // POST: Orderes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,Quantity,ProductId,Sale,OrdersDate")] Ordere ordere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId", ordere.ProductId);
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", ordere.UserId);
            return View(ordere);
        }

        // GET: Orderes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordere = await _context.Orderes.FindAsync(id);
            if (ordere == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId", ordere.ProductId);
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", ordere.UserId);
            return View(ordere);
        }

        // POST: Orderes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderId,UserId,Quantity,ProductId,Sale,OrdersDate")] Ordere ordere)
        {
            if (id != ordere.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdereExists(ordere.OrderId))
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
            ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId", ordere.ProductId);
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", ordere.UserId);
            return View(ordere);
        }

        // GET: Orderes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordere = await _context.Orderes
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordere == null)
            {
                return NotFound();
            }

            return View(ordere);
        }

        // POST: Orderes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var ordere = await _context.Orderes.FindAsync(id);
            _context.Orderes.Remove(ordere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdereExists(decimal id)
        {
            return _context.Orderes.Any(e => e.OrderId == id);
        }


        //public IActionResult BuyNow()
        //{
        //    string id = "id";
        //    ViewBag.session = HttpContext.Session.GetInt32(id);

        //    ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId");
        //    ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");


        //    return View();


        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult BuyNow(int prodId)
        {
            //string id = "id";
            //ViewBag.session = HttpContext.Session.GetInt32(id);
            //ViewData["ProductId"] = new SelectList(_context.Productes, "ProductId", "ProductId");
            //ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            var prod = _context.Productes.Where(x => x.ProductId == prodId).ToList();
            //var prod2 = _context.Productes.FirstOrDefault(p => p.ProductId == prodId);
            //var prod = _context.Productes.Where(x => x.ProductId == prodId).SingleOrDefault();

            //const string prId = "prId";
            //HttpContext.Session.SetInt32(prId, (int)prod.ProductId);

            //ViewBag.prId = HttpContext.Session.GetInt32(prId);

            return View(prod);
            //return RedirectToAction("BuyNow");

        }

        public async Task<IActionResult> Acc()
        {
            var modelContext = _context.Orderes.Include(o => o.Product).Include(o => o.User);
            return View(await modelContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Acc(DateTime fDate, DateTime sDate)
        {
            var order = _context.Orderes.Where(x => x.OrdersDate > fDate && x.OrdersDate < sDate).ToList();
            return View(order);
        }


    }
}
