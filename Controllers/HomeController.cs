using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BCrypt.Net;
using TodoApp.Models;
using TodoApp.Data;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoDbContext _context;

        public HomeController(TodoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
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

        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public Task<IActionResult> Login([Bind("Id, Username, Password")] User user)
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("Id, Username, Email, Password")] User user)
        {
            // Here you would typically add the user to your database and handle any validation
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            var existUser = _context.Users.FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);

            if (existUser != null)
            {
                ModelState.AddModelError(string.Empty, "Username or Email already exists.");
                return View(user);
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt();

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);

            user.Password = hashedPassword;
            user.Created_At = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // For now, we'll just redirect to the Index page after registration
            return RedirectToAction("Index");
        }
}
}
