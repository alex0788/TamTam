using System;
using System.Xml;
using MovieSearcherApi;
using MovieSearcherApi.Common;
using Newtonsoft.Json.Linq;

namespace MovieSearcherApi.Api
{
    public abstract class Trailer : MovieEntry
    {
        public string videoServiceUrl = "";
        public string YoutubeKey { get; set; }
        public string VideoService { get; set; }

        protected Trailer(TrailerContext context, JObject json)
        {
            var currType = GetType();
            var baseType = currType.BaseType;
            var apiName = currType.Name.Replace(baseType.Name, string.Empty);
            var props = currType.GetProperties();
            var apiNode = context.Config.SelectSingleNode("//MovieApi/" + apiName);
            if (apiNode != null)
            {
                foreach (var prop in props)
                {
                    var currNode =
                        apiNode.SelectSingleNode(String.Format("add[@key='{0}.item.{1}']/@value", apiName, prop.Name));
                    if (currNode != null)
                    {
                        if (!String.IsNullOrEmpty(currNode.InnerText))
                        {
                            var value = Utils.GeJsonValue(json, currNode.InnerText);
                            currType.GetProperty(prop.Name).SetValue(this, value, null);
                        }
                    }
                }
            }
        }

    }
}
