using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Aliyun.OSS;
using Auu.Framework.Common;
using Auu.PlugIn.Cloud.Base;

namespace Auu.PlugIn.Cloud.AliyunApi
{
    public class OssToken: ICloud
    {
        private readonly string AccessKeyId = "LTAIqxZID6JFlQOS";
        private readonly string AccessKeySecret = "NoZItPrupET8xEaFKMJ8TrBuliUGBA";
        private readonly string Endpoint = "oss-cn-qingdao.aliyuncs.com";

        public string GetOssToken(string sessionid)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var guid = Guid.NewGuid().ToString();
            var sign = "AccessKeyId=LTAIYDnwcYhBJ7tY&Action=AssumeRole";
            sign += "&DurationSeconds=3600";
            sign += "&Format=JSON";
            sign += "&RoleArn=" + Encrypt.UrlEncode("acs:ram::1349011346882730:role/aliyunosstokengeneratorrole");
            sign += "&RoleSessionName=" + Encrypt.Md5(sessionid);
            sign += "&SignatureMethod=HMAC-SHA1";
            sign += "&SignatureNonce=" + Encrypt.UrlEncode(guid);
            sign += "&SignatureVersion=1.0";
            sign += "&Timestamp=" + Encrypt.UrlEncode(timestamp);
            sign += "&Version=2015-04-01";

            sign = Encrypt.UrlEncode(sign);
            sign = "GET&%2F&" + sign;
            sign = Encrypt.Sha1(sign, "aT8CzdEEpTrcbHm5VsjGTbuU7YxBsH&");

            var request = "https://sts.aliyuncs.com?Format=JSON";
            request += "&Version=2015-04-01";
            request += "&AccessKeyId=LTAIYDnwcYhBJ7tY";
            request += "&Signature=" + Encrypt.UrlEncode(sign);
            request += "&SignatureMethod=HMAC-SHA1";
            request += "&SignatureVersion=1.0";
            request += "&SignatureNonce=" + Encrypt.UrlEncode(guid);
            request += "&Timestamp=" + Encrypt.UrlEncode(timestamp);
            request += "&Action=AssumeRole";
            request += "&RoleArn=" + Encrypt.UrlEncode("acs:ram::1349011346882730:role/aliyunosstokengeneratorrole");
            request += "&RoleSessionName=" + Encrypt.Md5(sessionid);
            request += "&DurationSeconds=3600";

            return HttpGet(request, Encoding.UTF8);
        }

        /// <summary>
        ///     Http Get 同步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Encoding encoding)
        {
            var httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var ret = encoding.GetString(t.Result);
            return ret;
        }

        public void PutObject(string filename, byte[] img)
        {
            var client = new OssClient(Endpoint, AccessKeyId, AccessKeySecret);
            var dda = client.PutObject("happy-sale-images", filename, new MemoryStream(img));
        }

        /// <summary>
        ///     获取公共参数
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Action"></param>
        /// <param name="Params"></param>
        public static string CommonParameter(string Url, string Action, List<string> Params)
        {
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var guid = Guid.NewGuid().ToString();
            var AccessKeyId = "zecPSEzBvJ91apXS";
            var AKS = "gthj4xqnVUh6FuyNTFzTCjMnclGZyD&";
            Params.Add("AccessKeyId=" + Encrypt.UrlEncode(AccessKeyId));
            Params.Add("Action=" + Encrypt.UrlEncode(AKS));
            Params.Add("Format=JSON");
            Params.Add("SignatureMethod=HMAC-SHA1");
            Params.Add("SignatureNonce=" + Encrypt.UrlEncode(guid));
            Params.Add("Version=2016-11-01");
            Params.Add("Timestamp=" + Encrypt.UrlEncode(timestamp));
            Params.Add("SignatureVersion=1.0");
            Params.Sort();
            var Paramstr = string.Join("&", Params.ToArray());
            var sign = Encrypt.UrlEncode(Paramstr);
            sign = "GET&%2F&" + sign;
            sign = Encrypt.Sha1(sign, AKS);

            var request = Url + "?" + Paramstr;
            request += "&Signature=" + Encrypt.UrlEncode(sign);
            return HttpGet(request, Encoding.UTF8);
        }
    }
}