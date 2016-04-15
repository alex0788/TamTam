# TamTam
assignment-backend (https://www.tamtam.nl/en/assignment-backend/)

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



