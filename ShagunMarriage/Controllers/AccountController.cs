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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUserAsync(loginViewModel);
                // Implement login logic here
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
