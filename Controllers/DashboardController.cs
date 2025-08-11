using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;
using BtnNewPinpad.Data;
using Microsoft.EntityFrameworkCore;

namespace BtnNewPinpad.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ApplicationDbContext _context;

        public DashboardController(ILogger<DashboardController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Monitoring()
        {
            var data = await _context.Pinpads
                .OrderBy(p => p.ParentBranch)
                .ToListAsync();

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
