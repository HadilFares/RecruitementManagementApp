using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitementManagementApp.Models;

namespace RecruitementManagementApp.Controllers
{
    public class RhController : Controller
    {
        private readonly RecruitementDbContext _context;

        public RhController(RecruitementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CompeleteProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompeleteProfile(Rh rh)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid)
            {
                if (userId.HasValue)
                {
                    rh.IdRh = userId.Value;

                    _context.RHs.Add(rh);
                    _context.SaveChanges();
                    var user = _context.Users.Find(userId);
                    if (user != null)
                    {
                        user.profilecompleted = true;
                        _context.SaveChanges();
                    }



                }



                return RedirectToAction("Index", "Offres");
            }
            return View(rh);
        }


        public async Task<IActionResult> lescandidaturesSelonOffre()
        {
           
            var userId = HttpContext.Session.GetInt32("UserId");
            var candidatures = _context.candidatOffres
            .Where(co => co.Offre.nameRh == userId.Value)
             .Include(co => co.Offre.candidatOffres)
             .ThenInclude(co => co.Candidat)
             .ToList();

            var candidatIds = candidatures.Select(co => co.Candidat.IdCandidat).ToList();
            var users = _context.Users.Where(u => candidatIds.Contains(u.Id)).ToList();

            // Use ViewData to pass the list of users to the view
            ViewData["Users"] = new SelectList(users, "Id", "Name", "LastName", "Numero");
            ViewBag.SelectedUser = users.FirstOrDefault();

            return View("lescandidaturesSelonOffre", candidatures);



        }



     

        //[Route("Rh/Edit/{codeOffre&IdCandidat}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? codeOffre, int? IdCandidat)
        {
            if (codeOffre == null || IdCandidat == null || _context.candidatOffres == null)
            {
                return NotFound();
            }

            var offreCandidate = await _context.candidatOffres.Include(o => o.Candidat)
                .Include(o => o.Offre)
                .FirstOrDefaultAsync(m => m.IdCandidat == IdCandidat && m.codeOffre == codeOffre); ;
            if (offreCandidate == null)
            {
                return NotFound();
            }
            ViewData["IdCandidat"] = new SelectList(_context.Candidats, "Id", "Id", offreCandidate.IdCandidat);
            ViewData["codeOffre"] = new SelectList(_context.Offres, "Id", "Id", offreCandidate.codeOffre);
            return View(offreCandidate);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdCandidat,codeOffre,Status")] CandidatOffre candidateoffre)
        {


            try
            {
                _context.Update(candidateoffre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }
            return RedirectToAction(nameof(lescandidaturesSelonOffre));

            
        }



        public async Task<IActionResult> DetailsProfile()
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || _context.RHs == null)
            {
                return NotFound();
            }

            var recruteur = await _context.RHs
                .FirstOrDefaultAsync(m => m.IdRh == userId);
            if (recruteur == null)
            {
                return NotFound();
            }

            return View(recruteur);
        }



        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || _context.RHs == null)
            {
                return NotFound();
            }

            var rh = await _context.RHs.FindAsync(userId);
            if (rh == null)
            {
                return NotFound();
            }
            return View(rh);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile([Bind("IdRh,Name,adresse,website")] Rh rh)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != rh.IdRh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RhExists(rh.IdRh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DetailsProfile));
            }
            return View(rh);
        }
        private bool RhExists(int id)
        {
            return (_context.RHs?.Any(e => e.IdRh == id)).GetValueOrDefault();
        }
    }
}
