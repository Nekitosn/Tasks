using System;
using System.Xml.Serialization;

namespace fileXML
{
    [Serializable]
    public class Date
    {
        [XmlAttribute]
        public DateTime Value { get; set; }
        public Movies Movies { get; set; }
        public Date() { }

        public Date(DateTime value, Movies moviesF)
        {
            this.Value = value;
            this.Movies = moviesF;
        }
    }
}
