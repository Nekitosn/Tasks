using System;

namespace Box
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Fighter sanya = new Fighter("Sanya", 228, 69);
            Fighter oleg = new Fighter("Oleg", 322, 33);

            Fighter.Fight(sanya, oleg, rand.Next(0, 2));
        }
    }
}
