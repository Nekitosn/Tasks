using System;
using System.Collections.Generic;

namespace SortIComparer_
{
    public delegate List<T> SortIComparer<T>(List<T> list);
    class Handler
    {
        public Handler()
        {

            Random r = new Random();

            Console.Write("How many people you want to enter for information: ");
            byte kolvoPers = byte.Parse(Console.ReadLine());
            Console.WriteLine("You want to fill the array with random information, or manually");
            Console.WriteLine("If by random press 1, if manually 2: ");
            int choice = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            if (choice == 1)
            {
                for (int i = 0; i < kolvoPers; i++)
                {
                    persons.Add(new Person(RandName(r.Next(0, 28)), RandName(r.Next(0, 28)), RandName(r.Next(0, 28)), (byte)r.Next(1, 31), (byte)r.Next(1, 12), r.Next(2000, 2020)));
                }
            }

            else if (choice == 2)
            {
                for (int i = 0; i < kolvoPers; i++)
                {
                    persons.Add(new Person());
                }
                for (int i = 0; i < kolvoPers; i++)
                {
                    persons[i].Initialization();
                }
            }
            else
                Console.WriteLine("Slava what did you introduce?");


            Console.WriteLine("\n\nYour list:");
            for (int i = 0; i < kolvoPers; i++)
                persons[i].Print();


            Person.AgeComparer(persons, -1);
            Console.WriteLine("\n\nYour sorted list from oldest to youngest:\n");
            for (int i = 0; i < kolvoPers; i++)
                persons[i].Print();

            Person.AgeComparer(persons);
            Console.WriteLine("\n\nYour sorted list from youngest to oldest:\n");
            for (int i = 0; i < kolvoPers; i++)
                persons[i].Print();

            Person.NameComparer(persons);
            Console.WriteLine("\n\nYour  sort list alphabetically:\n");
            for (int i = 0; i < kolvoPers; i++)
                persons[i].Print();


        }
        private string RandName(int index)
        {
            var list = new List<string>() { "Leha", "Nikita", "Den", "Sanya", "Nek", "Albert", "Emil", "Polina", "Nastya", "Luda", "Oksana",
                "Iluha", "Nesteren", "Sedov", "Goliy", "Starcev", "Yrhenko", "Krivenko", "Krivchun", "Pokemon", "Indeec", "Cigan", "Indus",
                "Arab", "Pejon", "Traglod", "Ivan", "Kostyan"};

            return list[index];
        }

    }
}


