using FileXML;
using System;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class ResetAllBookedSessions : ICommandos
    {
        //Нужно сделать так чтоб он принимал 1 параметр, это путь к файлу, который мы очистим
        private string path {  get; set; }

        public ResetAllBookedSessions(string pathToReset)
        {
            this.path = pathToReset;
        }
        public void Execute()
        {
            File.WriteAllText(path, String.Empty);
        }
    }
}
