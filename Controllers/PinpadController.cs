using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;
using BtnNewPinpad.Data;
using Microsoft.EntityFrameworkCore;

namespace BtnNewPinpad.Controllers;

public class PinpadController : Controller
{
    private readonly ILogger< PinpadController> _logger;

    private readonly ApplicationDbContext _context;

    public PinpadController(ILogger<PinpadController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // public async Task<IActionResult> Index()
    // {
    //     var data = await _context.Pinpads
    //         .OrderBy(p => p.ParentBranch)
    //         .ToListAsync();

    //     return View(data);
    // }

    public async Task<IActionResult> Index(string search)
    {
        var query = _context.Pinpads.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            query = query.Where(p =>
                p.ParentBranch.ToLower().Contains(search) ||
                p.SerialNumber.ToString().Contains(search) ||
                p.PinpadStatus.ToLower().Contains(search) ||
                p.Location.ToLower().Contains(search));
        }

        var data = await query
            .OrderBy(p => p.ParentBranch)
            .ToListAsync();

        ViewData["Search"] = search;
        return View(data);
    }

    public IActionResult Edit()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
