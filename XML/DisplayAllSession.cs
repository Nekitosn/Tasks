using FileXML;
using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML
{
    public class DisplayAllSession
    {
        private IParser parser;

        public DisplayAllSession(IParser parser)
        {
            this.parser = parser;
        }

        public void DisplayCommandOnConsole()
        {
            Console.WriteLine("Commands:\n" +
                     "1.Book a session\n" +
                     "2.List of booked sessions\n" +
                     "3.Display all\n" +
                     "4.Reset all booked sessions\n" +
                     "5.Exit the program\n");
        }
        public void Display()
        {
            List<Dates> dates = this.parser.Deserialize<Dates>(GlobalConstant.GetPathCinema());
            foreach (Dates d in dates)
            {
                Console.WriteLine($"Date: {d.Date.Value}");
                for (int i = 0; i < d.Date.Movies.Movie.Count; i++)
                {
                    Console.Write($"\tName: {d.Date.Movies.Movie[i].Name}\t");
                    for (int j = 0; j < d.Date.Movies.Movie[i].Sessions.Session.Count; j++)
                    {
                        Console.Write($"\t{d.Date.Movies.Movie[i].Sessions.Session[j].Time}");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void DisplayReserved()
        {
            List<ReservationSession> bookList = this.parser.Deserialize<ReservationSession>(GlobalConstant.GetPathBookInfo());

            if (bookList == null) 
            {
                Console.WriteLine("There are no booked sessions yet\n");
                return;
            }

            Console.WriteLine("Booked sessions::");
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine($"{bookList[i].Value.Day} {bookList[i].Value.Month} {bookList[i].Value.DayOfWeek}");
                for (int j = 0; j < bookList[i].Films.Count; j++)
                {
                    Console.Write($"   {bookList[i].Films[j].Film}");

                    for (int k = 0; k < bookList[i].Films[j].Times.Count; k++)
                        Console.Write($"\t{bookList[i].Films[j].Times[k].Time}");
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }
    }
}
