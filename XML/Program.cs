using XML;
using XML.Json;

namespace FileXML
{
    class Program
    {
        static void Main()
        {

            Handler handler = new(
                new SerializeJSON(),
                new Watcher(new SerializeXML()));
            handler.Start();
        }

    }
}

