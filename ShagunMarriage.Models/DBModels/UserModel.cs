namespace ShagunMarriage.Models.DBModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
