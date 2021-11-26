using System;
using XML.Interfaces;

namespace XML
{
    public class DisplayComandOnConsole : ICommandos
    {
        private IParser parser;

        public DisplayComandOnConsole(IParser parser)
        {
            this.parser = parser;
        }
        public  void Execute()
        {
            Console.WriteLine("Commands:\n" +
           "1.Book a session\n" +
           "2.List of booked sessions\n" +
           "3.Display all\n" +
           "4.Reset all booked sessions\n" +
           "5.Exit the program\n");
        }
    }
}
