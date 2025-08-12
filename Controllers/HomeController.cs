using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;
using BtnNewPinpad.Data;
using Microsoft.EntityFrameworkCore;

namespace BtnNewPinpad.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Total semua device
        var totalDevice = await _context.Pinpads.CountAsync();

        // Per kategori status
        var notReady = await _context.Pinpads.CountAsync(p => p.PinpadStatus == "Not Ready To Use");
        var ready = await _context.Pinpads.CountAsync(p => p.PinpadStatus == "Ready To Use");
        var active = await _context.Pinpads.CountAsync(p => p.PinpadStatus == "Active");
        var inactive = await _context.Pinpads.CountAsync(p => p.PinpadStatus == "Inactive");
        var maintenance = await _context.Pinpads.CountAsync(p => p.PinpadStatus == "Maintenance");

        // Kirim ke View lewat ViewData
        ViewData["TotalDevice"] = totalDevice;
        ViewData["NotReady"] = notReady;
        ViewData["Ready"] = ready;
        ViewData["Active"] = active;
        ViewData["Inactive"] = inactive;
        ViewData["Maintenance"] = maintenance;

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
