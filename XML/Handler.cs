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

        private readonly Dictionary<int, Action> command;
        private Dictionary<string, ICommand> classes;

        private readonly IWatcher watcher;

        //private readonly IParser parser;

        public Handler(IParser parser, IWatcher watcher)
        {
            container = new Container();

            container.RegisterInstance<IParser>(parser);
            container.Register<Book>();
            container.Register<DisplayComandOnConsole>();
            container.Register<DisplayAllSession>();
            container.Register<DisplayReservation>();
            container.Register<ResetAllBookedSessions>();
            container.Register<DefaultBookFile>();
            container.Register<DefaultFile>();

            container.Verify();

            this.watcher = watcher;
            //this.parser = parser;

            this.classes = new Dictionary<string, ICommand>()
            {
                {"displayerAll",container.GetInstance<DisplayAllSession>() },
                {"displayerBooked",container.GetInstance<DisplayReservation>() },
                {"displayerComandOnConsole",container.GetInstance<DisplayComandOnConsole>() },
                {"book",container.GetInstance<Book>() },
                {"cleanerAllBookedSessions",container.GetInstance<ResetAllBookedSessions>() },
                {"createrFile",container.GetInstance<DefaultFile>() },
                {"createrBookFile",container.GetInstance<DefaultBookFile>() },
            };

            this.command = new Dictionary<int, Action>()
            {
                {1,()=>classes["book"].Execute()},
                {2,()=>classes["displayerBooked"].Execute()},
                {3,()=>classes["displayerAll"].Execute()},
                {4,()=>classes["cleanerAllBookedSessions"].Execute()},
            };

        }
        public void Start()
        {
            this.watcher.Watch();

            //Display All
            this.classes["displayerAll"].Execute();

            this.GetChoice();
        }

        private void GetChoice()
        {
            while (true)
            {
                //Display Comand On Console
                this.classes["displayerComandOnConsole"].Execute();

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

