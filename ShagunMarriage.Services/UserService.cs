using AutoMapper;
using ShagunMarriage.Models;
using ShagunMarriage.Models.DBModels;
using ShagunMarriage.Models.ViewModels;
using ShagunMarriage.Repository;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            var passwordHash = HashPassword(user.PasswordHash);
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

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            var hash = HashPassword(password);
            return hash == passwordHash;
        }
    }
}
