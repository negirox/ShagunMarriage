using Microsoft.AspNetCore.Mvc;
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
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userService.AuthenticateUserAsync(loginViewModel);
            if (user != null)
            {
                // Set authentication cookie/session here as needed

                // Store email in session for future use
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", user.Username);
                var userModel = await _userService.GetUserInfo(user);
                if (userModel?.MatrimonialProfile == null)
                {
                    // Redirect to profile completion
                    return RedirectToAction("CompleteProfile", "Home");
                }
                else
                {
                    // Redirect to user home
                    return RedirectToAction("UserHome", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(loginViewModel);
        }


    }
}
