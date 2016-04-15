using System.Xml;
using MovieSearcherApi.Api.tmdbTrailer;

namespace MovieSearcherApi.Api.imdbMovie
{
    public class ImdbMovie : Movie
    {
        public ImdbMovie(ImdbMovieContext movieContext, XmlNode doc) : base(movieContext, doc)
        {
            TrailerContext context = new YoutubeTrailerContext(movieContext.Config);
            Trailer = context.GetTrailerById(IdImdb);
        }
    }
}
