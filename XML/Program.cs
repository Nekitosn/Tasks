using XML;
using XML.Factoryes;

namespace FileXML
{
    class Program
    {
        static void Main()
        {
            // Когда у нас 2 интерфейса IParser
            //Handler handler = new(
            //    SerializeFactory.ProduceSerialize(TypeSerializer.XML),
            //    SerializeFactory.ProduceSerialize(TypeSerializer.JSON),
            //    new Watcher(SerializeFactory.ProduceSerialize(TypeSerializer.XML)));


            Handler handler= new (
                SerializeFactory.ProduceSerialize(TypeSerializer.JSON),
                new Watcher(SerializeFactory.ProduceSerialize(TypeSerializer.JSON)));
            handler.Start();
        }

    }
}

