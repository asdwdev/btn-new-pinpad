// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using BtnNewPinpad.Models;
// using BtnNewPinpad.Data;
// using Microsoft.EntityFrameworkCore;

// using QuestPDF.Fluent;
// using QuestPDF;
// using QuestPDF.Helpers;
// using QuestPDF.Infrastructure;

// namespace BtnNewPinpad.Controllers
// {
//     public class DashboardController : Controller
//     {
//         private readonly ILogger<DashboardController> _logger;
//         private readonly ApplicationDbContext _context;

//         public DashboardController(ILogger<DashboardController> logger, ApplicationDbContext context)
//         {
//             _logger = logger;
//             _context = context;

//             QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
//         }

//         public IActionResult Index()
//         {
//             return View();
//         }
//         public IActionResult  Panel()
//         {
//             return View();
//         }
        
//         public async Task<IActionResult> PinpadList(string searchString, int pageNumber = 1, int pageSize = 10)
//         {
//             var query = _context.Pinpads.AsQueryable();

//             // Search
//             if (!string.IsNullOrEmpty(searchString))
//             {
//                 query = query.Where(p =>
//                     p.ParentBranch.Contains(searchString) ||
//                     p.OutletCode.Contains(searchString) ||
//                     p.Location.Contains(searchString) ||
//                     p.SerialNumber.Contains(searchString) ||
//                     p.TerminalId.Contains(searchString));
//             }

//             // Total data untuk pagination
//             int totalItems = await query.CountAsync();

//             // Pagination
//             var data = await query
//                 .OrderBy(p => p.ParentBranch)
//                 .Skip((pageNumber - 1) * pageSize)
//                 .Take(pageSize)
//                 .ToListAsync();

//             // Kirim data ke View
//             ViewBag.CurrentPage = pageNumber;
//             ViewBag.PageSize = pageSize;
//             ViewBag.TotalItems = totalItems;
//             ViewBag.SearchString = searchString;

//             return View(data);
//         }

//         public IActionResult Pinpad()
//         {
//             return View();
//         }

//         public async Task<IActionResult> Monitoring(string searchString, int pageNumber = 1, int pageSize = 10)
//         {
//             var query = _context.Pinpads.AsQueryable();

//             // Search
//             if (!string.IsNullOrEmpty(searchString))
//             {
//                 query = query.Where(p =>
//                     p.ParentBranch.Contains(searchString) ||
//                     p.OutletCode.Contains(searchString) ||
//                     p.Location.Contains(searchString) ||
//                     p.SerialNumber.Contains(searchString) ||
//                     p.TerminalId.Contains(searchString));
//             }

//             // Total data untuk pagination
//             int totalItems = await query.CountAsync();

//             // Pagination
//             var data = await query
//                 .OrderBy(p => p.ParentBranch)
//                 .Skip((pageNumber - 1) * pageSize)
//                 .Take(pageSize)
//                 .ToListAsync();

//             // Kirim data ke View
//             ViewBag.CurrentPage = pageNumber;
//             ViewBag.PageSize = pageSize;
//             ViewBag.TotalItems = totalItems;
//             ViewBag.SearchString = searchString;

//             return View(data);
//         }

//         public async Task<IActionResult> ExportPdf(string searchString)
//         {
//             var query = _context.Pinpads.AsQueryable();

//             if (!string.IsNullOrEmpty(searchString))
//             {
//             query = query.Where(p =>
//                 p.ParentBranch.Contains(searchString) ||
//                 p.OutletCode.Contains(searchString) ||
//                 p.Location.Contains(searchString) ||
//                 p.SerialNumber.Contains(searchString) ||
//                 p.TerminalId.Contains(searchString));
//             }

//             var data = await query.OrderBy(p => p.ParentBranch).ToListAsync();

//             var pdfBytes = Document.Create(container =>
//             {
//             container.Page(page =>
//             {
//                 page.Margin(30);
//                 page.Size(PageSizes.A4);
//                 page.Background("#F8F9FA");

//                 page.Header()
//                 .Row(row =>
//                 {
//                     row.RelativeColumn()
//                     .Text("Pinpad Monitoring Report")
//                     .FontSize(22)
//                     .Bold()
//                     .FontColor("#2C3E50")
//                     .AlignCenter();
//                 });

//                 page.Content()
//                 .PaddingVertical(10)
//                 .Table(table =>
//                 {
//                     table.ColumnsDefinition(columns =>
//                     {
//                     columns.RelativeColumn(2); // Cabang Induk
//                     columns.RelativeColumn(2); // Kode Outlet
//                     columns.RelativeColumn(3); // Location
//                     columns.RelativeColumn(3); // Tanggal Register
//                     columns.RelativeColumn(3); // Serial Number
//                     columns.RelativeColumn(2); // TID
//                     columns.RelativeColumn(3); // Status Pinpad
//                     columns.RelativeColumn(2); // Created By
//                     columns.RelativeColumn(2); // IP Low
//                     columns.RelativeColumn(2); // IP High
//                     columns.RelativeColumn(3); // Last Login
//                     });

//                     // Header row
//                     table.Header(header =>
//                     {
//                     string headerBg = "#34495E";
//                     string headerFg = "#FFFFFF";
//                     Action<string> headerCell = text =>
//                         header.Cell().Element(CellStyle).Background(headerBg).Text(text).FontColor(headerFg).Bold().AlignCenter();

//                     headerCell("Cabang Induk");
//                     headerCell("Kode Outlet");
//                     headerCell("Location");
//                     headerCell("Tanggal Register");
//                     headerCell("Serial Number");
//                     headerCell("TID");
//                     headerCell("Status Pinpad");
//                     headerCell("Created By");
//                     headerCell("IP Low");
//                     headerCell("IP High");
//                     headerCell("Last Login");
//                     });

//                     // Data rows
//                     foreach (var item in data)
//                     {
//                     table.Cell().Element(CellStyle).Text(item.ParentBranch).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.OutletCode).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.Location).AlignLeft();
//                     table.Cell().Element(CellStyle).Text(item.RegistrationDate?.ToString("yyyy-MM-dd HH:mm:ss") ?? "").AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.SerialNumber).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.TerminalId).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.PinpadStatus ?? "").AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.CreatedBy).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.IpLow).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.IpHigh).AlignCenter();
//                     table.Cell().Element(CellStyle).Text(item.LastLogin?.ToString("yyyy-MM-dd HH:mm:ss") ?? "").AlignCenter();
//                     }

//                     IContainer CellStyle(IContainer container) => container
//                     .BorderBottom(1)
//                     .BorderColor("#D5D8DC")
//                     .PaddingVertical(4)
//                     .PaddingHorizontal(2)
//                     .ShowOnce();
//                 });

//                 page.Footer()
//                 .AlignCenter()
//                 .Text(x =>
//                 {
//                     x.Span("Generated on: ").FontSize(10).FontColor("#7B7D7D");
//                     x.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm")).FontSize(10).FontColor("#7B7D7D").Bold();
//                 });
//             });
//             }).GeneratePdf();

//             return File(pdfBytes, "application/pdf", "PinpadMonitoringReport.pdf");
//         }

//         private void CellStyle(IContainer container)
//         {
//             throw new NotImplementedException();
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//         }
//     }
// }
