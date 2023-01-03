using System.Security.Cryptography;

namespace Infrastucture.Helpers
{
    public static class PasswordEncryption
    {
        public static (string, string) SaltAndHashPassword(string password)
        {
            string salt = Convert.ToBase64String(GenerateSalt());

            string passwordWithSalt = password + salt;
            byte[] hash = SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordWithSalt));
            string hashedPassword = Convert.ToBase64String(hash);
            return (hashedPassword, salt);
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}