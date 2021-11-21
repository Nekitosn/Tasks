using System;

namespace FileXML
{
    class Program
    {
        static void Main()
        {
            Handler handler = new(new SerializeXML());
            handler.Start();
        }

    }
}

