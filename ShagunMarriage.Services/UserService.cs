using AutoMapper;
using CommonUtilsNet.Utils;
using ShagunMarriage.Models.DBModels;
using ShagunMarriage.Models.ViewModels;
using ShagunMarriage.Repository;

namespace ShagunMarriage.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterUserAsync(UserViewModel user)
        {
            var passwordHash = user.PasswordHash.HashPassword();
            var userModel = _mapper.Map<UserModel>(user);
            await _userRepository.AddUserAsync(userModel);
        }

        public async Task<UserViewModel?> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return _mapper.Map<UserViewModel>(user);
            }
            return null;
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            var hash = password.HashPassword();
            return hash == passwordHash;
        }

        public async Task<UserViewModel?> GetUserInfo(UserViewModel userViewModel)
        {
            userViewModel.PasswordHash = userViewModel.PasswordHash.HashPassword();
            var user = _mapper.Map<UserModel>(userViewModel);
            var userModel = await _userRepository.GetUserInfo(user);
            if (userModel != null)
            {
                return _mapper.Map<UserViewModel>(userModel);
            }
            return null;
        }
    }
}
