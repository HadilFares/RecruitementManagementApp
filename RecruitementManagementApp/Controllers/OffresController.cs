using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using RecruitementManagementApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecruitementManagementApp.Controllers
{
    public class OffresController : Controller
    {
        private readonly RecruitementDbContext _context;

        public OffresController(RecruitementDbContext context)
        {
            _context = context;
        }




        public async Task<IActionResult> FilterOffre(string searchString)
        {
            var alloffres = await _context.Offres.Include(o => o.LeRh).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = alloffres.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", alloffres);
        }


       /* public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var recruitementDbContext = _context.Offres.Where(o => o.nameRh == userId.Value);

            return View(await recruitementDbContext.ToListAsync());
        }*/



        public IActionResult Index(string titre, string type)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            IQueryable list = _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value);
            var lestypes = new List<string> { "Publier", "Archiver" };
            ViewBag.type = new SelectList(lestypes);

            if (titre != null && type != null)
            {
                if (type == "Publier")
                {
                    list = from m in _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value && o.Title.Contains(titre)
                           && o.published == true)
                           select m;

                }
                else
                {
                    list = from m in _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value && o.Title.Contains(titre)
                           && o.archived == true)
                           select m;

                }

            }
            else if (titre == null && type == null)
            {
                list = from m in _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value)
                       select m;
            }

            else if (titre == null)
            {
                if (type == "Publier")
                {
                    list = from m in _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value
                           && o.published == true)
                           select m;

                }
                else
                {
                    list = from m in _context.Offres.Include(o => o.LeRh).Where(o => o.nameRh == userId.Value
                           && o.archived == true)
                           select m;

                }
            }
            else if (type == null)
            {
                list = from m in _context.Offres.Include(o => o.LeRh)
                       where m.nameRh == userId.Value && m.Title.Contains(titre)
                       select m;
            }
            return View(list);
        }



        /*
        public IActionResult SearchBy2(string title, string type )
        {


            var userId = HttpContext.Session.GetInt32("UserId");
            IQueryable list = _context.Offres.Where(o => o.nameRh == userId.Value);





            if (title != null && type != null)
            {

                if (type == "published")
                {
                    /*where m.Title.Contains(titre)
                       && m.Genre.Contains(genre)*/
        /* list = from o in _context.Offres.Where(o => o.nameRh == userId.Value && o.published && o.Title.Contains(title)) 
                select o;
     }
     else if (type == "archived")
     {

         list = from o in _context.Offres.Where(o => o.nameRh == userId.Value && o.archived && o.Title.Contains(title))
                select o;
     }
 }
 else if (title == null && type == null)
 {
     list = from o in _context.Offres.Where(o => o.nameRh == userId.Value)
     select o;
 }
 else if (type == null)
 {
     list = from m in _context.Offres.Where(o => o.nameRh == userId.Value)
     where m.Title.Contains(title)
            select m;
 }


 return View(list);

}

*/
        /*
        public async Task<IActionResult> FilterAchrived(string searchString)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var alloffres = await _context.Offres.Where(o => o.nameRh == userId.Value && o.archived == true).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = alloffres.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", alloffres);
        }


        public async Task<IActionResult> AchivedIndex()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var recruitementDbContext = _context.Offres.Where(o => o.nameRh == userId.Value && o.archived==true);

            return View(await recruitementDbContext.ToListAsync());
        }

        public async Task<IActionResult> FilterPublished(string searchString)

        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var alloffres = await _context.Offres.Where(o => o.nameRh == userId.Value && o.archived == true).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = alloffres.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", alloffres);
        }

        public async Task<IActionResult> PublishedIndex()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var recruitementDbContext = _context.Offres.Where(o => o.nameRh == userId.Value && o.published == true);

            return View(await recruitementDbContext.ToListAsync());
        }


        
        */







        // GET: Offres


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
