using System;
using System.Collections.Generic;
using System.Linq;

namespace Fun_with_LINQ;

public static class CustomerExtension
{
    //a.Найти потребителя, который зарегистрировался раньше/позжу всех
    public static Customer SearchTheOldestCustomer(this List<Customer> list) =>
        list.OrderBy(x => x.RegistrationDate)
            .First();
    public static Customer SearchTheYoungestCustomer(this List<Customer> list) =>
       list.OrderByDescending(x => x.RegistrationDate)
           .First();

    //b.Написать метод, который считает среднее арифметическое всех балансов всех потребителей
    public static int AverageAllBalance(this List<Customer> list) =>
        (int)list.Average(x => x.Balance);

    //c.Написать метод, который позволит фильтровать потребителей по дате регистрации (от X до Y). Если нет результата по фильтру - выводить сообщение "No results"
    public static List<Customer> SortByRegisterDate(this List<Customer> list, DateTime start, DateTime end) =>
        list.Where(x => x.RegistrationDate >= start && x.RegistrationDate <= end)
            .OrderBy(x => x.RegistrationDate)
            .ToList();

    //d.Написать метод, который позволяет фильтровать потребителей по Id-шникам
    public static List<Customer> SortById(this List<Customer> list, Predicate<long> pr) =>
        list.Where(x => pr(x.Id))
            .OrderBy(x => x.Id)
            .ToList();

    //e.Написать метод, который позволяет фильтровать потребителей по части имени не учитывая регистр
    public static List<Customer> FilterBySubString(this List<Customer> list, string subString) =>
        list.Where(x => x.Name.Contains(subString))
            .ToList();

    //f.Написать метод, который выведет на экран, в хронологическом порядке, потребителей которые зарегистрировались в один месяц, при этом в одной такой группе они должны быть отсортированы в алфавитном порядке
    public static List<Customer> GroupByMonths(this List<Customer> list) =>
        list.OrderBy(x => x.RegistrationDate.Month)
            .ThenBy(x => x.Name)
            .ToList();

    //h.  Написать метод, который выведет на экран имена всех потребителей в коллекции через запятую
    public static void DisplayAllName(this List<Customer> list)
    {
        Console.Write($"{list.Last().Name}");
        list.Skip(1)
            .ToList()
            .ForEach(x => Console.Write($", {x.Name}"));
        Console.WriteLine();
    }
    public static string GetAllName(this List<Customer> list)
    {
        var join = string.Join("", list.Select(x => $"{x.Name}, "));
        return join.Remove(join.LastIndexOf(','), 1);
    }
}

