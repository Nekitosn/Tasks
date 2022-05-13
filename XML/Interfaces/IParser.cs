using System.Collections.Generic;

namespace XML.Interfaces
{
    public interface IParser
    {
        List<T> Deserialize<T>(string pathFile);

        void Serialize<T>(List<T> list, string filePath);
    }
}
