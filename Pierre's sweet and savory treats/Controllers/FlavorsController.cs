using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Data;
using Pierre_s_sweet_and_savory_treats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pierre_s_sweet_and_savory_treats.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FlavorsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Flavor> flavors = _db.Flavors.ToList();
            return View(flavors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Flavor flavor)
        {
            if (ModelState.IsValid)
            {
                _db.Flavors.Add(flavor);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavor);
        }

        public IActionResult Details(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
            if (flavor == null)
            {
                return NotFound();
            }
            return View(flavor);
        }

        public IActionResult Edit(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
            if (flavor == null)
            {
                return NotFound();
            }
            return View(flavor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Flavor flavor)
        {
            if (id != flavor.FlavorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(flavor).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavor);
        }

        public IActionResult Delete(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
            if (flavor == null)
            {
                return NotFound();
            }
            return View(flavor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Flavor flavor = _db.Flavors.FirstOrDefault(f => f.FlavorId == id);
            if (flavor == null)
            {
                return NotFound();
            }
            _db.Flavors.Remove(flavor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
