using System;
using System.Collections.Generic;
using System.Xml;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.Api
{
    public abstract class Movie:MovieEntry
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string IdImdb { get; set; }
        public string Year { get; set; }
        public string UrlImdb { get; set; }
        public string VideoUrl { get; set; }
        public string Plot { get; set; }

        public Trailer Trailer;


        protected Movie(MovieContext context, XmlNode xml)
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
                            var value = Utils.GetXmlValue(xml, currNode.InnerText);
                            currType.GetProperty(prop.Name).SetValue(this, value, null);
                        }
                    }
                }
            }
        }
    
    }
}
