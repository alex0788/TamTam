using System.Collections.Generic;
using System.Xml;


namespace MovieSearcherApi.Api
{
    public abstract class MovieContext:ContextEntry
    {
        protected MovieContext(XmlDocument configuration):base(configuration){}

        public abstract IEnumerable<Movie> SearchMovies(string title, string year, string exact, int offset = 0);
        public abstract IEnumerable<Movie> SearchMovies(string id, int offset = 0);
    }
}
