using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Data;
using PierreTreats.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Data;
using Pierre_s_sweet_and_savory_treats.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pierre_s_sweet_and_savory_treats.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlavorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flavors = await _context.Flavors.ToListAsync();
            return View(flavors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Flavor flavor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flavor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavor);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors.FirstOrDefaultAsync(m => m.Id == id);

            if (flavor == null)
            {
                return NotFound();
            }

            return View(flavor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors.FindAsync(id);

            if (flavor == null)
            {
                return NotFound();
            }

            return View(flavor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Flavor flavor)
        {
            if (id != flavor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(flavor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flavor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flavor = await _context.Flavors.FirstOrDefaultAsync(m => m.Id == id);

            if (flavor == null)
            {
                return NotFound();
            }

            return View(flavor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flavor = await _context.Flavors.FindAsync(id);
            _context.Flavors.Remove(flavor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
