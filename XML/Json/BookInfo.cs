using FileXML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML.Interfaces;

namespace XML.Json
{
    public class BookInfo
    {
        public DateTime Date { get; set; }
        public string TimeStartFilm { get; set; }
        public string Name { get; set; }

    }

    public class BookJson
    {
        private IParser parser;

        private List<Dates> datesList;

        public BookJson(IParser parser)
        {
            this.parser = parser;

            this.datesList = this.parser.Deserialize<Dates>(GlobalConstant.GetPathCinema());
        }
        public void Start()
        {
            Dates dates1 = new(new Date(new DateTime(2019, 02, 25), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("051eaee5-0bc5-43f4-8435-20e3498083cc", "Invincible", new Sessions(new List<Session> { new Session("10:00") })) })));
            Dates dates2 = new(new Date(new DateTime(2019, 02, 26), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Doctor Strange", new Sessions(new List<Session> { new Session("15:15"), new Session("18:10"), new Session("20:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Sex in a village", new Sessions(new List<Session> { new Session("11:30"), new Session("16:45") })) })));
            Dates dates3 = new(new Date(new DateTime(2019, 02, 28), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("11:30") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Sex in a village", new Sessions(new List<Session> { new Session("13:25"), new Session("17:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Doctor Strange", new Sessions(new List<Session> { new Session("12:00"), new Session("17:00") })) })));
            List<Dates> dates = new() { dates1, dates2, dates3 };
            File.WriteAllText("BookInfo.json", JsonConvert.SerializeObject(dates, Formatting.Indented));
        }
        public void Start2()
        {
            BookInfo bookInfo = new BookInfo();
            string jsonData = JsonConvert.SerializeObject(bookInfo);
            var bookInfo2 = JsonConvert.DeserializeObject<BookInfo>(jsonData);


        }
        public void Start3()
        {
            var person = File.Exists("BookInfo.json") ? JsonConvert.DeserializeObject<BookInfo>(File.ReadAllText("BookInfo.json")) : new BookInfo
            {
                Date = new DateTime(DateTime.Now.Year),
                TimeStartFilm = "12:00",
                Name = "Doctor"
            };

            person.Name += " I";

            File.WriteAllText("BookInfo.json", JsonConvert.SerializeObject(person));

        }
        public void book()
        {
            Console.WriteLine();
        }

    }
}
   

