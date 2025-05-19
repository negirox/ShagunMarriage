
using ShagunMarriage.Models.ViewModels;

namespace ShagunMarriage.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserViewModel user);
        Task<UserViewModel?> AuthenticateUserAsync(string username,string password);

        Task<UserViewModel?> GetUserInfo(UserViewModel user);
    }
}