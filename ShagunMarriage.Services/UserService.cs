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
            var userModel = _mapper.Map<UserModel>(user);
            var passwordHash = user.PasswordHash.HashPassword();
            userModel.PasswordHash = passwordHash;
            await _userRepository.AddUserAsync(userModel);
        }

        public async Task<UserViewModel?> AuthenticateUserAsync(LoginViewModel loginViewModel)
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginViewModel.Username);
            if (user != null && VerifyPassword(loginViewModel.PasswordHash, user.PasswordHash))
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

        public async Task<MatrimonialUserViewModel?> GetUserProfileInfo(string email)
        {
            var userModel = await _userRepository.GetUserProfileInfo(email);
            if (userModel != null)
            {
                return _mapper.Map<MatrimonialUserViewModel>(userModel);
            }
            return null;
        }

        public async Task<bool> AddOrUpdate(MatrimonialUserViewModel userProfile,string email)
        {
            var matrimonialUserModel = _mapper.Map<MatrimonialUserModel>(userProfile);
            var userInfo = await _userRepository.GetUserByEmailAsync(email);
            if (userInfo == null)
            {
                return false;
            }
            matrimonialUserModel.UserId = userInfo.Id;
            matrimonialUserModel.User = userInfo;
            await _userRepository.AddOrUpdate(matrimonialUserModel,email);
            return true;
        }
    }
}
