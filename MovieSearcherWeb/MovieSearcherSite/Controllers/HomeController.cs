using System;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;
using MovieSearcherApi.Api;
using MovieSearcherApi.Api.imdbMovie;

namespace MovieSearcherSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
