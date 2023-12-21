using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitementManagementApp.Models;

namespace RecruitementManagementApp.Controllers
{
    public class CandidatOffresController : Controller
    {
        private readonly RecruitementDbContext _context;

        public CandidatOffresController(RecruitementDbContext context)
        {
            _context = context;
        }

        // GET: CandidatOffres
        public async Task<IActionResult> Index()
        {
            var recruitementDbContext = _context.candidatOffres.Include(c => c.Candidat).Include(c => c.Offre);
            return View(await recruitementDbContext.ToListAsync());
        }

        // GET: CandidatOffres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.candidatOffres == null)
            {
                return NotFound();
            }

            var candidatOffre = await _context.candidatOffres
                .Include(c => c.Candidat)
                .Include(c => c.Offre)
                .FirstOrDefaultAsync(m => m.IdCandidat == id);
            if (candidatOffre == null)
            {
                return NotFound();
            }

            return View(candidatOffre);
        }

        // GET: CandidatOffres/Create
        public IActionResult Create()
        {
            ViewData["IdCandidat"] = new SelectList(_context.Candidats, "IdCandidat", "Frameworks");
            ViewData["codeOffre"] = new SelectList(_context.Offres, "codeOffre", "Description");
            return View();
        }

        // POST: CandidatOffres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidat,codeOffre,Status")] CandidatOffre candidatOffre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatOffre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCandidat"] = new SelectList(_context.Candidats, "IdCandidat", "Frameworks", candidatOffre.IdCandidat);
            ViewData["codeOffre"] = new SelectList(_context.Offres, "codeOffre", "Description", candidatOffre.codeOffre);
            return View(candidatOffre);
        }

        // GET: CandidatOffres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.candidatOffres == null)
            {
                return NotFound();
            }

            var candidatOffre = await _context.candidatOffres.FindAsync(id);
            if (candidatOffre == null)
            {
                return NotFound();
            }
            ViewData["IdCandidat"] = new SelectList(_context.Candidats, "IdCandidat", "Frameworks", candidatOffre.IdCandidat);
            ViewData["codeOffre"] = new SelectList(_context.Offres, "codeOffre", "Description", candidatOffre.codeOffre);
            return View(candidatOffre);
        }

        // POST: CandidatOffres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidat,codeOffre,Status")] CandidatOffre candidatOffre)
        {
            if (id != candidatOffre.IdCandidat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatOffre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatOffreExists(candidatOffre.IdCandidat))
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
            ViewData["IdCandidat"] = new SelectList(_context.Candidats, "IdCandidat", "Frameworks", candidatOffre.IdCandidat);
            ViewData["codeOffre"] = new SelectList(_context.Offres, "codeOffre", "Description", candidatOffre.codeOffre);
            return View(candidatOffre);
        }

        // GET: CandidatOffres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.candidatOffres == null)
            {
                return NotFound();
            }

            var candidatOffre = await _context.candidatOffres
                .Include(c => c.Candidat)
                .Include(c => c.Offre)
                .FirstOrDefaultAsync(m => m.IdCandidat == id);
            if (candidatOffre == null)
            {
                return NotFound();
            }

            return View(candidatOffre);
        }

        // POST: CandidatOffres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.candidatOffres == null)
            {
                return Problem("Entity set 'RecruitementDbContext.candidatOffres'  is null.");
            }
            var candidatOffre = await _context.candidatOffres.FindAsync(id);
            if (candidatOffre != null)
            {
                _context.candidatOffres.Remove(candidatOffre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatOffreExists(int id)
        {
          return (_context.candidatOffres?.Any(e => e.IdCandidat == id)).GetValueOrDefault();
        }
    }
}
