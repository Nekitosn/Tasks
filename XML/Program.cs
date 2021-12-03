using XML;
using XML.Interfaces;
using SimpleInjector;

namespace FileXML
{
    class Program
    {
        private static  Container container; 
       
        static Program()
        {
            container = new Container();
            container.Register<IParser, SerializeJSON>();
            container.Register<IWatcher, Watcher>();
            container.Register<Handler>();
            container.Verify();

        }
        static void Main()
        {
            var handler = container.GetInstance<Handler>();

            handler.Start();
        }

    }
}

