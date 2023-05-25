using System.Security.Cryptography;
using System.Text;

namespace QueueManager.Application.Extensions
{
    public static class CustomExtensions
    {
        public static string ComputeHash(this string input)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes=Encoding.UTF8.GetBytes(input);
                byte[] hashbytes= hash.ComputeHash(bytes);
                return Convert.ToBase64String(hashbytes);
            }
        }
    }
}
