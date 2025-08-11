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

    public async Task<IActionResult> Index()
    {
        var data = await _context.Pinpads
            .OrderBy(p => p.ParentBranch)
            .ToListAsync();

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
