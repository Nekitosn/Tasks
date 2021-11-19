using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace fileXML
{
    public class SerializeOrDesirializeXML
    {

        public List<T> DeserializeXML<T>()
        {

            string value = GlobalConstant.GetPathCinema();
            XmlSerializer superFormatter = new(typeof(List<T>));

            using (FileStream fs = new(value, FileMode.Open))
            {
                List<T> dates = (List<T>)superFormatter.Deserialize(fs);
                return dates;
            }
        }

        public void SerializeXML<T>(List<T> list)
        {
            string value = GlobalConstant.GetPathCinema();
            XmlSerializer superFormatter = new(typeof(List<T>));
            using (FileStream fs = new(value, FileMode.Create))
            {
                superFormatter.Serialize(fs, list);
            }
        }

    }
}
