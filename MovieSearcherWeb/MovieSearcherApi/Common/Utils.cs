using System;
using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace MovieSearcherApi.Common
{
    public static class Utils
    {
        public static XmlDocument RequestXmlFeed(string requestUrl)
        {
            XmlDocument xmlDoc = null;
            try
            {
                var request = WebRequest.Create(requestUrl) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return xmlDoc;
        }

        public static JObject RequesJsonFeed(string requestUrl)
        {
            JObject o = null;
            try
            {
                var json = new WebClient().DownloadString(requestUrl);
                if (json != null)
                {
                    o = JObject.Parse(json);
                }
                return o;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GeJsonValue(JObject doc, string jPath)
        {
            try
            {
                return doc.SelectToken(jPath).ToString();
            }
            catch (Exception )
            {
               return string.Empty;
            }
        }
        public static string GetXmlValue(XmlNode doc,string xPath)
        {
            var node = doc.SelectSingleNode(xPath);
            if (node != null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }
    }
}
