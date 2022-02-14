using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace MyApplication.Utility
{
    public static class CryptographyUtility
    {
        public static string GetHashedPassword(string clearTextPassword, string username)
        {
            string hashedPassword;

            string combinedValue = username + clearTextPassword;

            hashedPassword = GetMD5Hash(combinedValue);

            return hashedPassword;
        }

        public static string GetMD5Hash(string value)
        {            
            MD5 md5Hasher = MD5.Create();

            byte[] input = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                strBuilder.Append(input[i].ToString("x2"));
            }

            string hashedValue = strBuilder.ToString();

            return hashedValue;
        }
    }
}
