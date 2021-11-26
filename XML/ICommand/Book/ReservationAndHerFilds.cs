namespace FileXML
{
    public class ReservationAndHerFilds
    {
        public Dates Dates {  get; set; }
        public int IndexNameFilm {  get; set; }
        public string TimeStartFilm {  get; set; }
        public ReservationSession ReservationSession {  get; set; }
        public ReservationAndHerFilds(Dates dates,int indexNameFilm, string timeStartFilm,ReservationSession bookedSession)
        {
            this.Dates = dates;
            this.IndexNameFilm = indexNameFilm;
            this.TimeStartFilm = timeStartFilm;
            this.ReservationSession = bookedSession;
        }
    }
}