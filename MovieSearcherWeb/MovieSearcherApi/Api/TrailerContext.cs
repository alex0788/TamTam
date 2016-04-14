using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MovieSearcherApi.Api
{
    public abstract class TrailerContext:ContextEntry
    {
        protected TrailerContext(XmlDocument configuration) : base(configuration)
        {
        }
        public abstract Trailer GetTrailerById(string id);
    }
}
