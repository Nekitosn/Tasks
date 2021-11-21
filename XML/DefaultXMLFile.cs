using FileXML;
using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML
{
    public class DefaultXMLFile
    {
        private IParser parser;


        public DefaultXMLFile(IParser parser)
        {
            this.parser = parser;
        }
        public void CreateDefaultXml()
        {
            //Создание xml файла как в примере
            Dates dates1 = new(new Date(new DateTime(2019, 02, 25), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("051eaee5-0bc5-43f4-8435-20e3498083cc", "Invincible", new Sessions(new List<Session> { new Session("10:00") })) })));
            Dates dates2 = new(new Date(new DateTime(2019, 02, 26), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Doctor Strange", new Sessions(new List<Session> { new Session("15:15"), new Session("18:10"), new Session("20:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Sex in a village", new Sessions(new List<Session> { new Session("11:30"), new Session("16:45") })) })));
            Dates dates3 = new(new Date(new DateTime(2019, 02, 28), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("11:30") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Sex in a village", new Sessions(new List<Session> { new Session("13:25"), new Session("17:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Doctor Strange", new Sessions(new List<Session> { new Session("12:00"), new Session("17:00") })) })));
            List<Dates> dates = new() { dates1, dates2, dates3 };
            this.parser.Serialize(dates, GlobalConstant.GetPathCinema());
        }
    }
}
