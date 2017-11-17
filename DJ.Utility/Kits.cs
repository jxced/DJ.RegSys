using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DJ.Utility
{
    public static class Kits
    {
        #region MD5加密
        /// <summary>
        /// md5加密字符串
        /// </summary>
        /// <param name="source">要加密的源</param>
        /// <param name="md5">传入md5类的实现</param>
        /// <returns></returns>
        public static string ToMD5(this string source, MD5CryptoServiceProvider md5)
        {
            //md5加密；
            //Encoding.UTF8.GetBytes(input) 把传入的字符串计算转换成utf8编码字节数组；
            //创建一个md5实例，调用其ComputeHash计算指定的字节数组的哈希值；
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("X2"));
            }
            return stringBuilder.ToString().Replace("-", "");
        }
        #endregion
        /// <summary>
        /// 封装cookie
        /// </summary>
        /// <param name="source">cookie的值</param>
        /// <param name="days">设置保存天数，默认7天</param>
        /// <param name="domain">设置域名</param>
        /// <returns></returns>
        public static HttpCookie Cookie(this string source,double days=7,string domain=null )
        {
            var cookie = new HttpCookie(UtilityStr.USER_COOKIE_KEY, source);
            cookie.Expires = DateTime.Now.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(cookie);
            return cookie;
        }
    }
 }
