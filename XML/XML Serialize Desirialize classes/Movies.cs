using System;
using System.Collections.Generic;

namespace FileXML
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
