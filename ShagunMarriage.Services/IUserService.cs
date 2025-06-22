
using ShagunMarriage.Models.ViewModels;

namespace ShagunMarriage.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserViewModel user);
        Task<UserViewModel?> AuthenticateUserAsync(LoginViewModel loginViewModel);
        Task<UserViewModel?> GetUserInfo(UserViewModel user);
        Task<MatrimonialUserViewModel?> GetUserProfileInfo(string email);
    }
}