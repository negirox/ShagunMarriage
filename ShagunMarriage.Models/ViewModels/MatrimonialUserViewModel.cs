using System;
using System.ComponentModel.DataAnnotations;

namespace ShagunMarriage.Models.ViewModels
{
    public class MatrimonialUserViewModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } // Example: "Male", "Female", "Other"

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Religion is required")]
        [StringLength(50, ErrorMessage = "Religion cannot be longer than 50 characters")]
        public string Religion { get; set; }

        [StringLength(50, ErrorMessage = "Caste cannot be longer than 50 characters")]
        public string? Caste { get; set; }

        [Required(ErrorMessage = "Education is required")]
        [StringLength(100, ErrorMessage = "Education cannot be longer than 100 characters")]
        public string Education { get; set; }

        [StringLength(100, ErrorMessage = "Occupation cannot be longer than 100 characters")]
        public string? Occupation { get; set; }

        [Required(ErrorMessage = "Annual Income is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Annual Income must be a positive number")]
        public decimal AnnualIncome { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        public string Country { get; set; }

        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string? State { get; set; }

        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Range(50, 250, ErrorMessage = "Height must be between 50 cm and 250 cm")]
        public int HeightInCm { get; set; }

        [StringLength(500, ErrorMessage = "About Me cannot be longer than 500 characters")]
        public string? AboutMe { get; set; }

        // Preferences for matchmaking
        [StringLength(50, ErrorMessage = "Preferred Religion cannot be longer than 50 characters")]
        public string? PreferredReligion { get; set; }

        [StringLength(50, ErrorMessage = "Preferred Caste cannot be longer than 50 characters")]
        public string? PreferredCaste { get; set; }

        [Range(18, 100, ErrorMessage = "Preferred Age must be between 18 and 100")]
        public int? PreferredAgeFrom { get; set; }

        [Range(18, 100, ErrorMessage = "Preferred Age must be between 18 and 100")]
        public int? PreferredAgeTo { get; set; }

        [Range(50, 250, ErrorMessage = "Preferred Height must be between 50 cm and 250 cm")]
        public int? PreferredHeightFrom { get; set; }

        [Range(50, 250, ErrorMessage = "Preferred Height must be between 50 cm and 250 cm")]
        public int? PreferredHeightTo { get; set; }

        [StringLength(500, ErrorMessage = "Additional Preferences cannot be longer than 500 characters")]
        public string? AdditionalPreferences { get; set; }
    }
}
