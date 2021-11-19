using System;

namespace Input_and_handler.FileTypes
{
    public class Movie : File
    {
        private string Resolution { get; set; }
        private string Length { get; set; }
        private static int CountCallsDisplay { get; set; }
        public override void Display()
        {
            if (CountCallsDisplay == 0)   //Если мы раннее не вызывали вывод у нас выведет заголовок
                Console.WriteLine("Movie:");
            CountCallsDisplay++;

            Console.WriteLine($"\t{Name}\n" +
                $"\t\tExtension: {Extension}\n" +
                $"\t\tSize: {Size}\n" +
                $"\t\tResolution: {Resolution}\n" +
                $"\t\tLength: {Length}");
        }

        public override File GetFileInfo(string str)
        {
            base.GetFileInfo(str);

            this.Resolution = this.GetResolutionInStr(str);

            this.Length = this.GetLengthInStr(str);

            return this;
        }

        private string GetResolutionInStr(string str)
        {
            str = str.Trim().Remove(0, str.IndexOf(";") + 1);
            str = str.Remove(str.IndexOf(";"));
            return str;
        }
        private string GetLengthInStr(string str)
        {
            str = str.Trim().Remove(0, str.LastIndexOf(";") + 1);
            return str;
        }
    }
}


