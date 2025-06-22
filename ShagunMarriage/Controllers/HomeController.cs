using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShagunMarriage.Models;
using ShagunMarriage.Services;

namespace ShagunMarriage.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IUserService userService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUserService _userService= userService;

        public IActionResult CompleteProfile()
        {
            RetrieveUserEmail(out string? userEmail);// Optionally, you can fetch user profile data and pass it to the view
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult UserHome()
        {
            RetrieveUserEmail(out string? userEmail);// Optionally, you can fetch user profile data and pass it to the view
            if (string.IsNullOrEmpty(userEmail))
            { 
                return RedirectToAction("Login", "Account");
            }
            // For example, if you have a service to get user profile data:
            var userProfile = _userService.GetUserProfileInfo(userEmail);
            return View(userProfile);
        }

        private void RetrieveUserEmail(out string? userEmail)
        {
            // Retrieve user email from session
            userEmail = HttpContext.Session.GetString("UserEmail");
            // You can use the userEmail to fetch user-specific data if needed
            ViewBag.UserEmail = userEmail; // Pass the email to the view if needed
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
    }
}
