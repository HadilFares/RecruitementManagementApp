using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


            if (userId.HasValue)
            {
                // Create an Rh entity and set its properties
              /* var rh = new Rh
                {
                    // Set other properties as needed
                    IdRh = userId.Value,
                    Name=newdata.Name,
                    adresse=newdata.adresse,
                    website=newdata.website
                    // Set UserId property to the retrieved user ID
                };
               */

                // Add the Rh entity to the context and save changes
                rh.IdRh= userId.Value;
             
                _context.RHs.Add(rh);
                _context.SaveChanges();
                var user = _context.Users.Find(userId);
                if (user != null)
                {
                    user.profilecompleted = true;
                    _context.SaveChanges();
                }


                // ... the rest of your code ...
            }



            return RedirectToAction("Index", "Offres");
        }





        // GET: RhController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RhController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RhController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RhController/Create
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

        // GET: RhController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RhController/Edit/5
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

        // GET: RhController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RhController/Delete/5
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
