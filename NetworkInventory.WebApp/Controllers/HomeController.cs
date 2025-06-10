using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetworkInventory.WebApp.Models;

namespace NetworkInventory.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventoryContext _context;

        public HomeController(ILogger<HomeController> logger,InventoryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.DeviceCategories=_context.DeviceCategories.ToList();
            ViewBag.ConnectivityItemTypes=_context.ConnectivityItems
                .Select(ci => ci.ItemType)
                .Distinct()
                .ToList();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
