using System;
using System.Security.Cryptography;
using System.Text;

namespace AppHockeyClub.service
{
    internal static class hash
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytePassword);
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
        }

        public static bool Verify(string inputPassword, string storedHash)
        {
            
            string hashedInput = HashPassword(inputPassword);

            
            return string.Equals(hashedInput, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}