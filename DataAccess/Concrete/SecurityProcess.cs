using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    internal class SecurityProcess
    {
        static SecurityProcess securityProcess;
        private SecurityProcess()
        {

        }
        public string Encrypt(string eKey, string value)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(eKey));
            tripleDESCryptoService.Key = byteHash;
            tripleDESCryptoService.Mode = CipherMode.ECB;
            byte[] data = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(tripleDESCryptoService.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
        }

        public string Decrypt(string dKey, string value)
        {
            TripleDESCryptoServiceProvider tripleDESCryptoService = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            byte[] byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(dKey));
            tripleDESCryptoService.Key = byteHash;
            tripleDESCryptoService.Mode = CipherMode.ECB;
            byte[] data = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(tripleDESCryptoService.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
        }

        public static SecurityProcess GetInstance()
        {
            if (securityProcess==null)
            {
                securityProcess = new SecurityProcess();
            }
            return securityProcess;
        }

    }
}
