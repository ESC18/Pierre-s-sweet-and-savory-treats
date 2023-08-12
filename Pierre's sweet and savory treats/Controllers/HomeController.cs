using Microsoft.AspNetCore.Mvc;

namespace Pierre_s_sweet_and_savory_treats.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Display splash page with list of treats and flavors
            return View();
        }
    }
}
