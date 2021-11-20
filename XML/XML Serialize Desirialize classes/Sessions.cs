using System;
using System.Collections.Generic;

namespace FileXML
{
    [Serializable]
    public class Sessions
    {
        public List<Session> Session { get; set; }
        public Sessions() { }

        public Sessions(List<Session> session)
        {
            this.Session = session;
        }
    }
}
