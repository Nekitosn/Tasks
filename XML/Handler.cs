using System;
using System.Collections.Generic;
using SimpleInjector;
using XML;
using XML.Interfaces;

namespace FileXML
{
    public class Handler
    {
        private static Container container;


        //private DisplayAllSession displayerAll;
        //private DisplayReservation displayerBooked;
        //private DisplayComandOnConsole displayerComandOnConsole;
        //private Book book;
        //private ResetAllBookedSessions cleanerAllBookedSessions;
        //private DefaultFile createrFile;
        //private DefaultBookFile createrBookFile;

        private readonly Dictionary<int, Action> command;

        private readonly IWatcher watcher;
        private readonly IParser parser;

        //private DisplayAllSession displayerAll;
        //private DisplayReservation displayerBooked;
        //private DisplayComandOnConsole displayerComandOnConsole;
        //private Book book;
        //private ResetAllBookedSessions cleanerAllBookedSessions;
        //private DefaultFile createrFile;
        //private DefaultBookFile createrBookFile;
        static Handler()
        {
            container = new Container();

            container.Collection.Register<ICommandos>(
                typeof(Book),
                typeof(DisplayAllSession),
                typeof(DisplayComandOnConsole),
                typeof(DisplayReservation),
                typeof(ResetAllBookedSessions)
                );
            
            container.Collection.Register<IParser>(
                typeof(DisplayAllSession),
                typeof(DisplayReservation),
                typeof(DisplayComandOnConsole),
                typeof(Book),
                typeof(ResetAllBookedSessions),
                typeof(DefaultFile),
                typeof(DefaultBookFile)
                );

            container.RegisterInstance<IParser>(new SerializeXML());
            container.Verify();
        }
        public Handler(IParser parser, IWatcher watcher)
        {
            //this.parser = parser;
            //this.createrFile = new(this.parser);
            //this.createrBookFile = new(this.parser);
            //this.displayerAll = new(this.parser);
            //this.displayerBooked = new(this.parser);
            //this.displayerComandOnConsole = new(this.parser);
            //this.book = new(this.parser);
            //this.cleanerAllBookedSessions = new(GlobalConstant.GetPathBookInfo());
            //this.watcher = watcher;
            this.parser = parser;
            this.watcher = watcher;

            //this.displayerAll = container.GetInstance<DisplayAllSession>();
            //this.displayerBooked = container.GetInstance<DisplayReservation>();
            //this.displayerComandOnConsole = container.GetInstance<DisplayComandOnConsole>();
            //this.book = container.GetInstance<Book>();
            //this.cleanerAllBookedSessions = container.GetInstance<ResetAllBookedSessions>();
            //this.createrFile = container.GetInstance<DefaultFile>();
            //this.createrBookFile = container.GetInstance<DefaultBookFile>();

            var displayerAll = container.GetInstance<DisplayAllSession>();
            var displayerBooked = container.GetInstance<DisplayReservation>();
            var displayerComandOnConsole = container.GetInstance<DisplayComandOnConsole>();
            var book = container.GetInstance<Book>();
            var cleanerAllBookedSessions = container.GetInstance<ResetAllBookedSessions>();
            var createrFile = container.GetInstance<DefaultFile>();
            var createrBookFile = container.GetInstance<DefaultBookFile>();

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

            //this.displayerAll.Execute();

            this.GetChoice();
        }

        private void GetChoice()
        {
            while (true)
            {
                //this.displayerComandOnConsole.Execute();
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

