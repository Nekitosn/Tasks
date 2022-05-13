using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace FileXML
{
    public class Book : ICommand
    {
        private IParser parser;

        private List<Dates> datesList;

        public Book(IParser parser)
        {
            this.parser = parser;

            this.datesList = this.parser.Deserialize<Dates>(GlobalConstant.GetPathCinema());

        }
        public  void Execute()
        {
            ReservationAndHerFilds reservationAndHerFilds;
            try
            {
                bool existSesion = ExistSession(out reservationAndHerFilds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var bookList = this.parser.Deserialize<ReservationSession>(GlobalConstant.GetPathBookInfo());

            if (bookList == null )
            {
                BookedJson(bookList, reservationAndHerFilds);
                Console.WriteLine($"You have booked a session\n");
            }
            else if (IsThisSessionBooked(bookList, reservationAndHerFilds.ReservationSession) != true)
            {
                BookedJson(bookList, reservationAndHerFilds);
                Console.WriteLine($"You have booked a session\n");
            }
            else
            {
                Console.WriteLine("This session is already booked\n");
                return;
            }
        }

        private bool ExistSession(out ReservationAndHerFilds reservationAndHerFilds)
        {
            reservationAndHerFilds = GetReservationSession();
            return true;
        }
        private ReservationAndHerFilds GetReservationSession()
        {

            Dates dates = ExistsValue(datesList);
            if (dates == null) throw new Exception("There is no schedule for this date\n");
            int indexNameFilm = ExistsFilm(dates);
            if (indexNameFilm == -1) throw new Exception("In this date of this movie is not\n");
            string timeStartFilm = ExistsTime(dates, indexNameFilm);
            if (timeStartFilm == string.Empty) throw new Exception("There are no sessions at this time\n");
            ReservationSession reservationSession = new ReservationSession(dates, indexNameFilm, timeStartFilm);
            
            return new(dates, indexNameFilm,timeStartFilm,reservationSession);
        }
        private Dates ExistsValue(List<Dates> allSessions)
        {
            Console.WriteLine("Specify the date when you want to purchase a ticket: ");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                for (int i = 0; i < allSessions.Count; i++)
                {
                    if (date == allSessions[i].Date.Value)
                        return allSessions[i];
                }

                return null;
        }
        private int ExistsFilm(Dates dates)
        {
            Console.WriteLine("Which movie do you want to go to: ");
            string nameFilm = Console.ReadLine();

            for (int i = 0; i < dates.Date.Movies.Movie.Count; i++)
            {
                if (nameFilm == dates.Date.Movies.Movie[i].Name)
                    return i;
            }

            return -1;
        }
        private string ExistsTime(Dates dates, int indexNameFIlm)
        {
            Console.WriteLine("What time do you want to go: ");
            string time = Console.ReadLine();

            for (int i = 0; i < dates.Date.Movies.Movie[indexNameFIlm].Sessions.Session.Count; i++)
            {
                if (time == dates.Date.Movies.Movie[indexNameFIlm].Sessions.Session[i].Time)
                    return time;
            }

            return string.Empty;
        }

        private bool IsThisSessionBooked(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                    for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                        if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                            for (int k = 0; k < allReservationSessions[i].Films[j].Times.Count; k++)
                                if (allReservationSessions[i].Films[j].Times[k].Time == bookNow.Films[0].Times[0].Time)
                                    return true;
            }
            return false;
        }


        private void BookedJson(List<ReservationSession> bookList, ReservationAndHerFilds reservationAndHerFilds)
        {
            if (bookList == null)
            {
                bookList = new List<ReservationSession>();
                bookList.Add(reservationAndHerFilds.ReservationSession);
                this.parser.Serialize(bookList, GlobalConstant.GetPathBookInfo());
                return;
            }

            int indexReservationNameFilm = GetIndexSessionOnThisMovie(bookList, reservationAndHerFilds.ReservationSession);
            int indexValue = GetIndexSessionInThisDay(bookList, reservationAndHerFilds.ReservationSession);
            //Добавляем на существующую(ту которую указал пользователь) дату, на существующий фильм новое время
            if (CheckReservationSessionOnThisMovie(bookList, reservationAndHerFilds.ReservationSession))
            {
                bookList[indexValue].Films[indexReservationNameFilm].Times.Add(
                    new TimeStartFilm(reservationAndHerFilds.TimeStartFilm));
            }
            //Добавляем на существующую(ту которую указал пользователь) дату новый фильм
            else if (CheckReservationSessionInThisDay(bookList, reservationAndHerFilds.ReservationSession))
            {
                bookList[indexValue].Films.Add(
                    new NameFilm(reservationAndHerFilds.Dates.Date.Movies.Movie[reservationAndHerFilds.IndexNameFilm].Name,
                    new List<TimeStartFilm> {
                        new TimeStartFilm(reservationAndHerFilds.TimeStartFilm) }));
            }
            this.parser.Serialize(bookList, GlobalConstant.GetPathBookInfo());
        }       
        private int GetIndexSessionInThisDay(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
                for (int i = 0; i < allReservationSessions.Count; i++)
                {
                    if (allReservationSessions[i].Value == bookNow.Value)
                        return i;
                }
                return -1;
        }
        private int GetIndexSessionOnThisMovie(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
                for (int i = 0; i < allReservationSessions.Count; i++)
                {
                    if (allReservationSessions[i].Value == bookNow.Value)
                        for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                            if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                                return j;
                }
                return -1;
        }


        private bool CheckReservationSessionOnThisMovie(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                    for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                        if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                            return true;
            }
            return false;
        }
        private bool CheckReservationSessionInThisDay(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                    return true;
            }
            return false;
        }


    }
}
