using System;
using System.Xml;

namespace MovieSearcherApi
{
    public abstract class ContextEntry
    {
        public string Key { get; set; }
        public string Url { get; set; }
        public string ItemsOnPage { get; set; }
        public string SingleMovie { get; set; }
        private readonly XmlDocument _config;

        public XmlDocument Config { get { return _config; } }

        protected ContextEntry(XmlDocument configuration)
        {
            if (configuration != null)
            {
                _config = configuration;
                InitPropertiesFromConfig(_config);
            }
        }

        private void InitPropertiesFromConfig(XmlDocument configDocument)
        {
            var currType = GetType();
            var baseType = currType.BaseType;
            var apiName = currType.Name.Replace(baseType.Name, string.Empty);
            var props = currType.GetProperties();
            var apiNode = configDocument.SelectSingleNode("//MovieApi/" + apiName);
            if (apiNode != null)
            {
                foreach (var prop in props)
                {
                    var currNode =
                        apiNode.SelectSingleNode(String.Format("add[@key='{0}.context.{1}']/@value", apiName, prop.Name));
                    if (currNode != null)
                    {
                        if (!String.IsNullOrEmpty(currNode.InnerText))
                        {
                            currType.GetProperty(prop.Name).SetValue(this, currNode.InnerText, null);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Configuration file is broken. Please check");
            }
        }

        public abstract string BuildQuery();
    }
}
