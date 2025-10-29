using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari_Otomasyon
{
    /// <summary>
    /// Parolaları düz metin saklamak çok büyük güvenlik açığıdır. PBKDF2 örneğini kullanılmalıdır.
    /// </summary>
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // bytes
        private const int HashSize = 20; // bytes
        private const int Iterations = 10000;

        public static string HashPassword(string password)
        {
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);
                    var hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                    return Convert.ToBase64String(hashBytes);
                }
            }
        }
        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashBytes = Convert.FromBase64String(storedHash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, Iterations))
            {
                var hash = pbkdf2.GetBytes(HashSize);
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i]) return false;
                }
                return true;
            }
        }


    }
}
