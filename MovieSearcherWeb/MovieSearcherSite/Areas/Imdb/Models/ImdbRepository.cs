using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Xml;
using MovieSearcherApi;
using MovieSearcherApi.Api;
using MovieSearcherApi.Api.imdbMovie;

namespace MovieSearcherSite.Areas.Imdb.Models
{
    public class ImdbRepository 
    {
        public static MovieContext ImdbApi { get; set; }
        static ImdbRepository()
        {
            InitContext();
        }

        private static void InitContext()
        {
            var config = WebConfigurationManager.AppSettings["config"];
            var configPath = HttpContext.Current.Server.MapPath(config);
            if (File.Exists(configPath))
            {
                XmlDocument xmlDoc = new ConfigXmlDocument();
                xmlDoc.Load(File.OpenRead(configPath));
                try
                {
                    ImdbApi = new ImdbMovieContext(xmlDoc);
                }
                catch (Exception ex)
                {
                    //exception
                }
            }
        }


        private IEnumerable<Movie> GetFromCache(string key)
        {
            if (WebCache.Get(key) != null)
            {
                return (IEnumerable<Movie>)WebCache.Get(key);
            }
            return null;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string title, string year,string exact, int offset)
        {
            var key = string.Format("title={0}&year={1}&exact={2}&offset={3}", title, year, exact, offset);
            IEnumerable<Movie> movies = GetFromCache(key);
            if (movies == null)
            {
                movies = ImdbApi.SearchMovies(title, year,exact, offset);
                WebCache.Set(key, movies, 300);
            }
            return movies;
        }

        public IEnumerable<Movie> GetMovieById(string movId, int offset)
        {
            var key = string.Format("movId={0}&offset={1}", movId, offset);
            IEnumerable<Movie> movies = GetFromCache(key);
            if (movies == null)
            {
                movies = ImdbApi.SearchMovies(movId, offset);
                WebCache.Set(key, movies, 300);
            }
            return movies;
        }
    }
}
 