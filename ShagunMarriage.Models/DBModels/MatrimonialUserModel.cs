namespace ShagunMarriage.Models.DBModels
{
    public class MatrimonialUserModel
    {
        public int Id { get; set; }

        // Foreign key for UserModel
        public int UserId { get; set; }

        // Navigation property for the one-to-one relationship
        public UserModel User { get; set; }

        public string FullName { get; set; }
        public string Gender { get; set; } // Example: "Male", "Female", "Other"
        public DateTime DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string? Caste { get; set; }
        public string Education { get; set; }
        public string? Occupation { get; set; }
        public decimal AnnualIncome { get; set; }
        public string Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int HeightInCm { get; set; }
        public string? AboutMe { get; set; }

        // Preferences for matchmaking
        public string? PreferredReligion { get; set; }
        public string? PreferredCaste { get; set; }
        public int? PreferredAgeFrom { get; set; }
        public int? PreferredAgeTo { get; set; }
        public int? PreferredHeightFrom { get; set; }
        public int? PreferredHeightTo { get; set; }
        public string? AdditionalPreferences { get; set; }
    }
}
