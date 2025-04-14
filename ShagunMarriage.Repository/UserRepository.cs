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

        public async Task<UserModel?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<UserModel?> GetUserInfo(UserModel user)
        {
            return await _context.Users.FirstOrDefaultAsync(u => (u.Username == user.Username || u.Email == user.Email)
            && u.PasswordHash == user.PasswordHash);
        }
    }
}
