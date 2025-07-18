using DE_Store_Backend.Models;
using System.Security.Cryptography;
using System.Text;

namespace DE_Store_Backend.Services;

public class PasswordHasher
{
    private readonly string salt = "H6JdzeZPYOQp4QCM";
    public string HashPassword(string password, string username)
    {
        string saltedPassword = $"{username}{password}{salt}";

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }
    }

    public bool varifyPassword (User user, string enteredPassword)
    {
        string enteredPasswordHashed = HashPassword(user.Username, user.PasswordHash);

        return enteredPasswordHashed == enteredPassword;
    }
}
