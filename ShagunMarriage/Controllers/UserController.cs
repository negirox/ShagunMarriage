using Microsoft.AspNetCore.Mvc;

namespace ShagunMarriage.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
