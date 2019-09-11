using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Auu.Framework.Common
{
    public static class Http
    {
        public enum MyHttpMethod
        {
            Get,
            Post,
            Put,
            Delete
        }
        /// <summary>
        ///     Http Get 同步方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> headers,
            Dictionary<string, string> param = null)
        {
            using (var httpClient = new HttpClient())
            {
                if (headers != null)
                    foreach (var header in headers)
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

                if (param != null) url += "?" + param.GetQueryString();
                var t = httpClient.GetByteArrayAsync(url);
                t.Wait();
                var ret = Encoding.UTF8.GetString(t.Result);
                return ret;
            }
        }

        /// <summary>
        ///     POST 同步
        /// </summary>
        public static string HttpPost(string url, Dictionary<string, string> headers,
            Dictionary<string, string> form = null, string content = null, int timeOut = 10000)
        {
            using (var handler = new HttpClientHandler())
            {
                var client = new HttpClient(handler);
                HttpContent hc = null;
                if (content != null)
                    hc = new StringContent(content);
                else if (form != null) hc = new FormUrlEncodedContent(form);

                if (headers != null)
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);

                var t = client.PostAsync(url, hc);
                t.Wait();
                var t2 = t.Result.Content.ReadAsByteArrayAsync();
                return Encoding.UTF8.GetString(t2.Result);
            }
        }

        private static string HttpPostOrPutJson(string url, Dictionary<string, string> headers, string content,
            string method = "post")
        {
            using (var handler = new HttpClientHandler())
            {
                var client = new HttpClient(handler);
                HttpContent hc = new StringContent(content);
                hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (headers != null)
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);

                if (method.ToLower() == "post")
                {
                    var t = client.PostAsync(url, hc);
                    t.Wait();
                    var t2 = t.Result.Content.ReadAsByteArrayAsync();
                    return Encoding.UTF8.GetString(t2.Result);
                }

                if (method.ToLower() == "put")
                {
                    var t = client.PutAsync(url, hc);
                    t.Wait();
                    var t2 = t.Result.Content.ReadAsByteArrayAsync();
                    return Encoding.UTF8.GetString(t2.Result);
                }

                throw new Exception("Http method wrong");
            }
        }

        public static string HttpPostJson(string url, Dictionary<string, string> headers, string content)
        {
            return HttpPostOrPutJson(url, headers, content);
        }

        public static string HttpPutJson(string url, Dictionary<string, string> headers, string content)
        {
            return HttpPostOrPutJson(url, headers, content, "put");
        }

        public static string HttpDelete(string url, Dictionary<string, string> headers, int timeOut = 10000)
        {
            using (var handler = new HttpClientHandler())
            {
                var client = new HttpClient(handler);
                if (headers != null)
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);

                var t = client.DeleteAsync(url);
                t.Wait();
                var t2 = t.Result.Content.ReadAsByteArrayAsync();
                return Encoding.UTF8.GetString(t2.Result);
            }
        }

        /// <summary>
        ///     组装QueryString的方法
        ///     参数之间用& 连接，首位没有符号，如：a=1& b=2& c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0) return "";

            var sb = new StringBuilder();

            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count) sb.Append("&");
            }

            return sb.ToString();
        }
    }
}