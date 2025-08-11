using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BtnNewPinpad.Models;
using BtnNewPinpad.Data;

namespace BtnNewPinpad.Controllers
{
    public class PinpadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PinpadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pinpad
        public async Task<IActionResult> Index()
        {
            var data = await _context.Pinpads
                .OrderBy(p => p.ParentBranch)
                .ToListAsync();

            return View(data);
        }
    }
}
