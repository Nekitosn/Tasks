using System;
using System.Collections.Generic;

namespace FileXML
{
    public class ReservationSession
    {
        public DateTime Value { get; set; }
        public List<NameFilm> Films { get; set; }
        public ReservationSession() { }
        public ReservationSession(Dates dates, int indexNameFilm, string timeStartFilm)
        {
            this.Value = dates.Date.Value;
            this.Films = new List<NameFilm>() { new NameFilm(dates.Date.Movies.Movie[indexNameFilm].Name, new List<TimeStartFilm>() { new TimeStartFilm(timeStartFilm) }) };
        }
    }
}
