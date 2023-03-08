using System.Security.Cryptography;

namespace FancyNotes.Server.Utilities
{
    public static class HashGenerator
    {
        public static string Generate(string input) {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
