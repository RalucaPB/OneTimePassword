using OneTimePasswordConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePasswordConsoleApp.Services
{
    public class CryptographyService : ICryptographyService
    {
        readonly string hash = "prb@97";
        public string Encrypt(string message)
        {
            string encryptedMessage = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(message);
            using (MD5CryptoServiceProvider md5Service = new MD5CryptoServiceProvider())
            {
                byte[] hashData = UTF8Encoding.UTF8.GetBytes(hash);
                byte[] keys = md5Service.ComputeHash(hashData);
                using (TripleDESCryptoServiceProvider tDESService = new TripleDESCryptoServiceProvider())
                {
                    tDESService.Key = keys;
                    tDESService.Mode = CipherMode.ECB;
                    tDESService.Padding = PaddingMode.PKCS7;

                    ICryptoTransform transformation = tDESService.CreateEncryptor();
                    byte[] results = transformation.TransformFinalBlock(data, 0, data.Length);
                    encryptedMessage = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return encryptedMessage;
        }

        public string Decrypt(string message)
        {
            string decryptedMessage = "";
            byte[] data = Convert.FromBase64String(message);
            using (MD5CryptoServiceProvider md5Service = new MD5CryptoServiceProvider())
            {
                byte[] hashData = UTF8Encoding.UTF8.GetBytes(hash);
                byte[] keys = md5Service.ComputeHash(hashData);
                using (TripleDESCryptoServiceProvider tDESService = new TripleDESCryptoServiceProvider())
                {
                    tDESService.Key = keys;
                    tDESService.Mode = CipherMode.ECB;
                    tDESService.Padding = PaddingMode.PKCS7;

                    ICryptoTransform transformation = tDESService.CreateDecryptor();
                    byte[] results = transformation.TransformFinalBlock(data, 0, data.Length);
                    decryptedMessage = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return decryptedMessage;
        }
    }
}
