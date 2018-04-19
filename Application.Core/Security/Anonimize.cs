using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Security
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EncriptedAttribute : Attribute
    {

    }

    public static class Anonimize
    {
        private static readonly string cryptoKey = "App:Anonimize:Key";

        private static readonly byte[] IV = new byte[8] { 125, 6, 87, 63, 172, 2, 173, 69 };

        /// <summary>
        /// Encrypts provided string parameter
        /// </summary>
        public static string Encrypt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return null;
            }
            return result;
        }

        //
        // Summary:
        //     Decripts the specified string.
        //
        // Parameters:
        //   input:
        //     The input string to decrypt.
        //
        // Returns:
        //     The computed decryption.
        public static string Decrypt(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string result = string.Empty;
            try
            {
                byte[] buffer = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                des.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(cryptoKey));
                des.IV = IV;
                result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return null;
            }
            return result;
        }
    }
}
