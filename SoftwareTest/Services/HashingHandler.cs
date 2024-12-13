using System.Security.Cryptography;
using BCrypt.Net;
using SoftwareTest.Services;
using System.Text;

namespace SoftwareTest.Services
{
    public interface IHashingHandler
    {
        dynamic SHAHashing(dynamic valueToHash);
        dynamic HMACHashing(dynamic valueToHash);
        dynamic PBKDF2Hashing(dynamic valueToHash);
        string BCryptHashing(string textToHash);
        bool BCryptVerifyHashing(string textToHash, string hashedValue);
    }

    public class HashingHandler : IHashingHandler
    {
        // SHA
        public dynamic SHAHashing(dynamic valueToHash) =>
            valueToHash is byte[]
                ? SHA256.Create().ComputeHash(valueToHash)
                : Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(valueToHash)));

        // HMAC
        public dynamic HMACHashing(dynamic valueToHash) =>
            valueToHash is byte[]
                ? new HMACSHA256(Encoding.ASCII.GetBytes("YourSecretKey")).ComputeHash(valueToHash)
                : Convert.ToBase64String(new HMACSHA256(Encoding.ASCII.GetBytes("YourSecretKey")).ComputeHash(Encoding.UTF8.GetBytes(valueToHash)));

        // PBKDF2
        public dynamic PBKDF2Hashing(dynamic valueToHash) =>
            valueToHash is byte[]
                ? Rfc2898DeriveBytes.Pbkdf2(valueToHash, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256, 32)
                : Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(valueToHash, Encoding.UTF8.GetBytes("SaltValue"), 10000, HashAlgorithmName.SHA256, 32));

        // BCrypt
        public string BCryptHashing(string textToHash) =>
            BCrypt.Net.BCrypt.HashPassword(textToHash);

        public bool BCryptVerifyHashing(string textToHash, string hashedValue) =>
            BCrypt.Net.BCrypt.Verify(textToHash, hashedValue);
    }
}
