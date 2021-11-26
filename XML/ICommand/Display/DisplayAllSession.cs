using FileXML;
using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML
{
    public class DisplayAllSession: ICommandos
    {
        private IParser parser;

        public DisplayAllSession(IParser parser)
        {
            this.parser = parser;
        }
        public  void Execute()
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
    }
}
