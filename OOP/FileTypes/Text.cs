using System;

namespace Input_and_handler.FileTypes
{
    public class Text : File
    {
        private string Content { get; set; }
        private static int CountCallsDisplay { get; set; }

        public override void Display()
        {
            if (CountCallsDisplay == 0)   //Если мы раннее не вызывали вывод у нас выведет заголовок
                Console.WriteLine("Text files:");
            CountCallsDisplay++;

            Console.WriteLine($"\t{Name}\n" +
            $"\t\tExtension: {Extension}\n" +
            $"\t\tSize: {Size}\n" +
            $"\t\tContent: {Content}\n");
        }

        public override File GetFileInfo(string str)
        {
            base.GetFileInfo(str);
            this.Content = this.GetContentInStr(str);

            return this;
        }

        private string GetContentInStr(string str)
        {
            return str.Trim().Remove(0, str.IndexOf(";") + 1);
        }

    }
}
