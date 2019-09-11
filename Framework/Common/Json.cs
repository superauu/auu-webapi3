using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace Auu.Framework.Common
{
    public static class Json
    {
        public static string GetJson(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static T GetObject<T>(string json)
        {
            var serializer = new JsonSerializer();
            var sr = new StringReader(json);
            var o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            var t = (T) o;
            return t;
        }

        public static string GetJsonFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc);
            return json;
        }
        public static string GetXmlFromJson(string json)
        {
            XmlDocument doc=JsonConvert.DeserializeXmlNode(json);
            return doc.OuterXml;
        }
        
        /// <summary>
        ///     获取json字符串中某个属性出现的次数
        /// </summary>
        /// <param name="json"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static int GetPropertyCount(string json, string propertyName)
        {
            var reader = new JsonTextReader(new StringReader(json));
            var result = 0;
            while (reader.Read())
                if (reader.TokenType.ToString() == "PropertyName" && reader.Value.ToString() == propertyName)
                    result++;
            return result;
        }
    }
}