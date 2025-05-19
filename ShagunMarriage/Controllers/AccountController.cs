using Microsoft.AspNetCore.Mvc;
using ShagunMarriage.Models;
using ShagunMarriage.Models.ViewModels;
using ShagunMarriage.Services;

namespace ShagunMarriage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _userService.RegisterUserAsync(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                UserViewModel userViewModel = new()
                {
                    Username = username,
                    PasswordHash = password,
                    Email = "placeholder@example.com" // Provide a default or placeholder value for Email
                };
                var user = await _userService.GetUserInfo(userViewModel);
                // Implement login logic here
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
