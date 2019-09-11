using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Auu.Framework.Common
{
    public static class Encrypt
    {
        /// <summary>
        ///     md5加密，到处都用
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>加密后的字符串(大写）</returns>
        public static string Md5(string value)
        {
            if (value == "")
                return "";
            byte[] bytes;
            using (var md5 = MD5.Create())
            {
                bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            }

            var result = new StringBuilder();
            foreach (var t in bytes)
                result.Append(t.ToString("X2"));
            return result.ToString();
        }

        /// <summary>
        ///     没密码的sha1加密，目前没啥用
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>加密后的字符串(大写）</returns>
        public static string Sha1(string value)
        {
            if (value == "")
                return "";
            var enc = Encoding.GetEncoding(0);

            var buffer = enc.GetBytes(value);
            var sha1 = SHA1.Create();
            var hash = BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }

        /// <summary>
        ///     sha256加密个推restful api会用到
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Sha256(string value)
        {
            if (value == "")
                return "";
            var enc = Encoding.GetEncoding(0);
            var buffer = enc.GetBytes(value);
            var sha256 = SHA256.Create();
            var hash = BitConverter.ToString(sha256.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }

        /// <summary>
        ///     有密码的Sha1加密，oss会用到
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <param name="key">加密秘钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Sha1(string value, string key)
        {
            if (value == "")
                return "";
            var myHmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key));
            var byteText = myHmacsha1.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToBase64String(byteText);
        }

        /// <summary>
        ///     url编码oss有用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            var builder = new StringBuilder();
            foreach (var c in str)
                if (HttpUtility.UrlEncode(c.ToString())?.Length > 1)
                    builder.Append(HttpUtility.UrlEncode(c.ToString())?.ToUpper());
                else
                    builder.Append(c);
            return builder.ToString();
        }

        /// <summary>
        ///     url解码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlDecode(string value)
        {
            return HttpUtility.UrlDecode(value);
        }


        public static string ToBase64String(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";

            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string UnBase64String(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            var bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}