using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierreTreats.Data;
using PierreTreats.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PierreTreats.Controllers
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

        // ... Other CRUD actions
    }
}
