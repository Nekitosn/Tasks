using FileXML;
using System;
using System.Collections.Generic;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class DefaultBookFile
    {
        private IParser parser;

        public DefaultBookFile(IParser parser)
        {
            this.parser = parser;
            CreateDefaultBook();
        }
        public void CreateDefaultBook()
        {
            //Создание файла для записи бронированых файлов
            FileStream fstream = new FileStream(GlobalConstant.GetPathBookInfo(), FileMode.OpenOrCreate);
            fstream.Close();
        }
    }
}
