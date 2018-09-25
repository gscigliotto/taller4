using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    class SeguridadADM
    {
        public static String EncodePassword(String txt)
        {
            HashAlgorithm hashProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(txt);
            return ArrayToString(hashProvider.ComputeHash(bytes));

            
        }
        private static string ArrayToString(byte[] byteArray)
        {
            StringBuilder builder = new StringBuilder(byteArray.Length);
            for (int i = 0; i < byteArray.Length; i++)
            {
                builder.Append(byteArray[i].ToString("X2"));
            }
            return builder.ToString();
        }
    }
}
