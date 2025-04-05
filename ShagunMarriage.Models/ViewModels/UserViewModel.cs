using System.ComponentModel.DataAnnotations;

namespace ShagunMarriage.Models.ViewModels
{
    public class UserViewModel : LoginViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

    }
}
