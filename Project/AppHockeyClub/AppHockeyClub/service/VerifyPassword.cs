using System;
using System.Security.Cryptography;
using System.Text;

namespace AppHockeyClub.service
{
    internal static class VerifyPassword
    {
        
        public static bool Verify(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrEmpty(enteredPassword) || string.IsNullOrEmpty(storedHash))
                return false;

           
            try
            {
                
                var hashBytes = Convert.FromBase64String(storedHash);

                
                var salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                
                var vp = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
                byte[] hash = vp.GetBytes(32); 

                
                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                
                return false;
            }
        }

        
        
    }
}