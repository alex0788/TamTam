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
