using System.IO;

namespace FileXML
{
    public static class GlobalConstant
    {
        public static string GetPathCinema()
        {

            return System.Configuration.ConfigurationSettings.AppSettings["pathToCinema"];
        }
        public static string GetFullPathCinema()
        {
            return Directory.GetCurrentDirectory() + @"\"+ GetPathCinema();
        }
        public static string GetPathBookInfo()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["pathToBookInfo"];
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


        //public static int GetCountKeyInDictionary<T>(T dickionary) 
        //{
        //    retur;
        //}
    }
}
