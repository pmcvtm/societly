using System;
using System.Configuration;
using System.Security.Cryptography;

namespace Societly.Features.Account
{
    public class EncrypterDecrypterService
    {
        public static HashResult CreateHash(string password)
        {
            var saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);
            return new HashResult
            {
                Salt = salt,
                Hash = ComputeHash(salt, password)
            };
        }

        private static string ComputeHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var pepper = ConfigurationManager.AppSettings["Pepper"];
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password + pepper, saltBytes))
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }

        public static bool Verify(string salt, string hash, string password)
        {
            return hash == ComputeHash(salt, password);
        }

        public class HashResult
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }
    }
}
