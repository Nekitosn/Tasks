using System;

namespace Tetris
{
    public class Field : IWork
    {
        public void Excute()
        {
            //public static int GetWight() => 30;
            //public static int GetHeight() => 120;

            //public static int GetLeftField() => 53;
            //public static int GetRightField() => 67;
            //public static int GetDawnField() => 28;

            //System.Threading.Thread.Sleep(500);
            for (int i = 0; i < GlobalConstant.GetWight(); i++)
            {
                for (int j = 0; j < GlobalConstant.GetHeight(); j++)
                {
                    if (i == GlobalConstant.GetDawnField())
                    { 
                        if(j >= GlobalConstant.GetLeftField() || j <= GlobalConstant.GetRightField())
                        {
                            Console.Write("#");
                            continue;
                        }
                      
                    }
                    if(j == GlobalConstant.GetLeftField() || j == GlobalConstant.GetRightField())
                    {
                        Console.Write("#");
                        continue;
                    }

                    else
                        Console.Write(" ");
                }
            }
          
        }
    }
}
