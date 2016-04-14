using System.Web.Mvc;
using MovieSearcherSite.Areas.Imdb.Models;

namespace MovieSearcherSite.Areas.Imdb.Controllers
{
    public class MovieController : Controller
    {
        readonly ImdbRepository _repo = new ImdbRepository();
        public PartialViewResult GetMoviesByTitle(string title,string year,string exact,int offset)
        {
            var movs = _repo.GetMoviesByTitle(title, year,exact, offset);
            return PartialView("Movie", movs);
        }
        public PartialViewResult GetMoviesById(string movid, int offset)
        {
            var movs = _repo.GetMovieById(movid, offset);
            return PartialView("Movie", movs);
        }
	}
}