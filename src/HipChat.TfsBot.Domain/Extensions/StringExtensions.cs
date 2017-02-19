using System.Security.Cryptography;
using System.Text;

namespace HipChat.TfsBot.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Sha512(this string str)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = ue.GetBytes(str);

            var hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);

            foreach (byte x in hashValue)
            {
                hex += $"{x:x2}";
            }

            return hex;
        }
    }
}
