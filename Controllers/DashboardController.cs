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

        // public async Task<IActionResult> Monitoring(string searchString)
        // {
        //     var pinpads = from p in _context.Pinpads
        //                 select p;

        //     if (!string.IsNullOrEmpty(searchString))
        //     {
        //         pinpads = pinpads.Where(p =>
        //             p.ParentBranch.Contains(searchString) ||
        //             p.OutletCode.Contains(searchString) ||
        //             p.Location.Contains(searchString) ||
        //             p.SerialNumber.Contains(searchString) ||
        //             p.TerminalId.Contains(searchString) ||
        //             p.PinpadStatus.Contains(searchString) ||
        //             p.CreatedBy.Contains(searchString) ||
        //             p.IpLow.Contains(searchString) ||
        //             p.IpHigh.Contains(searchString)
        //         );
        //     }

        //     var data = await pinpads
        //         .OrderBy(p => p.ParentBranch)
        //         .ToListAsync();

        //     return View(data);
        // }

        public async Task<IActionResult> Monitoring(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Pinpads.AsQueryable();

            // Search
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p =>
                    p.ParentBranch.Contains(searchString) ||
                    p.OutletCode.Contains(searchString) ||
                    p.Location.Contains(searchString) ||
                    p.SerialNumber.Contains(searchString) ||
                    p.TerminalId.Contains(searchString));
            }

            // Total data untuk pagination
            int totalItems = await query.CountAsync();

            // Pagination
            var data = await query
                .OrderBy(p => p.ParentBranch)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Kirim data ke View
            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.SearchString = searchString;

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
