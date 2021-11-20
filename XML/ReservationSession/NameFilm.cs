using System.Collections.Generic;

namespace FileXML
{
    public class NameFilm
    {
        public string Film { get; set; }
        public List<TimeStartFilm> Times { get; set; }
        public NameFilm() { }
        public NameFilm(string film, List<TimeStartFilm> timeStart)
        {
            this.Film = film;
            this.Times = timeStart;
        }
    }
}
