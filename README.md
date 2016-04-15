# TamTam assignment-backend 
https://www.tamtam.nl/en/assignment-backend

An application for searching trailers MovieSearcherWeb.
An API for searching movies : www.myapifilms.com/imdb.
An API for searching trailers by imdbId : http://www.myapifilms.com/tmdb/movieInfoImdb.

Solution MovieSearcherWeb contains 2 projects:
- MovieSearcherApi - an api that provides an api for searching movies and trailers.
  Project contains 2 main entries ContextEntry and MovieEntry.
  ContextEntry - an abstract class which contain configuration file. 
  Using xpath it initializes own properties from xml.
  Derived classes in folder Api TrailerContext (within defined methods for accessing trailers) and MovieContext (within defined methods for accessing movies).
  MovieEntry - just abstract class for classes Movie and Trailer.
  Derived classes Movie (it contains logic for initializing own fields from xml) and Trailer (it contains logic for initializing own fields from json).
  Within folder Api/imdbMovie stored real implementation based on abstract classes above for requesting movies from imdb service.
  Within folder Api/tmdbTrailer stored real implementation based on abstract classes above for requesting youtube trailers from tmdb service.

- MovieSearcherSite - website that requests data from API and shows items on the page.
It contains config file ~\Config\config.xml for configuring API.


# Issues
1.Use an API of an online movie database (e.g. IMDB or Rotten Tomatoes);
I used another api which I found in Internet www.myapifilms.com/imdb. 

2.Use an API of an online video service (e.g. YouTube or Vimeo);
I used another api which I found in Internet http://www.myapifilms.com/tmdb/movieInfoImdb. 

3.Create your own WebAPI as middleware to retrieve the results of both services and aggregate them;
Prepared a separate library which can be used in another application. It aggregates data and saves movies and trailers in 
a short format.

4.Cache the aggregated data for performance;
I used memory cache for storing data. Each request will live 5 hours in memory. It decreased a tile for loading the same query.

5.Make the search as smart as you can.
I did not so complex search. Current search can be extended via adding new controls on the page for searching which generates a query
to the remote server. 
Possible search cases: by id, by title, by title + year, by title + exact

6.Use the development language of the vacancy you are applying for.
I used next technology: .NET.C#, JSON.NET, ASP.NET MVC 4, javascript, jquery, html, css


Looking forward to hear a feedback from you.


