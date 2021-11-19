using System;
using System.Collections.Generic;

namespace fileXML
{
    public class Book
    {

        public void BookSession(List<ReservationSession> bookList)
        {
            SerializeOrDesirializeXML s = new();
            List<Dates> datesList = s.DeserializeXML<Dates>();

            while (true)
            {
                Dates dates = ExistsValue(datesList);
                if (dates == null) { Console.WriteLine("There is no schedule for this date\n"); break; }
                int indexNameFilm = ExistsFilm(dates);
                if (indexNameFilm == -1) { Console.WriteLine("In this date of this movie is not\n"); break; }
                string timeStartFilm = ExistsTime(dates, indexNameFilm);
                if (timeStartFilm == null) { Console.WriteLine("There are no sessions at this time\n"); break; }

                //Чтоб цикл не делал бесмысленную роботу сразу смотрим, забронирован ли уже данный сеанс
                if (CheckingReservation(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm)))
                {
                    //Если данный сеанс уже забронирован
                    Console.WriteLine("This senas is already booked\n"); break;
                }

                int indexReservationNameFilm = GetIndexSessionOnThisMovie(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm));
                int indexValue = GetIndexSessionInThisDay(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm));

                if (CheckReservationSessionOnThisMovie(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm)))
                {
                    //Добавляем на существующую(ту которую указал пользователь) дату, на существующий фильм новое время
                    bookList[indexValue].Films[indexReservationNameFilm].Times.Add(new TimeStartFilm(timeStartFilm));
                    Console.WriteLine($"You have booked a session\n"); break;
                }
                else if (CheckReservationSessionInThisDay(bookList, new ReservationSession(dates, indexNameFilm, timeStartFilm)))
                {
                    //Добавляем на существующую(ту которую указал пользователь) дату новый фильм
                    bookList[indexValue].Films.Add(new NameFilm(dates.Date.Movies.Movie[indexNameFilm].Name, new List<TimeStartFilm> { new TimeStartFilm(timeStartFilm) }));
                    Console.WriteLine($"You have booked a session\n"); break;
                }
                else   //Добавляем новую дату со всеми вытекающими
                {
                    bookList.Add(new ReservationSession(dates, indexNameFilm, timeStartFilm));
                    Console.WriteLine($"You have booked a session\n"); break;
                }

            }
        }

        private bool CheckingReservation(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            bool coincide = false;
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (coincide)
                    break;
                if (allReservationSessions[i].Value == bookNow.Value)
                    for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                        if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                            for (int k = 0; k < allReservationSessions[i].Films[j].Times.Count; k++)
                                if (allReservationSessions[i].Films[j].Times[k].Time == bookNow.Films[0].Times[0].Time)
                                    coincide = true;
            }
            return coincide;
        }
        private bool CheckReservationSessionInThisDay(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            bool coincide = false;
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (coincide)
                    break;
                if (allReservationSessions[i].Value == bookNow.Value)
                    coincide = true;
            }
            return coincide;
        }
        private int GetIndexSessionInThisDay(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            int coincide = -1;
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                {
                    coincide = i;
                    break;
                }
            }
            return coincide;
        }
        private bool CheckReservationSessionOnThisMovie(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            bool coincide = false;
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (coincide)
                    break;
                if (allReservationSessions[i].Value == bookNow.Value)
                    for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                        if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                            coincide = true;
            }
            return coincide;
        }
        private int GetIndexSessionOnThisMovie(List<ReservationSession> allReservationSessions, ReservationSession bookNow)
        {
            int coincide = -1;
            for (int i = 0; i < allReservationSessions.Count; i++)
            {
                if (allReservationSessions[i].Value == bookNow.Value)
                    for (int j = 0; j < allReservationSessions[i].Films.Count; j++)
                        if (allReservationSessions[i].Films[j].Film == bookNow.Films[0].Film)
                        {
                            coincide = j;
                            break;
                        }

            }
            return coincide;
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

            return null;
        }

    }
}
