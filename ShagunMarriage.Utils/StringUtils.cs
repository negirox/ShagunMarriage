using System.Security.Cryptography;
using System.Text;

namespace ShagunMarriage.Utils
{
    public static class StringUtils
    {
        public static string HashPassword(this string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
