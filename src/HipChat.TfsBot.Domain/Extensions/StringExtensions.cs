using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HipChat.TfsBot.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Sha512(this string str)
        {
            var ue = new UnicodeEncoding();
            byte[] hashValue;
            var message = ue.GetBytes(str);

            var hashString = new SHA512Managed();

            hashValue = hashString.ComputeHash(message);

            return hashValue.Aggregate("", (current, x) => current + $"{x:x2}");
        }
    }
}
