using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;

namespace BtnNewPinpad.Controllers;

public class PinpadListController : Controller
{
    private readonly ILogger<PinpadListController> _logger;

    public PinpadListController(ILogger<PinpadListController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
