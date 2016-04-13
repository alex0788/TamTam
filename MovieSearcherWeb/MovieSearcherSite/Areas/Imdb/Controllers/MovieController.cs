using System.Web.Mvc;
using MovieSearcherSite.Areas.Imdb.Models;

namespace MovieSearcherSite.Areas.Imdb.Controllers
{
    public class MovieController : Controller
    {
        public PartialViewResult GetMovies(string title,int offset)
        {
            var repo = new ImdbRepository();
            var movs = repo.GetMoviesList(title,offset);
            return PartialView("Movie", movs);
        }
	}
}