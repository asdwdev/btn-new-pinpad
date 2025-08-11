using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;

namespace BtnNewPinpad.Controllers;

public class PinpadController : Controller
{
    private readonly ILogger< PinpadController> _logger;

    public  PinpadController(ILogger< PinpadController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
