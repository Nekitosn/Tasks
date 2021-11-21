using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using XML.Interfaces;

namespace FileXML
{
    public class SerializeXML : IParser
    {
        public List<T> Deserialize<T>(string filePath)
        {
            XmlSerializer superFormatter = new(typeof(List<T>));
            using FileStream fs = new(filePath, FileMode.Open);
            var dates = (List<T>)superFormatter.Deserialize(fs);
            return dates;
        }

        public void Serialize<T>(List<T> list, string filePath)
        {
            XmlSerializer superFormatter = new(typeof(List<T>));
            using FileStream fs = new(filePath, FileMode.Create);
            superFormatter.Serialize(fs, list);
        }
    }
}
