using System;
using System.Collections.Generic;

namespace Customers_GitHub
{
    public class HandlerCustomer
    {

        //g.  Написать метод, который отсортирует потребителей по заданному полю и направлению (ascending, descending)[ремарка - рефлексия в помощь]
        public void Start(List<Customer> customers)
        {
            Console.WriteLine("Our List: ");
            PrintFieldsCustomer(customers);

            Console.WriteLine("YoungestC ustomers in our list:");
            PrintFieldsCustomer(Customer.GetYoungestCustomer(customers));
            Console.WriteLine("Eldest Customer in our list:");
            PrintFieldsCustomer(Customer.GetEldestCustomer(customers));
            Console.WriteLine($"Avarage balance all customers: {Customer.GetAvarageBalance(customers)}");
            Console.WriteLine("\nCustomers who fit the data register criteria:");
            PrintFieldsCustomer(Customer.GetDataFilter(customers, new DateTime(2017, 7, 1), new DateTime(2021, 5, 12)));
            Console.WriteLine("Customers who fit the Id critaria:");
            PrintFieldsCustomer(Customer.GetIdFilter(customers, x => x % 2 == 0));
            string part_name = "arg";
            Console.WriteLine($"Customers who have a part \"{part_name}\" in their name: ");
            PrintFieldsCustomer(Customer.GetFilterName(customers, part_name));
            Console.WriteLine("Customers who register in a given year and month:");
            PrintFieldsCustomer(Customer.GetChronological(customers, new DateTime(2017, 7, 1)));
            Console.WriteLine("Print all customers name who register: ");
            Customer.PrintNameCustomers(customers);
            Console.WriteLine("\n\nList Customers after Eldest Sort: ");
            PrintFieldsCustomer(Customer.SortDateOlder(customers));
            Console.WriteLine("List Customers after Younger Sort: ");
            PrintFieldsCustomer(Customer.SortDateYounger(customers));


        }
        public static void PrintFieldsCustomer(List<Customer> customers)
        {
            if (customers.Count != 0)
                for (int i = 0; i < customers.Count; i++)
                    Console.WriteLine($"Id: {customers[i].Id}\tName: {customers[i].Name}\tData register: {customers[i].RegistrationDate}\tBalance: {customers[i].Balance}");
            else
                Console.WriteLine("No result");

            Console.WriteLine("\n\n");
        }
    }
}