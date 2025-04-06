using System.Security.Cryptography;
using System.Text;

namespace TrelloApiTests
{
    public class StringIntGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string GenerateString(int length)
        {
            var result = new StringBuilder(length);
            using (var rng = RandomNumberGenerator.Create())
            {
                var buffer = new byte[sizeof(uint)];
                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(buffer);
                    uint num = BitConverter.ToUInt32(buffer, 0);
                    result.Append(Chars[(int)(num % (uint)Chars.Length)]);
                }
            }
            return result.ToString();
        }
    }
}
