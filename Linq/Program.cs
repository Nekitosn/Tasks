using System;
using System.Collections.Generic;

namespace Customers_GitHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Silvia Stefano", new DateTime(2017, 7, 25), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Tawana Shope", new DateTime(2017, 7, 11), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };

            var test = new HandlerCustomer();
            test.Start(customers);

        }

    }
}