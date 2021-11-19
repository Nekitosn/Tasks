using System;

namespace Input_and_handler.FileTypes
{
    public class Image : File
    {
        private string Resolution { get; set; }
        private static int CountCallsDisplay { get; set; }
        public override void Display()
        {
            if (CountCallsDisplay == 0)   //Если мы раннее не вызывали вывод у нас выведет заголовок
                Console.WriteLine("Image:");
            CountCallsDisplay++;

            Console.WriteLine($"\t{Name}\n" +
            $"\t\tExtension: {Extension}\n" +
            $"\t\tSize: {Size}\n" +
            $"\t\tResolution: {Resolution}\n");
        }
        public override File GetFileInfo(string str)
        {
            base.GetFileInfo(str);

            this.Resolution = this.GetResolutionInStr(str);

            return this;
        }
        private string GetResolutionInStr(string str)
        {
            return str.Trim().Remove(0, str.IndexOf(";") + 1);
        }
    }
}
