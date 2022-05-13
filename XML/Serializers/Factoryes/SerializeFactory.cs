using FileXML;
using XML.Interfaces;

namespace XML.Factoryes
{
    class SerializeFactory 
    {
        public static IParser ProduceSerialize(TypeSerializer type)
        {
            switch (type)
            {
                case TypeSerializer.JSON:
                    return new SerializeJSON();
                case TypeSerializer.XML:
                    return new SerializeXML();

                default:
                    return new SerializeUnknown();
            }
        }
    }
}
