using XML;
using XML.Factoryes;
using XML.Interfaces;
using SimpleInjector;

namespace FileXML
{
    class Program
    {
        static Container container;

        //Не понимаю как оно работает, от слова вообще
        //static Program()
        //{
        //    container = new Container();
        //    //container.Register<IWatcher, Watcher>();

        //    container.Verify();
        //}
        static void Main()
        {
            Handler handler = new Handler(
                SerializeFactory.ProduceSerialize(TypeSerializer.XML),
                new Watcher(SerializeFactory.ProduceSerialize(TypeSerializer.XML)));

            handler.Start();
        }

    }
}

