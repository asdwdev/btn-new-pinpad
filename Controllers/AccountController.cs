using Microsoft.AspNetCore.Mvc;
using BtnNewPinpad.Data;
using BtnNewPinpad.Models;
using System.Linq;

namespace BtnNewPinpad.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tampilkan form login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Proses login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Simpan session atau cookie (sementara kita pakai session)
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Username atau password salah";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login");
        }
    }
}
