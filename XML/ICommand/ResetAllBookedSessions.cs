using FileXML;
using System;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class ResetAllBookedSessions : ICommand
    {
        public void Execute()
        {
            File.WriteAllText(GlobalConstant.GetPathBookInfo(), String.Empty);
        }
    }
}

