using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShagunMarriage.Models;
using ShagunMarriage.Models.ViewModels;
using ShagunMarriage.Services;

namespace ShagunMarriage.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IUserService userService) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUserService _userService= userService;

        [HttpGet]
        public IActionResult CompleteProfile()
        {
            RetrieveUserEmail(out string? userEmail, out string? userName);// Optionally, you can fetch user profile data and pass it to the view
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CompleteProfileAsync(MatrimonialUserViewModel matrimonialUserViewModel) {
            RetrieveUserEmail(out string? userEmail, out string? userName);// Optionally, you can fetch user profile data and pass it to the view
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                bool isAdded = await _userService.AddOrUpdate(matrimonialUserViewModel, userEmail);
                if(isAdded)
                  return RedirectToAction("UserHome", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving user profile for {Email}", userEmail);
                ModelState.AddModelError("", $"An error occurred while saving your profile: {ex.Message}");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserHomeAsync()
        {
            RetrieveUserEmail(out string? userEmail, out string? userName);// Optionally, you can fetch user profile data and pass it to the view
            if (string.IsNullOrEmpty(userEmail))
            { 
                return RedirectToAction("Login", "Account");
            }
            // For example, if you have a service to get user profile data:
            var userProfile = await _userService.GetUserProfileInfo(userEmail);
            return View(userProfile);
        }

        private void RetrieveUserEmail(out string? userEmail,out string? userName)
        {
            // Retrieve user email from session
            userEmail = HttpContext.Session.GetString("UserEmail");
            userName = HttpContext.Session.GetString("UserName");
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
