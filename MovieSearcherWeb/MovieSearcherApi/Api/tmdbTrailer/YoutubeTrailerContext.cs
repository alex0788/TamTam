using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using MovieSearcherApi.Api.imdbMovie;
using MovieSearcherApi.Api.tmdbTrailer;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.Api.youtubeTrailer
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
