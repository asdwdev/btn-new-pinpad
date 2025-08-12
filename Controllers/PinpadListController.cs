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

    public async Task<IActionResult> Index(
        string regional,
        string parentBranch,
        string outlet,
        string serialNumber,
        string createdBy,
        string status
    )
    {
        var query = _context.Pinpads.AsQueryable();

        // Filter berdasarkan masing-masing field
        if (!string.IsNullOrWhiteSpace(regional))
            query = query.Where(p => p.Region == regional);

        if (!string.IsNullOrWhiteSpace(parentBranch))
            query = query.Where(p => p.ParentBranch == parentBranch);

        if (!string.IsNullOrWhiteSpace(outlet))
            query = query.Where(p => p.OutletCode == outlet);

        if (!string.IsNullOrWhiteSpace(serialNumber))
            query = query.Where(p => p.SerialNumber.Contains(serialNumber));

        if (!string.IsNullOrWhiteSpace(createdBy))
            query = query.Where(p => p.CreatedBy.Contains(createdBy));

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(p => p.PinpadStatus == status);

        var data = await query
            .OrderBy(p => p.ParentBranch)
            .ToListAsync();

        // Dropdowns
        var regionals = await _context.Pinpads
            .Where(p => !string.IsNullOrEmpty(p.Region))
            .Select(p => p.Region)
            .Distinct()
            .OrderBy(r => r)
            .ToListAsync();

        var parentBranches = await _context.Pinpads
            .Where(p => !string.IsNullOrEmpty(p.ParentBranch))
            .Select(p => p.ParentBranch)
            .Distinct()
            .OrderBy(p => p)
            .ToListAsync();

        var outlets = await _context.Pinpads
            .Where(p => !string.IsNullOrEmpty(p.OutletCode))
            .Select(p => p.OutletCode)
            .Distinct()
            .OrderBy(p => p)
            .ToListAsync();

        var statuses = await _context.Pinpads
            .Where(p => !string.IsNullOrEmpty(p.PinpadStatus))
            .Select(p => p.PinpadStatus)
            .Distinct()
            .OrderBy(p => p)
            .ToListAsync();

        ViewData["Regionals"] = regionals;
        ViewData["ParentBranches"] = parentBranches;
        ViewData["Outlets"] = outlets;
        ViewData["Status"] = statuses;

        // Simpan filter yang dipilih biar formnya tetep keisi
        ViewData["SelectedRegional"] = regional;
        ViewData["SelectedParentBranch"] = parentBranch;
        ViewData["SelectedOutlet"] = outlet;
        ViewData["SelectedSerialNumber"] = serialNumber;
        ViewData["SelectedCreatedBy"] = createdBy;
        ViewData["SelectedStatus"] = status;

        return View(data);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
