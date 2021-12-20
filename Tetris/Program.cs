using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field start = new Field();
            for (int i = 0; i < 120; i++)
            {
                Console.Clear();
                start.Excute();
            }
           

        }
    }
}
