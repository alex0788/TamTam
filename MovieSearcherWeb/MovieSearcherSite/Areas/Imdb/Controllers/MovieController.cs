using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MovieSearcherApi.Api;
using MovieSearcherSite.Areas.Imdb.Models;

namespace MovieSearcherSite.Areas.Imdb.Controllers
{
    public class MovieController : Controller
    {
        readonly ImdbRepository _repo = new ImdbRepository();
        public PartialViewResult GetMoviesByTitle(string title,string year,string exact,int offset)
        {
            try
            {
                var movs = _repo.GetMoviesByTitle(title.ToLower().TrimStart().TrimEnd(), year, exact, offset);
                return ShowResults(movs);
            }
            catch (Exception ex)
            {
                return PartialView("Error",ex.Message);
            }
        }

        public PartialViewResult GetMoviesById(string movid, int offset)
        {
            try
            {
                var movs = _repo.GetMovieById(movid.Trim(), offset);
                return ShowResults(movs);
            }
            catch (Exception ex)
            {
                return PartialView("Error", ex.Message);
            }
        }

        private PartialViewResult ShowResults(IEnumerable<Movie> movs)
        {
            if (movs != null && movs.Any())
            {
                return PartialView("Movie", movs);
            }
            else
            {
                return PartialView("NoResults");
            }
        }
	}
}