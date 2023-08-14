using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pierre_s_sweet_and_savory_treats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TreatsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Treat> treats = _db.Treats.ToList();
            return View(treats);
        }

        public ActionResult Details(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat != null)
            {
                _db.Treats.Remove(treat);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
