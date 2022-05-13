using System;

namespace Fun_with_LINQ;

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
}

