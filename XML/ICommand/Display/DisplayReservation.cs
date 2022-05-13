using FileXML;
using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML
{
    public class DisplayReservation : ICommand
    {
        private IParser parser;

        public DisplayReservation(IParser parser)
        {
            this.parser = parser;
        }

        public  void Execute()
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
