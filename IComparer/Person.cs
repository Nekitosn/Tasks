using System;
using System.Collections.Generic;

namespace SortIComparer_
{
    class Person
    {
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private int _day;
        private int _month;
        private int _year;

        public Person() { }
        public Person(string FirstName, string MiddleName, string LastName, byte Day, byte Month, int Year) { this._firstName = FirstName; this._middleName = MiddleName; this._lastName = LastName; this._day = Day; this._month = Month; this._year = Year; }

        public string FirstName { get { return _firstName; } }
        public string MiddleName { get { return _middleName; } }
        public string LastName { get { return _lastName; } }
        public int Day { get { return _day; } }
        public int Month { get { return _month; } }
        public int Year { get { return _year; } }
        public void Initialization()
        {
            Console.Write("Enter FirstName: ");
            _firstName = Console.ReadLine();

            Console.Write("Enter LastName: ");
            _lastName = Console.ReadLine();

            Console.Write("Enter MiddleName: ");
            _middleName = Console.ReadLine();

            Console.Write("Enter Day: ");
            _day = byte.Parse(Console.ReadLine());

            Console.Write("Enter Month: ");
            _month = byte.Parse(Console.ReadLine());

            Console.Write("Enter Year: ");
            _year = int.Parse(Console.ReadLine());

        }
        public void Print()
        {
            PrintOnePerson();
        }

        private void PrintOnePerson()
        {
            Console.WriteLine($"{_firstName} {_middleName} {_lastName}\t{_day}.{_month}.{_year}");
        }

        public static void NameComparer(List<Person> persons)
        {
            persons.Sort(
                delegate (Person x, Person y)
                {
                    int resultFirstName = String.Compare(x.FirstName, y.FirstName);
                    if (resultFirstName < 0)
                        return -1;
                    else if (resultFirstName == 0)
                    {
                        int resultMiddleName = String.Compare(x.MiddleName, y.MiddleName);
                        if (resultMiddleName < 0)
                            return -1;
                        else if (resultMiddleName == 0)
                        {
                            int resultLastName = string.Compare(x.LastName, y.LastName);
                            if (resultLastName < 0)
                                return -1;
                            else if (resultFirstName == 0)
                                return 0;
                            else
                                return 1;
                        }
                        else
                            return 1;
                    }
                    else
                        return 1;
                });
        }


        /// <summary>
        /// Изначально сортируется от наимладшего до наистаршего, если хотите от наистаршего к наимладшему то аргументом передайте:  -1 
        /// </summary>
        public static void AgeComparer(List<Person> persons, int mode = 1)
        {
            if (mode == 1 || mode == -1)
            {
                persons.Sort(
                    delegate (Person x, Person y)
                    {
                        if (x.Year > y.Year)
                            return mode * (-1);
                        else if (x.Year == y.Year)
                        {
                            if (x.Month > y.Month)
                                return mode * (-1);
                            else if (x.Month == y.Month)
                            {
                                if (x.Day > y.Day)
                                    return mode * (-1);
                                else if (x.Day == y.Day)
                                    return 0;
                                else
                                    return mode * (1);
                            }
                            else
                                return mode * (1);
                        }
                        else
                            return mode * (1);
                    });
            }
        }


    }
}



