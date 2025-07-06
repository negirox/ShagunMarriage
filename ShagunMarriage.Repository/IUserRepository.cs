using ShagunMarriage.Models.DBModels;

namespace ShagunMarriage.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserModel user);
        Task AddOrUpdate(MatrimonialUserModel userProfile,string email);
        Task<UserModel?> GetUserByUsernameAsync(string username);
        Task<UserModel?> GetUserByEmailAsync(string email);
        Task<UserModel?> GetUserInfo(UserModel user);
        Task<MatrimonialUserModel?> GetUserProfileInfo(string email);
    }
}
