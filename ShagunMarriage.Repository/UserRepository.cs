using Microsoft.EntityFrameworkCore;
using ShagunMarriage.Models.DBModels;

namespace ShagunMarriage.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShagunMarriageDbContext _context;

        public UserRepository(ShagunMarriageDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrUpdate(MatrimonialUserModel userProfile,string email)
        {
            MatrimonialUserModel? existingProfile = await GetUserProfileInfo(email);
            if (existingProfile != null)
            {
                existingProfile.FullName = userProfile.FullName;
                existingProfile.DateOfBirth = userProfile.DateOfBirth;
                existingProfile.State = userProfile.State;
                existingProfile.City = userProfile.City;
                existingProfile.Country = userProfile.Country;
                existingProfile.Occupation = userProfile.Occupation;
                existingProfile.Religion = userProfile.Religion;
                existingProfile.Caste = userProfile.Caste;
                existingProfile.Education = userProfile.Education;
                existingProfile.AnnualIncome = userProfile.AnnualIncome;
                existingProfile.Education = userProfile.Education;
                existingProfile.HeightInCm = userProfile.HeightInCm;
                existingProfile.AboutMe = userProfile.AboutMe;
                existingProfile.PreferredReligion = userProfile.PreferredReligion;
                existingProfile.PreferredCaste = userProfile.PreferredCaste;
                existingProfile.PreferredAgeFrom = userProfile.PreferredAgeFrom;
                existingProfile.PreferredAgeTo = userProfile.PreferredAgeTo;
                existingProfile.PreferredHeightFrom = userProfile.PreferredHeightFrom;
                existingProfile.PreferredHeightTo = userProfile.PreferredHeightTo;
                existingProfile.AdditionalPreferences = userProfile.AdditionalPreferences;
                // Update existing profile
                _context.MatrimonialUsers.Update(existingProfile);

            }
            else
            {
                // Add new profile
                _context.MatrimonialUsers.Add(userProfile);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserModel?> GetUserInfo(UserModel user)
        {
            return await _context.Users.FirstOrDefaultAsync(u => (u.Username == user.Username || u.Email == user.Email)
            && u.PasswordHash == user.PasswordHash);
        }

        public async Task<MatrimonialUserModel?> GetUserProfileInfo(string email)
        {
            return await _context.MatrimonialUsers.FirstOrDefaultAsync(u => u.User.Email == email);
        }
    }
}
