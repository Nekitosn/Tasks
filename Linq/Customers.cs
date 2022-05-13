using System;
using System.Collections.Generic;
using System.Linq;

namespace Customers_GitHub
{
    /*
        + a.Найти потребителя, который зарегистрировался раньше всех
        + b.Написать метод, который считает среднее арифметическое всех балансов всех потребителей
        + c.Написать метод, который позволит фильтровать потребителей по дате регистрации (от X до Y). Если нет результата по фильтру - выводить сообщение "No results"
        + d.Написать метод, который позволяет фильтровать потребителей по Id-шникам
        + e.Написать метод, который позволяет фильтровать потребителей по части имени не учитывая регистр
        + f.Написать метод, который выведет на экран, в хронологическом порядке, потребителей которые зарегистрировались в один месяц, при этом в одной такой группе они должны быть отсортированы в алфавитном порядке
    g.  Написать метод, который отсортирует потребителей по заданному полю и направлению (ascending, descending)[ремарка - рефлексия в помощь]
        + h.  Написать метод, который выведет на экран имена всех потребителей в коллекции через запятую
    */

    // definition of Customer:
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public double Balance { get; set; }

        public delegate bool DelegateIdFilter(long number);
        public Customer(long id, string name, DateTime registrationDate, double balance)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.Balance = balance;
        }

        //a.Найти потребителя, который зарегистрировался раньше всех
        public static List<Customer> GetYoungestCustomer(List<Customer> customers)
        {
            var youngerRegister = customers.OrderBy(x => x.RegistrationDate).Take(1);
            return youngerRegister.ToList();
        }
        public static List<Customer> GetEldestCustomer(List<Customer> customers)
        {
            return customers.OrderByDescending(x => x.RegistrationDate)
                            .Take(1)
                            .ToList();
        }


        //b.Написать метод, который считает среднее арифметическое всех балансов всех потребителей
        public static double GetAvarageBalance(List<Customer> customers)
        {
            return customers.Average(x => x.Balance);
        }


        //c.Написать метод, который позволит фильтровать потребителей по дате регистрации(от X до Y). Если нет результата по фильтру - выводить сообщение "No results"
        public static List<Customer> GetDataFilter(List<Customer> customers, DateTime reference_Date, DateTime end_Date)
        {
            var list = customers.Where(c => c.RegistrationDate >= reference_Date && c.RegistrationDate <= end_Date);
            return list.ToList();
        }


        //d.Написать метод, который позволяет фильтровать потребителей по Id-шникам
        public static List<Customer> GetIdFilter(List<Customer> customers, DelegateIdFilter delegateIdFilter)
        {
            var list = customers.Where(c => delegateIdFilter(c.Id));

            return list.ToList();
        }


        //e.Написать метод, который позволяет фильтровать потребителей по части имени не учитывая регистр
        public static List<Customer> GetFilterName(List<Customer> customers, string piece_name)
        {
            var list = from l in customers
                       let start = l.Name.ToUpper().IndexOf(piece_name.ToUpper())
                       where start != -1
                       select l;

            return list.ToList();
        }

        //f.Написать метод, который выведет на экран, в хронологическом порядке, потребителей которые зарегистрировались в один месяц, при этом в одной такой группе они должны быть отсортированы в алфавитном порядке
        public static List<Customer> GetChronological(List<Customer> customers, DateTime intresting)
        {
            var list = customers.Where(c => c.RegistrationDate.Month == intresting.Month && c.RegistrationDate.Year == intresting.Year);
            list = list.OrderBy(d => d.RegistrationDate).ThenBy(n => n.Name);
            return list.ToList();
        }


        //g.Написать метод, который отсортирует потребителей по заданному полю и направлению(ascending, descending)[ремарка - рефлексия в помощь]


        //h.Написать метод, который выведет на экран имена всех потребителей в коллекции через запятую
        public static void PrintNameCustomers(List<Customer> customers)
        {
            Console.Write("Имена всех наших потребителей: ");
            for (int i = 0; i < customers.Count; i++)
                Console.Write($"{customers[i].Name}, ");
            Console.WriteLine();
        }


        //Сортировка по дате регистрации от тех кто раньше загерестрировался до тех кто позже
        public static List<Customer> SortDateOlder(List<Customer> customers)
        {
            var list = customers.OrderBy(x => x.RegistrationDate);
            return list.ToList();
        }
        public static List<Customer> SortDateYounger(List<Customer> customers)
        {
            var list = customers.OrderByDescending(x => x.RegistrationDate);
            return list.ToList();
        }


    }
}