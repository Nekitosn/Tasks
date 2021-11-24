using FileXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
