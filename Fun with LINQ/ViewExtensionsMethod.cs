using System;
using System.Collections.Generic;

namespace Fun_with_LINQ;

public class ViewExtensionsMethod
{
    public void Start(List<Customer> customers)
    {
        Console.WriteLine("Our List: ");
        PrintFieldsCustomer(customers);

        Console.WriteLine("Oldest Customers in our list:");
        PrintFieldsCustomer(customers.SearchTheOldestCustomer());
        Console.WriteLine("Youngest Customer in our list:");
        PrintFieldsCustomer(customers.SearchTheYoungestCustomer());

        Console.WriteLine($"Avarage balance all customers: {customers.AverageAllBalance()}");

        Console.WriteLine("\nCustomers who fit the data register criteria:");
        PrintFieldsCustomer(customers.SortByRegisterDate(new DateTime(2017, 7, 1), new DateTime(2021, 5, 12)));

        Console.WriteLine("Customers who fit the Id critaria:");
        PrintFieldsCustomer(customers.SortById(x => x % 2 == 0));

        Console.WriteLine($"Customers who have a part 'Luc' in their name: ");
        PrintFieldsCustomer(customers.FilterBySubString("Luc"));

        Console.WriteLine("Order customers by months and then by name: ");
        PrintFieldsCustomer(customers.GroupByMonths());

        Console.WriteLine($"All name customers через запятую");
        customers.DisplayAllName();

        Console.WriteLine($"\n\nAll name customers через запятую2:\n {customers.GetAllName()}");
    }
    public static void PrintFieldsCustomer(Customer customer) =>
        Console.WriteLine($"Id: {customer.Id}\tName: {customer.Name}\tData register: {customer.RegistrationDate}\tBalance: {customer.Balance}" + Environment.NewLine);

    public static void PrintFieldsCustomer(List<Customer> custArray)
    {
        if (custArray.Count == 0)
        {
            Console.WriteLine("No result");
            return;
        }
        custArray.ForEach(x => PrintFieldsCustomer(x));

        Console.WriteLine(Environment.NewLine + Environment.NewLine);
    }
}

