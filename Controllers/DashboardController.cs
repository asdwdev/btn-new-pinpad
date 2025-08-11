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

        // public async Task<IActionResult> Monitoring()
        // {
        //     var data = await _context.Pinpads
        //         .OrderBy(p => p.ParentBranch)
        //         .ToListAsync();

        //     return View(data);
        // }

        public async Task<IActionResult> Monitoring(string searchString)
        {
            var pinpads = from p in _context.Pinpads
                        select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                pinpads = pinpads.Where(p =>
                    p.ParentBranch.Contains(searchString) ||
                    p.OutletCode.Contains(searchString) ||
                    p.Location.Contains(searchString) ||
                    p.SerialNumber.Contains(searchString) ||
                    p.TerminalId.Contains(searchString) ||
                    p.PinpadStatus.Contains(searchString) ||
                    p.CreatedBy.Contains(searchString) ||
                    p.IpLow.Contains(searchString) ||
                    p.IpHigh.Contains(searchString)
                );
            }

            var data = await pinpads
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
