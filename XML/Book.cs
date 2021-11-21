using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace FileXML
{
    public class Book
    {
        private IParser parser;

        private List<Dates> datesList;

        public Book(IParser parser)
        {
            this.parser = parser;

            this.datesList = this.parser.Deserialize<Dates>(GlobalConstant.GetPathCinema());
        }

        public void BookSession(List<ReservationSession> bookList)
        {
            try
            {
                ExistSession(out Dates dates, out int indexNameFilm, out string timeStartFilm);
                if (CheckingReservation(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm)))//Если данный сеанс уже забронирован
                {
                    Console.WriteLine("This session is already booked\n"); return;
                }
                else
                {
                    Booked(bookList, dates, indexNameFilm, timeStartFilm);
                    Console.WriteLine($"You have booked a session\n");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return; }
        }

        private bool ExistSession(out Dates dates, out int indexNameFilm, out string timeStartFilm)
        {

            dates = ExistsValue(datesList);
            if (dates == null) throw new Exception("There is no schedule for this date\n");
            indexNameFilm = ExistsFilm(dates);
            if (indexNameFilm == -1) throw new Exception("In this date of this movie is not\n");
            timeStartFilm = ExistsTime(dates, indexNameFilm);
            if (timeStartFilm == string.Empty) throw new Exception("There are no sessions at this time\n");

            return true;
        }

        private void Booked(List<ReservationSession> bookList, Dates dates, int indexNameFilm, string timeStartFilm)
        {
            int indexReservationNameFilm = GetIndexSessionOnThisMovie(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm));
            int indexValue = GetIndexSessionInThisDay(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm));

            ReservationSession reservationSession = new(dates, indexNameFilm, timeStartFilm);

            //Добавляем на существующую(ту которую указал пользователь) дату, на существующий фильм новое время
            if (CheckReservationSessionOnThisMovie(bookList, reservationSession))
            {
                bookList[indexValue].Films[indexReservationNameFilm].Times.Add(new TimeStartFilm(timeStartFilm));
                return;
            }
            //Добавляем на существующую(ту которую указал пользователь) дату новый фильм
            else if (CheckReservationSessionInThisDay(bookList, reservationSession))
            {
                bookList[indexValue].Films.Add(new NameFilm(dates.Date.Movies.Movie[indexNameFilm].Name, new List<TimeStartFilm> { new TimeStartFilm(timeStartFilm) }));
                return;
            }
            //Добавляем новую дату со всеми вытекающими
            else
            {
                bookList.Add(reservationSession);
                return;
            }
        }

        private bool CheckingReservation(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
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
        private bool CheckReservationSessionInThisDay(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                    return true;
            }
            return false;
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
        private Dates ExistsValue(List<Dates> allSessions)
        {
            Console.WriteLine("Specify the date when you want to purchase a ticket: ");
            try
            {
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                for (int i = 0; i < allSessions.Count; i++)
                {
                    if (date == allSessions[i].Date.Value)
                        return allSessions[i];
                }

                return null;
            }
            catch
            {
                Console.WriteLine("Enter the date in the format 2020 01 28 (year month day)\n");
                return null;
            }
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

    }
}
