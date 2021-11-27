using System;
using System.Collections.Generic;
using XML;
using XML.Interfaces;

namespace FileXML
{
    public class Handler
    {
        private DefaultFile createrFile;
        private DefaultBookFile createrBookFile;
        private IWatcher watcher;
        private DisplayAllSession displayerAll;
        private DisplayReservation displayerBooked;
        private DisplayComandOnConsole displayerComandOnConsole;
        private Book book;
        private ResetAllBookedSessions cleanerAllBookedSessions;
        

        private readonly Dictionary<int, Action> command; 

        private readonly IParser parser;

        public Handler(IParser parser, IWatcher watcher)
        {
            this.parser = parser;
            this.createrFile = new(this.parser);
            this.createrBookFile = new(this.parser);
            this.displayerAll = new(this.parser);
            this.displayerBooked = new(this.parser);
            this.displayerComandOnConsole = new(this.parser);
            this.book = new(this.parser);
            this.cleanerAllBookedSessions = new(GlobalConstant.GetPathBookInfo());
            this.watcher = watcher;

            this.command = new Dictionary<int, Action>()
            {
                {1,()=>book.Execute() },
                {2,()=>displayerBooked.Execute() },
                {3,()=>displayerAll.Execute() },
                {4,()=>cleanerAllBookedSessions.Execute() }
            };
        }
        public void Start()
        {
            this.watcher.Watch();

            this.displayerAll.Execute();

            this.GetChoice();
        }

        private void GetChoice()
        {
            while (true)
            {
                this.displayerComandOnConsole.Execute();
                string choiceTry = Console.ReadLine();
                bool normalin = int.TryParse(choiceTry, out int choice);
                if (normalin && choice>=0 && choice <= command.Count+1)
                {
                    if (choice == command.Count + 1)
                        break;

                    command[choice]();
                }
                else
                    Console.WriteLine("Check the spelling");

            }
            Console.WriteLine("Exit the program\n");
        }
    }

}

