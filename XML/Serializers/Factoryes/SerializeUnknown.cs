using System;
using System.Collections.Generic;
using XML.Interfaces;

namespace XML.Factoryes
{
    public class SerializeUnknown : IParser
    {
        public List<T> Deserialize<T>(string pathFile)
        {
            throw new Exception("This deserialize does not exist\n");
        }

        public void Serialize<T>(List<T> list, string filePath)
        {
            throw new Exception("This serialization does not exist\n");
        }
    }
}
