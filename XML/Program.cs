using XML;
using XML.Interfaces;
using SimpleInjector;
using System;
using SQL;
using System.Collections.Generic;


namespace FileXML
{
    class Program
    {
        private static  Container container;

        //static Program()
        //{
        //    container = new Container();
        //    container.Register<IParser, SerializeJSON>();
        //    container.Register<IWatcher, Watcher>();
        //    container.Register<Handler>();
        //    container.Verify();

        //}
        static void Main()
        {
            //var handler = container.GetInstance<Handler>();

            //handler.Start();
            using (DatesContext db = new DatesContext())
            {
                //создаем три объекта Dates
                Dates dates1 = new(new Date(new DateTime(2019, 02, 25), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("051eaee5-0bc5-43f4-8435-20e3498083cc", "Invincible", new Sessions(new List<Session> { new Session("10:00") })) })));
                Dates dates2 = new(new Date(new DateTime(2019, 02, 26), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("10:30"), new Session("19:00") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Doctor Strange", new Sessions(new List<Session> { new Session("15:15"), new Session("18:10"), new Session("20:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Sex in a village", new Sessions(new List<Session> { new Session("11:30"), new Session("16:45") })) })));
                Dates dates3 = new(new Date(new DateTime(2019, 02, 28), new Movies(new List<Movie> { new Movie("ed0c5c20-4259-4b09-823a-1a6531221060", "Deadpool 2", new Sessions(new List<Session> { new Session("11:30") })), new Movie("22d41e99-6a1b-4d1b-9adf-dd6fbba3835b", "Sex in a village", new Sessions(new List<Session> { new Session("13:25"), new Session("17:20") })), new Movie("01683097-397e-4cfe-9dbf-40b73a8b2b43", "Doctor Strange", new Sessions(new List<Session> { new Session("12:00"), new Session("17:00") })) })));


                //добавляем их в бд
                db.Dates.Add(dates1);
                db.Dates.Add(dates2);
                db.Dates.Add(dates3);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                //получаем объекты из бд и выводим на консоль
                var dates = db.Dates;
                Console.WriteLine("Список объектов:");
                foreach (Dates u in dates)
                {
                    Console.WriteLine("1");
                }
            }
        }

    }
}

