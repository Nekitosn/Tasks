using System;
using System.Collections.Generic;
using XML;

namespace FileXML
{
    public class Handler 
    {
        private DefaultXMLFile create;
        private Watcher watch;
        private Display display;
        public void Start()
        {
            create = new();
            watch = new();
            display = new();

            //Создаеться xml файл как в примере
            create.CreateDefaultXml();

            //Слежение за изменением xml файлом
            watch.Watch(GlobalConstant.GetPathCinema());

            display.DisplayAll();

            GetChoice();
        }

        private void GetChoice()
        {
            display = new();
            List<ReservationSession> bookList = new();
            bool repeate = true;
            while (repeate)
            {
                display.DisplayCommandOnConsole();
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
                            display.DisplayReserved(bookList);
                            break;
                        case 3:
                            display.DisplayAll();
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

    }
   
}
