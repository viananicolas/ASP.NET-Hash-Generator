using System;
using System.Security.Cryptography;

namespace ASP.NET_Hash_Generator.Methods
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            var dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}