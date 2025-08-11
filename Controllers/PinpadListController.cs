using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Models;
using BtnNewPinpad.Data;
using Microsoft.EntityFrameworkCore;

namespace BtnNewPinpad.Controllers;

public class PinpadListController : Controller
{
    private readonly ILogger<PinpadListController> _logger;

    private readonly ApplicationDbContext _context;

    public PinpadListController(ILogger<PinpadListController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(string search)
    {
        var query = _context.Pinpads.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();

            query = query
                .AsEnumerable()
                .Where(p =>
                    (p.Region != null && p.Region.ToLower().Contains(search)) ||
                    (p.ParentBranch != null && p.ParentBranch.ToLower().Contains(search)) ||
                    (p.OutletCode != null && p.OutletCode.ToLower().Contains(search)) ||
                    (p.Location != null && p.Location.ToLower().Contains(search)) ||
                    p.RegistrationDate.ToString("dd-MM-yyyy HH:mm:ss").Contains(search) ||
                    p.UpdateDate.ToString("dd-MM-yyyy HH:mm:ss").Contains(search) ||
                    p.SerialNumber.ToString().Contains(search) ||
                    (p.TerminalId != null && p.TerminalId.ToLower().Contains(search)) ||
                    (p.PinpadStatus != null && p.PinpadStatus.ToLower().Contains(search)) ||
                    (p.CreatedBy != null && p.CreatedBy.ToLower().Contains(search)) ||
                    (p.IpLow != null && p.IpLow.Contains(search)) ||
                    (p.IpHigh != null && p.IpHigh.Contains(search)) ||
                    (p.LastActivity.HasValue &&
                    p.LastActivity.Value.ToString("dd-MM-yyyy HH:mm:ss").ToLower().Contains(search))
                )
                .AsQueryable();
        }

        var data = query
            .OrderBy(p => p.ParentBranch)
            .ToList();

        ViewData["Search"] = search;
        return View(data);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
