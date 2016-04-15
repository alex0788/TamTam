using System;
using System.Web;
using System.Xml;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.Api.tmdbTrailer
{
    public class YoutubeTrailerContext:TrailerContext
    {
        public YoutubeTrailerContext(XmlDocument configuration)
            : base(configuration)
        {
        }

        public override string BuildQuery()
        {
            var url = new UriBuilder(Url);
            var param = HttpUtility.ParseQueryString(string.Empty);
            param["token"] = Key;
            param["format"] = "json";
            param["language"] = "en";
            param["videos"] = "1";
            url.Query = param.ToString();
            return url.Uri.ToString();
        }

        public override Trailer GetTrailerById(string id)
        {
            var url = new UriBuilder(BuildQuery());
            var query = HttpUtility.ParseQueryString(url.Query);
            query["idIMDB"] = id;
            url.Query = query.ToString();
            var jObject = Utils.RequesJsonFeed(url.ToString());
            Trailer trailer = new YoutubeTrailer(this, jObject);
            return trailer;
        }
    }
}
