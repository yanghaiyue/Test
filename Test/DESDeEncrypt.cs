using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Test
{
    public class DESDeEncrypt
    {
        private static string key = "EastimeDESKey";
        /// <summary>  
        /// DES解密方法  
        /// </summary>  
        /// <param name="encryptedValue">待解密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <param name="iv">向量</param>  
        /// <returns>解密后的字符串</returns>  
        public static string DESDecrypt(string encryptedValue, string iv)
        {
            string result = string.Empty;
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            ICryptoTransform providerDecryptor = provider.CreateDecryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(key.Substring(0, 7)));


            //using (DESCryptoServiceProvider sa = new DESCryptoServiceProvider
            //{ Key = Encoding.UTF8.GetBytes(key), IV = Encoding.UTF8.GetBytes(iv) })
            //{
            //    using (ICryptoTransform ct = sa.CreateDecryptor())
            //    {
            //        byte[] byt = Convert.FromBase64String(encryptedValue);

            //        using (var ms = new MemoryStream())
            //        {
            //            using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
            //            {
            //                cs.Write(byt, 0, byt.Length);
            //                cs.FlushFinalBlock();
            //            }
            //            return Encoding.UTF8.GetString(ms.ToArray());
            //        }
            //    }
            //}
            return result;
        }
    }
}
