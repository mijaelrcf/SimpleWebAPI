using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SimpleWebAPI.Encryption
{
    public class RsaEncryption
    {
        #region Properties
        private string SerialNumber { get; set; }
        #endregion

        #region Constructor
        public RsaEncryption()
        {
            SerialNumber = "2dc3d369fbf17c934b7e9424807e1ee8";
        }
        #endregion

        #region Methods
        private X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection collection = my.Certificates.Find(X509FindType.FindBySerialNumber, this.SerialNumber, false);
            if (collection.Count == 1)
            {
                return collection[0];
            }
            else if (collection.Count > 1)
            {
                throw new Exception(string.Format("More than one certificate with name '{0}' found in store LocalMachine/My.", this.SerialNumber));
            }
            else
            {
                throw new Exception(string.Format("Certificate '{0}' not found in store LocalMachine/My.", this.SerialNumber));
            }
        }

        public string EncryptRsa(string content)
        {
            string encryptedContent = string.Empty;            
            
            X509Certificate2 cert = GetCertificate();

            using (var rsa = cert.GetRSAPrivateKey())
            {
                byte[] bytesData = Encoding.UTF8.GetBytes(content);
                byte[] bytesEncrypted = rsa!.Encrypt(bytesData, RSAEncryptionPadding.OaepSHA1);
                encryptedContent = Convert.ToBase64String(bytesEncrypted);
            }

            return encryptedContent;
        }

        public string DecryptRsa(string encrypted)
        {
            string decryptedContent = string.Empty;

            X509Certificate2 cert = GetCertificate();

            using (var rsa = cert.GetRSAPrivateKey())
            {
                byte[] bytesEncrypted = Convert.FromBase64String(encrypted);
                byte[] bytesDecrypted = rsa!.Decrypt(bytesEncrypted, RSAEncryptionPadding.OaepSHA1);
                decryptedContent = Encoding.UTF8.GetString(bytesDecrypted);
            }

            return decryptedContent;
        }
        #endregion
    }
}
