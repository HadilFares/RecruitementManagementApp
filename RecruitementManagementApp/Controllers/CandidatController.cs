using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitementManagementApp.Models;

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


            var recruitementDbContext = _context.Offres.Include(o => o.LeRh);

            return View(await recruitementDbContext.ToListAsync());
        }



        public async Task<IActionResult> FilterOffre(string searchString)
        {
            var alloffres = await _context.Offres.Include(o => o.LeRh).ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = alloffres.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("AllOffres",filteredResult);
            }

            return View("AllOffres",alloffres);
        }












        // GET: CandidatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
