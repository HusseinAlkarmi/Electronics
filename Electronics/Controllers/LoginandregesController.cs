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
    public class LoginandregesController : Controller
    {
        private readonly ModelContext _context;

        public LoginandregesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Loginandreges
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Loginandreges.Include(l => l.Role);
            return View(await modelContext.ToListAsync());
        }


       

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string username, string password)
        {
           
            var Auth = _context.Useres.Where(x => x.Email == username && x.Password == password).SingleOrDefault();

            const string id = "id";
            const string ph = "ph";
            const string email = "email";

            if (Auth != null)
            {
                switch (Auth.RoleId)
                {
                    case 1:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetInt32(ph, (int)Auth.Phone);
                            HttpContext.Session.SetString(email, (string)Auth.Email);


                            return RedirectToAction("Customer", "Homepagees");
                           
                        }
                    case 2:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetInt32(ph, (int)Auth.Phone);
                            HttpContext.Session.SetString(email, (string)Auth.Email);
                            return RedirectToAction("Admin", "Useres");
                        }
                    case 3:
                        {
                            HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                            HttpContext.Session.SetInt32(ph, (int)Auth.Phone);
                            HttpContext.Session.SetString(email, (string)Auth.Email);

                            return RedirectToAction("Accountant", "Useres");
                        }
                    case null:

                        HttpContext.Session.SetInt32(id, (int)Auth.UserId);
                        HttpContext.Session.SetInt32(ph, (int)Auth.Phone);
                        HttpContext.Session.SetString(email, (string)Auth.Email);

                        return RedirectToAction("Customer", "Homepagees");

                }
            }else
            {
                return RedirectToAction("Index", "Home");
            }
            //ViewBag.role = Auth.RoleId;
            return View();
        }


    
    

    // GET: Loginandreges/Details/5
    public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginandrege = await _context.Loginandreges
                .Include(l => l.Role)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (loginandrege == null)
            {
                return NotFound();
            }

            return View(loginandrege);
        }

        // GET: Loginandreges/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName");
            return View();
        }

        // POST: Loginandreges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,Fname,Lname,Username,Password,RoleId")] Loginandrege loginandrege)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginandrege);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", loginandrege.RoleId);
            return View(loginandrege);
        }

        // GET: Loginandreges/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginandrege = await _context.Loginandreges.FindAsync(id);
            if (loginandrege == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", loginandrege.RoleId);
            return View(loginandrege);
        }

        // POST: Loginandreges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("LogId,Fname,Lname,Username,Password,RoleId")] Loginandrege loginandrege)
        {
            if (id != loginandrege.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginandrege);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginandregeExists(loginandrege.LogId))
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
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", loginandrege.RoleId);
            return View(loginandrege);
        }

        // GET: Loginandreges/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginandrege = await _context.Loginandreges
                .Include(l => l.Role)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (loginandrege == null)
            {
                return NotFound();
            }

            return View(loginandrege);
        }

        // POST: Loginandreges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var loginandrege = await _context.Loginandreges.FindAsync(id);
            _context.Loginandreges.Remove(loginandrege);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginandregeExists(decimal id)
        {
            return _context.Loginandreges.Any(e => e.LogId == id);
        }
    }
}
