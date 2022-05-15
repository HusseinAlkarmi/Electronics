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
    public class PaymentesController : Controller
    {
        private readonly ModelContext _context;

        public PaymentesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Paymentes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Paymentes.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Paymentes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymente = await _context.Paymentes
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PayemntId == id);
            if (paymente == null)
            {
                return NotFound();
            }

            return View(paymente);
        }

        // GET: Paymentes/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            return View();
        }

        // POST: Paymentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayemntId,Cardname,Cardnum,Toalamount,Cardexp,UserId")] Paymente paymente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", paymente.UserId);
            return View(paymente);
        }

        // GET: Paymentes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymente = await _context.Paymentes.FindAsync(id);
            if (paymente == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", paymente.UserId);
            return View(paymente);
        }

        // POST: Paymentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("PayemntId,Cardname,Cardnum,Toalamount,Cardexp,UserId")] Paymente paymente)
        {
            if (id != paymente.PayemntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymenteExists(paymente.PayemntId))
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
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId", paymente.UserId);
            return View(paymente);
        }

        // GET: Paymentes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymente = await _context.Paymentes
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PayemntId == id);
            if (paymente == null)
            {
                return NotFound();
            }

            return View(paymente);
        }

        // POST: Paymentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var paymente = await _context.Paymentes.FindAsync(id);
            _context.Paymentes.Remove(paymente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymenteExists(decimal id)
        {
            return _context.Paymentes.Any(e => e.PayemntId == id);
        }

        public IActionResult Customer()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Customer([Bind("PayemntId,Cardname,Cardnum,Toalamount,Cardexp,UserId")] Paymente paymente)
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            if (ModelState.IsValid)
            {
                if (paymente.Cardname != null)
                {
                    _context.Add(paymente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("customer", "homepagees");
                }
            }
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");

            return View("Customer");
        }

        public IActionResult PayementCard(int id)
        {
            var pay = _context.Paymentes.Where(x => x.UserId == id).ToList();
            return View(pay);
        }

        public async Task<IActionResult> acc()
        {
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);
            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            ViewData["UserId"] = new SelectList(_context.Useres, "UserId", "UserId");
            var modelContext = _context.Paymentes.Include(p => p.User);
            return View(await modelContext.ToListAsync());
        }

    }
}
