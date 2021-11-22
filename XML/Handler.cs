using System;
using System.Collections.Generic;
using XML;
using XML.Interfaces;

namespace FileXML
{
    public class Handler
    {
        private DefaultXMLFile createrFile;
        private IWatcher watcher;
        private Display displayer;

        private Book book;

        private readonly IParser parser;

        public Handler(IParser parser, IWatcher watcher)
        {
            this.parser = parser;
            this.watcher = watcher;
            this.createrFile = new(this.parser);            
            this.displayer = new(this.parser);
            this.book = new(this.parser);
        }
        public void Start()
        {
            //Создаеться xml файл как в примере
            this.createrFile.CreateDefaultXml();

            //Слежение за изменением xml файлом
            this.watcher.Watch();

            this.displayer.DisplayAll();

            this.GetChoice();
        }

        private void GetChoice()
        {
            List<ReservationSession> bookList = new();
            bool repeate = true;
            while (repeate)
            {
                this.displayer.DisplayCommandOnConsole();
                string choiceTry = Console.ReadLine();
                bool normalin = int.TryParse(choiceTry, out int choice);
                if (normalin)
                {
                    switch (choice)
                    {
                        case 1:                            
                            this.book.BookSession(bookList);
                            break;
                        case 2:
                            this.displayer.DisplayReserved(bookList);
                            break;
                        case 3:
                            this.displayer.DisplayAll();
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
