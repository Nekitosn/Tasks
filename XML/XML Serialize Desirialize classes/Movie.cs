using System;
using System.Xml.Serialization;

namespace fileXML
{
    [Serializable]
    public class Movie
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        public Sessions Sessions { get; set; }
        public Movie() { }

        public Movie(string id, string name, Sessions sessions)
        {
            this.Id = id;
            this.Name = name;
            this.Sessions = sessions;
        }
    }
}
