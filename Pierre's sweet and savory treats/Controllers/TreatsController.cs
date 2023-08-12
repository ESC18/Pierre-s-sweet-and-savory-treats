using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pierre_s_sweet_and_savory_treats.Data;
using Pierre_s_sweet_and_savory_treats.Models;
using PierreTreats.Data;
using PierreTreats.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pierre_s_sweet_and_savory_treats.Controllers
{
    public class TreatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var treats = await _context.Treats.ToListAsync();
            return View(treats);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Treat treat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treat);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.Treats.FirstOrDefaultAsync(m => m.Id == id);

            if (treat == null)
            {
                return NotFound();
            }

            return View(treat);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.Treats.FindAsync(id);

            if (treat == null)
            {
                return NotFound();
            }

            return View(treat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Treat treat)
        {
            if (id != treat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(treat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treat);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treat = await _context.Treats.FirstOrDefaultAsync(m => m.Id == id);

            if (treat == null)
            {
                return NotFound();
            }

            return View(treat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treat = await _context.Treats.FindAsync(id);
            _context.Treats.Remove(treat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
