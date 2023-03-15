using System.Security.Cryptography;
using System.Text;

namespace Vinodrill_Back.Models.Auth
{
    public class Hash
    {
        public static string[] HashPassword(string password)
        {
            byte[] saltBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];
            passwordBytes.CopyTo(saltedPasswordBytes, 0);
            saltBytes.CopyTo(saltedPasswordBytes, passwordBytes.Length);

            byte[] hashBytes;
            using (var sha256 = new SHA256Managed())
            {
                hashBytes = sha256.ComputeHash(saltedPasswordBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);
            string hash = Convert.ToBase64String(hashBytes);

            return new string[] { salt, hash };
        }


        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            byte[] hashBytes;

            using (var sha256 = new HMACSHA256(saltBytes))
            {
                hashBytes = sha256.ComputeHash(passwordBytes);
            }

            string enteredHash = Convert.ToBase64String(hashBytes);

            return enteredHash == storedHash;
        }

    }
}
