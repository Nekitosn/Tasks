using XML;
using XML.Factoryes;
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
            container.Register<IWatcher, Watcher>();
            container.Register<IParser, SerializeJSON>();
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

