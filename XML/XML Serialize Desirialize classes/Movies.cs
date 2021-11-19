using System;
using System.Collections.Generic;

namespace fileXML
{
    [Serializable]
    public class Movies
    {
        public List<Movie> Movie { get; set; }
        public Movies() { }

        public Movies(List<Movie> movie)
        {
            this.Movie = movie;
        }
    }
}
