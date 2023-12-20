using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using RecruitementManagementApp.Models;

namespace RecruitementManagementApp.Controllers
{
    public class OffresController : Controller
    {
        private readonly RecruitementDbContext _context;

        public OffresController(RecruitementDbContext context)
        {
            _context = context;
        }



        


        // GET: Offres
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var recruitementDbContext = _context.Offres.Where(o => o.nameRh == userId.Value);
          
            return View(await recruitementDbContext.ToListAsync());
        }

        // GET: Offres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Offres == null)
            {
                return NotFound();
            }

            var offre = await _context.Offres
                .Include(o => o.LeRh)
                .FirstOrDefaultAsync(m => m.codeOffre == id);
            if (offre == null)
            {
                return NotFound();
            }

            return View(offre);
        }

        // GET: Offres/Create
        public IActionResult Create()
        {
            ViewData["nameRh"] = new SelectList(_context.RHs, "IdRh", "Name");
            return View();
        }

        // POST: Offres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codeOffre,Title,Description,published,archived,nameRh")] Offre offre)
        {
            /*if (ModelState.IsValid)
            {
               
            }*/
            var userId = HttpContext.Session.GetInt32("UserId");

            ViewData["nameRh"] = new SelectList(_context.RHs, "IdRh", "Name", offre.nameRh);
            try
            { 
                offre.nameRh = userId.Value;
                _context.Add(offre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(offre);
            }
        }

        // GET: Offres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Offres == null)
            {
                return NotFound();
            }

            var offre = await _context.Offres.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }
            ViewData["nameRh"] = new SelectList(_context.RHs, "IdRh", "Name", offre.nameRh);
            return View(offre);
        }

        // POST: Offres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codeOffre,Title,Description,published,archived,nameRh")] Offre offre)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (id != offre.codeOffre)
            {
                return NotFound();
            }

            
                try
                { offre.nameRh=userId.Value;
                    _context.Update(offre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OffreExists(offre.codeOffre))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["nameRh"] = new SelectList(_context.RHs, "IdRh", "Name", offre.nameRh);
            return View(offre);
        }

        // GET: Offres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Offres == null)
            {
                return NotFound();
            }

            var offre = await _context.Offres
                .Include(o => o.LeRh)
                .FirstOrDefaultAsync(m => m.codeOffre == id);
            if (offre == null)
            {
                return NotFound();
            }

            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Offres == null)
            {
                return Problem("Entity set 'RecruitementDbContext.Offres'  is null.");
            }
            var offre = await _context.Offres.FindAsync(id);
            if (offre != null)
            {
                _context.Offres.Remove(offre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OffreExists(int id)
        {
          return (_context.Offres?.Any(e => e.codeOffre == id)).GetValueOrDefault();
        }
    }
}
