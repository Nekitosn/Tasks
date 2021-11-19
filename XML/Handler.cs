using fileXML.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace fileXML
{
    public class Handler : ICreateXmlDefaultFile, IDisplayAllSessions, IDisplayReservedSessions, IWatcher, IDisplayCommandOnConsole
    {
        public void Start()
        {
            //Создаеться xml файл как в примере
            CreateDefaultXml();

            //Слежение за изменением xml файлом
            Watch(GlobalConstant.GetFullPathCinema());

            DisplayAll();

            GetChoice();
        }



        private void GetChoice()
        {
            List<ReservationSession> bookList = new();
            bool repeate = true;
            while (repeate)
            {
                DisplayCommandOnConsole();
                string choiceTry = Console.ReadLine();
                bool normalin = int.TryParse(choiceTry, out int choice);
                if (normalin)
                {
                    switch (choice)
                    {
                        case 1:
                            Book book = new();
                            book.BookSession(bookList);
                            break;
                        case 2:
                            DisplayReserved(bookList);
                            break;
                        case 3:
                            DisplayAll();
                            break;
                        case 4:
                            Console.WriteLine("The program has completed its work");
                            repeate = false;
                            break;
                        default:
                            Console.WriteLine("This command does not exist");
                            break;
                    }
                }
                else
                    Console.WriteLine("Check the spelling");
            }
        }

        public void CreateDefaultXml()
        {
            //Создание xml файла как в примере
            Dates dates1 = new(new Date(new DateTime(2019, 02, 25), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("051eaee5-0bc5-43f4-8435-20e3498083cc", "Invincible", new Sessions(new List<Session> { new Session("10:00") })) })));
            Dates dates2 = new(new Date(new DateTime(2019, 02, 26), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Doctor Strange", new Sessions(new List<Session> { new Session("15:15"), new Session("18:10"), new Session("20:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Sex in a village", new Sessions(new List<Session> { new Session("11:30"), new Session("16:45") })) })));
            Dates dates3 = new(new Date(new DateTime(2019, 02, 28), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("11:30") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Sex in a village", new Sessions(new List<Session> { new Session("13:25"), new Session("17:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Doctor Strange", new Sessions(new List<Session> { new Session("12:00"), new Session("17:00") })) })));
            List<Dates> dates = new() { dates1, dates2, dates3 };
            SerializeOrDesirializeXML createXml = new();
            createXml.SerializeXML<Dates>(dates);
        }
        public void DisplayCommandOnConsole()
        {
            Console.WriteLine("Commands:\n" +
                     "1.Book a session\n" +
                     "2.List of booked sessions\n" +
                     "3.Exit the program\n");
        }
        public void DisplayAll()
        {
            SerializeOrDesirializeXML deserializeXml = new();
            List<Dates> dates = deserializeXml.DeserializeXML<Dates>();
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
        public void Watch(string path)
        {
            FileSystemWatcher watcher = new();
            watcher.Path = Path.GetDirectoryName(path);
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(WatcherChanged);
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.Clear();

            DisplayAll();
            DisplayCommandOnConsole();
        }

    }
}
