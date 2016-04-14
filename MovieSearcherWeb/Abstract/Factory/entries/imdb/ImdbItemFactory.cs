using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstract.Factory.entries.imdb
{
    class ImdbItemFactory:MovieItem
    {
        public ImdbItemFactory(ImdbMovieContext context, XmlNode xml) : base(context, xml)
        {
        }
    }
}
