using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitementManagementApp.Models;
using System.Net.NetworkInformation;

namespace RecruitementManagementApp.Controllers
{
    public class CandidatController : Controller
    {

        private readonly RecruitementDbContext _context;
        public CandidatController(RecruitementDbContext context)
        {
            _context = context;
        }
        // GET: CandidatController
        public ActionResult Index()
        {
            return View();
        }
        //TempData["message"]="Postuled successfully"


        [HttpGet]
        public IActionResult CompeleteProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompeleteProfile(Candidat cd)
        {
            var userId = HttpContext.Session.GetInt32("UserId");


            if (userId.HasValue)
            {

                cd.IdCandidat = userId.Value;

                _context.Candidats.Add(cd);
                _context.SaveChanges();
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    user.profilecompleted = true;
                    _context.SaveChanges();
                }


                // ... the rest of your code ...
            }



            return RedirectToAction("AllOffres", "Offres");
        }


        public async Task<IActionResult> AllOffres()
        {


            var recruitementDbContext = _context.Offres.Include(o => o.LeRh).Where(o=>o.published);

            return View(await recruitementDbContext.ToListAsync());
        }



        public async Task<IActionResult> FilterOffre(string searchString)
        {
            var alloffres = await _context.Offres.Include(o => o.LeRh).Where(o => o.published==true).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = alloffres.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("AllOffres",filteredResult);
            }

            return View("AllOffres",alloffres);
        }


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

        [Route("Candidat/Postuler/{codeOffre}")]

        public async Task<IActionResult> Postuler(int? codeOffre)
        {
            if (codeOffre == null || _context.Offres == null)
            {
                return NotFound();
            }
            var userId = HttpContext.Session.GetInt32("UserId");

            var recruitmentDbContext = _context.Offres.Include(o => o.LeRh).Where(o => o.published==true);

            bool hasAlreadyApplied = _context.candidatOffres
             .Any(co => co.IdCandidat == userId && co.codeOffre == codeOffre);

            if (hasAlreadyApplied)
            {
                TempData["ErrorMessage"] = "You have already applied for this job offer.";
                return RedirectToAction("AllOffres", await recruitmentDbContext.ToListAsync());
            }

            CandidatOffre oc = new CandidatOffre
            {
                IdCandidat = userId.Value ,
                codeOffre = (int)codeOffre,
                Status = ApplicationStatus.EnAttente
            };
            _context.candidatOffres.Add(oc);
            _context.SaveChanges();
           
          //  var recruitmentDbContext = _context.Offres.Include(o => o.LeRh);
            TempData["SuccessMessage"] = "Operation was successful.";


            return View("AllOffres", await recruitmentDbContext.ToListAsync());
        }


        public async Task<IActionResult> Suivremescandidatures( )
        {
            
            var userId = HttpContext.Session.GetInt32("UserId");


            var candidatures = _context.candidatOffres
         .Where(co => co.IdCandidat == userId)
         .Include(co => co.Offre.LeRh);
         

            return View ("Suivremescandidatures", candidatures);

          
        }




        // GET: CandidatController/Details/5


        // GET: CandidatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
