using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using MovieSearcherApi.Common;

namespace MovieSearcherApi.Api.imdbMovie
{
    public class ImdbMovieContext : MovieContext
    {
        public ImdbMovieContext(XmlDocument configDocument) : base(configDocument){}

        public override IEnumerable<Movie> SearchMovies(string title,string year,string exact,int offset=10)
        {
            var url = new UriBuilder(BuildQuery());
            var query = HttpUtility.ParseQueryString(url.Query);
            query["title"] = title;
            if (!string.IsNullOrEmpty(year))
            {
                query["forceYear"] = "1";
                query["year"] = year;
            }
            query["exactFilter"] = exact;
            query["offset"] = offset.ToString();
            url.Query = query.ToString();
            var doc = Utils.RequestXmlFeed(url.ToString());
            List<Movie> movs = new List<Movie>();
            if (doc!=null && doc.SelectNodes(SingleMovie) != null)
            {
                var nodes = doc.SelectNodes(SingleMovie);
                foreach (XmlNode selectNode in nodes)
                {
                   Movie mov = new ImdbMovie(this,selectNode);
                   if (movs.All(l => l.IdImdb != mov.IdImdb))
                   {
                       movs.Add(mov);
                   }
                }
            }
            return movs;
        }

        public override IEnumerable<Movie> SearchMovies(string id, int offset=10)
        {
            var url = new UriBuilder(BuildQuery());
            var query = HttpUtility.ParseQueryString(url.Query);
            query["idIMDB"] = id;
            query["offset"] = offset.ToString();
            url.Query = query.ToString();
            var doc = Utils.RequestXmlFeed(url.ToString());
            List<Movie> movs = new List<Movie>();
            if (doc != null && doc.SelectNodes(SingleMovie) != null)
            {
                var nodes = doc.SelectNodes(SingleMovie);
                if (nodes != null)
                    foreach (XmlNode selectNode in nodes)
                    {
                        Movie mov = new ImdbMovie(this, selectNode);
                        if (!movs.Any(l => l.IdImdb == mov.IdImdb))
                        {
                            movs.Add(mov);
                        }
                    }
            }
            return movs;
        }

        public override string BuildQuery()
        {
            var url = new UriBuilder(Url);
            var param = HttpUtility.ParseQueryString(string.Empty);
            param["token"] = Key;
            param["format"] = "xml";
            param["filter"] = "3";
            param["language"] = "en-us";
            param["trailers"] = "1";
            int limit = 0;
            param["limit"] = int.TryParse(ItemsOnPage, out limit) ?  ItemsOnPage : "5";
            url.Query = param.ToString();
            return url.Uri.ToString();
        }
    }
}
