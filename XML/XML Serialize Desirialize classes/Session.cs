using System;
using System.Xml.Serialization;

namespace fileXML
{
    [Serializable]
    public class Session
    {
        [XmlAttribute]
        public string Time { get; set; }
        public Session() { }

        public Session(string time)
        {
            this.Time = time;
        }
    }
}
