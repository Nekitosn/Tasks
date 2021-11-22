using XML;

namespace FileXML
{
    class Program
    {
        static void Main()
        {
            Handler handler = new(
                new SerializeXML(),
                new Watcher(new SerializeXML()));
            handler.Start();
        }

    }
}

