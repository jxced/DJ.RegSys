using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DJ.Utility
{
    public static class Kits
    {
        /// <summary>
        /// md5加密字符串
        /// </summary>
        /// <param name="source">要加密的源</param>
        /// <param name="md5">传入md5类的实现</param>
        /// <returns></returns>
        public static string ToMD5(this string source,MD5CryptoServiceProvider md5)
        {
            //md5加密；
            //Encoding.UTF8.GetBytes(input) 把传入的字符串计算转换成utf8编码字节数组；
            //创建一个md5实例，调用其ComputeHash计算指定的字节数组的哈希值；
            byte[] data= md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("X2"));
            }
            return stringBuilder.ToString().Replace("-","");
        }
    }
}
