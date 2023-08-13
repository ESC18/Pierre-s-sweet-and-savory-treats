using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Data;
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

        public IActionResult Index()
        {
            List<Treat> treats = _db.Treats.ToList();
            return View(treats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Treat treat)
        {
            if (ModelState.IsValid)
            {
                _db.Treats.Add(treat);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treat);
        }

        public IActionResult Details(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        public IActionResult Edit(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Treat treat)
        {
            if (id != treat.TreatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(treat).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treat);
        }

        public IActionResult Delete(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            return View(treat);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Treat treat = _db.Treats.FirstOrDefault(t => t.TreatId == id);
            if (treat == null)
            {
                return NotFound();
            }
            _db.Treats.Remove(treat);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
