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
    public class UseresController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UseresController(ModelContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }

        // GET: Useres
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Useres.Include(u => u.Role);
            return View(await modelContext.ToListAsync());
        }

        // GET: Useres/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usere = await _context.Useres
                //.Include(u => u.Log)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usere == null)
            {
                return NotFound();
            }

            return View(usere);
        }

        // GET: Useres/Create
        public IActionResult Create()
        {
            //ViewData["LogId"] = new SelectList(_context.Loginandreges, "LogId", "LogId");
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName");

            return View();
        }

        // POST: Useres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Fname,Lname,Phone,Email,Address,Password,RoleId,Image,ImageFile")] Usere usere)
        {
            if (ModelState.IsValid)
            {
                if (usere.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + usere.ImageFile.FileName;
                    string extension = Path.GetExtension(usere.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await usere.ImageFile.CopyToAsync(fileStream);
                    }
                    usere.Image = fileName;
                    _context.Add(usere);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            //ViewData["LogId"] = new SelectList(_context.Loginandreges, "LogId", "LogId", usere.LogId);
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", usere.RoleId);
            return View(usere);
        }

        // GET: Useres/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usere = await _context.Useres.FindAsync(id);
            if (usere == null)
            {
                return NotFound();
            }
            //ViewData["LogId"] = new SelectList(_context.Loginandreges, "LogId", "LogId", usere.LogId);
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", usere.RoleId);
            return View(usere);
        }

        // POST: Useres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ImageFile,UserId,Fname,Lname,Phone,Email,Address,Password,RoleId")] Usere usere)
        {
            if (id != usere.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (usere.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + usere.ImageFile.FileName;
                        string extension = Path.GetExtension(usere.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await usere.ImageFile.CopyToAsync(fileStream);
                        }
                        usere.Image = fileName;
                        _context.Update(usere);
                        await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }
                    else if (usere.Password != null)
                    {
                        _context.Update(usere);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsereExists(usere.UserId))
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
            //ViewData["LogId"] = new SelectList(_context.Loginandreges, "LogId", "LogId", usere.LogId);
            ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", usere.RoleId);
            return View(usere);
        }

        // GET: Useres/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usere = await _context.Useres
                //.Include(u => u.Log)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usere == null)
            {
                return NotFound();
            }

            return View(usere);
        }

        // POST: Useres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var usere = await _context.Useres.FindAsync(id);
            _context.Useres.Remove(usere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsereExists(decimal id)
        {
            return _context.Useres.Any(e => e.UserId == id);
        }

        public IActionResult Customer()
        {
            //var cust = _context.Useres.Find(x => x.userId == Usere.userId);
            //ViewData["CustomerId"] = new SelectList(_context.Rolees, "RoleId", "RoleName");
            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            string ph = "ph";
            ViewBag.ph = HttpContext.Session.GetInt32(ph);

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);

            return View();
        }

        public IActionResult Admin()
        {

            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            string ph = "ph";
            ViewBag.ph = HttpContext.Session.GetInt32(ph);

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            return View();
        }

        public IActionResult Accountant()
        {

            string id = "id";
            ViewBag.session = HttpContext.Session.GetInt32(id);

            string ph = "ph";
            ViewBag.ph = HttpContext.Session.GetInt32(ph);

            string email = "email";
            ViewBag.email = HttpContext.Session.GetString(email);
            return View();
        }


        public IActionResult Register()
        {



            //return RedirectToAction("login", "Loginandreges");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,Fname,Lname,Phone,Email,Address,Password,Image,ImageFile")] Usere usere)
        {
            if (ModelState.IsValid)
            {
                if (usere.ImageFile != null )
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + usere.ImageFile.FileName;
                    string extension = Path.GetExtension(usere.ImageFile.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await usere.ImageFile.CopyToAsync(fileStream);
                    }
                    usere.Image = fileName;
                    _context.Add(usere);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("customer", "homepagees");
                }
                else if(usere.Email != null)
                {

                    _context.Add(usere);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("customer", "homepagees");
                }
            }

            //ViewData["RoleId"] = new SelectList(_context.Rolees, "RoleId", "RoleName", usere.RoleId);
            return View("register");
        }

        public async Task<IActionResult> acc()
        {
            var modelContext = _context.Useres.Include(u => u.Role);
            return View(await modelContext.ToListAsync());
        }
    }
}
