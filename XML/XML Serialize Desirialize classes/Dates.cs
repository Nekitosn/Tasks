﻿using System;

namespace fileXML
{
    [Serializable]
    public class Dates
    {
        public Date Date { get; set; }
        public Dates() { }

        public Dates(Date date)
        {
            this.Date = date;
        }
    }
}
