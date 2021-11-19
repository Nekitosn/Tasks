namespace fileXML
{
    public static class GlobalConstant
    {
        public static string GetPathCinema()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["path"];
        }
        public static string GetFullPathCinema()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["fullPath"];
        }
    }
}
