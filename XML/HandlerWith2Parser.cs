using System;
using System.IO;
using XML;
using XML.Interfaces;

namespace FileXML
{
    public class HandlerWith2Parser
    {
        private DefaultXMLFile createrFile;
        private IWatcher watcher;
        private DisplayAllSession displayerAll;
        private DisplayReservation displayerBooked;
        private BookWith2Parser book;


        private readonly IParser reading;
        private readonly IParser recording;

        public HandlerWith2Parser(IParser reading, IParser recording, IWatcher watcher)
        {
            this.reading = reading;
            this.recording = recording;
            this.watcher = watcher;
            this.createrFile = new(this.reading);
            this.displayerAll = new(this.reading);
            this.displayerBooked = new(this.recording);
            this.book = new(this.reading, this.recording);
        }
        public void Start()
        {
            //Создаеться xml файл как в примере
            this.createrFile.CreateDefaultXml();

            //Слежение за изменением xml файлом
            this.watcher.Watch();

            this.displayerAll.Display();

            this.GetChoice();
        }

        private void GetChoice()
        {
            bool repeate = true;
            while (repeate)
            {
                this.displayerAll.DisplayCommandOnConsole();
                string choiceTry = Console.ReadLine();
                bool normalin = int.TryParse(choiceTry, out int choice);
                if (normalin)
                {
                    switch (choice)
                    {
                        case 1:
                            this.book.BookSession();
                            break;
                        case 2:
                            this.displayerBooked.Display();
                            break;
                        case 3:
                            this.displayerAll.Display();
                            break;
                        case 4:
                            File.WriteAllText(GlobalConstant.GetPathBookInfo(), String.Empty);
                            break;
                        case 5:
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
