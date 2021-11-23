using FileXML;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class SerializeJSON : IParser
    {
        public List<T> Deserialize<T>(string filePath)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText("BookInfo.json"));
        }

        public void Serialize<T>(List<T> list, string filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(list, Formatting.Indented));
        }
    }
}
