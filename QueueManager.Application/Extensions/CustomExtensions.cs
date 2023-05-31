using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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

        public static bool OnlyLetters( this string arg)
        {

            foreach (char item in arg)
            {
                if (!char.IsLetter(item))
                    return false;
            }
            return true;
        }

        public static bool IsValidPhoneNumber(this string arg )
        {
            Regex regex = new Regex(@"^998\d{9}$");
            return regex.IsMatch(arg);
        }
    }
}
