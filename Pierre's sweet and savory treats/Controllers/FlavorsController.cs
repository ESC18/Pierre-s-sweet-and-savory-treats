using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Data;
using PierreTreats.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PierreTreats.Controllers
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

        // ... Other CRUD actions
    }
}
