using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace MovieSearcherApi.Api.tmdbTrailer
{
    public class YoutubeTrailer:Trailer
    {
        public YoutubeTrailer(TrailerContext context, JObject json)
            : base(context, json)
        {
            videoServiceUrl = "https://www.youtube.com/watch?v=";
        }
    }
}
