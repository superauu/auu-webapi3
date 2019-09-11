using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Auu.Framework.Common
{
    public static class Xml
    {
        public static string GetXml<T>(T obj)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }

        public static T GetObject<T>(string strXml) where T : class
        {
            try
            {
                using (var sr = new StringReader(strXml))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch
            {
                return null;
            }
        }

        //Convert xml string to a json string
        public static string GetJson(string strXml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(strXml);
            return JsonConvert.SerializeXmlNode(doc);
        }
    }
}