using System.IO;

namespace FileXML
{
    public static class GlobalConstant
    {
        public static string GetPathCinema()
        {

            return System.Configuration.ConfigurationSettings.AppSettings["path"];
        }
        public static string GetFullPathCinema()
        {
            return Directory.GetCurrentDirectory() + @"\"+ GetPathCinema();
        }
    }
}
