using FileXML;
using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML
{
    public class Display
    {
        private IParser parser;

        public Display(IParser parser)
        {
            this.parser = parser;
        }

        public void DisplayCommandOnConsole()
        {
            Console.WriteLine("Commands:\n" +
                     "1.Book a session\n" +
                     "2.List of booked sessions\n" +
                     "3.Display all\n" +
                     "4.Exit the program\n");
        }
        public void DisplayAll()
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

        public void DisplayReserved(List<ReservationSession> list)
        {
            Console.WriteLine("Booked sessions::");
            if (list.Count == 0)
                Console.WriteLine("There are no booked sessions yet\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{list[i].Value.Day} {list[i].Value.Month} {list[i].Value.DayOfWeek}");
                for (int j = 0; j < list[i].Films.Count; j++)
                {
                    Console.Write($"   {list[i].Films[j].Film}");

                    for (int k = 0; k < list[i].Films[j].Times.Count; k++)
                        Console.Write($"\t{list[i].Films[j].Times[k].Time}");
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }
    }
}
