using System.Security.Cryptography;
using System.Text;

namespace TokenPlusMongo.Models;

public static class PasswordHasher
{
    public static string GetHash(string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;

        }
    }
}
