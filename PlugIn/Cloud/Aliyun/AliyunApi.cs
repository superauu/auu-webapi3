using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Auu.Framework.Common;
using Auu.PlugIn.Cloud.Base;

namespace Auu.PlugIn.Cloud.AliyunApi
{
    public static class AliyunApi
    {
        public static string Request(ApiParam param,string action, params string[] values)
        {
            
            return Format(param.Url,
                param.AccessKeyId,
                param.Sha1Key,
                action, param.Version, values);
        }
        //格式化api请求
        private static string Format(string url, string accessKeyId, string key,
            string action, string version, params string[] values)
        {
            try
            {
                var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
                var guid = Guid.NewGuid().ToString();
                var strS = new List<string>
                {
                    "AccessKeyId=" + accessKeyId,
                    "Action=" + action,
                    "Format=JSON",
                    "SignatureMethod=HMAC-SHA1",
                    "SignatureNonce=" + Encrypt.UrlEncode(Encrypt.Md5(guid)),
                    "SignatureVersion=1.0",
                    "Timestamp=" + Encrypt.UrlEncode(timestamp),
                    "Version=" + version
                };
                strS.AddRange(values);
                var sort = strS.ToArray();
                Array.Sort(sort, (a, b) => string.Compare(a, b, StringComparison.Ordinal));
                var sign = sort.Aggregate("", (current, str) => current + ("&" + str));
                sign = sign.Substring(1);
                sign = Encrypt.UrlEncode(sign);
                sign = "GET&%2F&" + sign;
                sign = Encrypt.Sha1(sign, key + "&");
                var request = url + "?&Signature=" + Encrypt.UrlEncode(sign);
                request = sort.Aggregate(request, (current, str) => current + ("&" + str));
                return HttpGet(request, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return "error:" + ex.Message;
            }
        }

        private static string HttpGet(string url, Encoding encoding)
        {
            var httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding?.GetString(t.Result);
            return ret;
        }
    }
}