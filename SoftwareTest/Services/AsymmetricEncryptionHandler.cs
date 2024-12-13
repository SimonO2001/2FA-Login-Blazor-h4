using System.Security.Cryptography;
using System.Text;

namespace SoftwareTest.Services
{
    public class AsymmetricEncryptionHandler
    {
        private readonly RSA _rsa;

        public string PublicKey { get; private set; }
        private string PrivateKey { get; set; }

        public AsymmetricEncryptionHandler()
        {
            _rsa = RSA.Create();

            // Generer nøgler
            PrivateKey = Convert.ToBase64String(_rsa.ExportRSAPrivateKey());
            PublicKey = Convert.ToBase64String(_rsa.ExportRSAPublicKey());
        }

        public string Encrypt(string plainText)
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(PublicKey), out _);

            var data = Encoding.UTF8.GetBytes(plainText);
            var encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

            return Convert.ToBase64String(encryptedData);
        }

        public string Decrypt(string cipherText)
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(PrivateKey), out _);

            var data = Convert.FromBase64String(cipherText);
            var decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
