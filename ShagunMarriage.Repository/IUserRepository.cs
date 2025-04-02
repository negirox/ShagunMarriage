using ShagunMarriage.Models.DBModels;

namespace ShagunMarriage.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserModel user);
        Task<UserModel?> GetUserByUsernameAsync(string username);
    }
}
