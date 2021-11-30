using FileXML;
using System;
using System.Collections.Generic;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class DefaultBookFile:ICommandos
    {

        public DefaultBookFile()
        {
            Execute();
        }
        //public void CreateDefaultBook()
        //{
        //    //Создание файла для записи бронированых файлов
        //    FileStream fstream = new FileStream(GlobalConstant.GetPathBookInfo(), FileMode.OpenOrCreate);
        //    fstream.Close();
        //}

        public void Execute()
        {
            //Создание файла для записи бронированых файлов
            FileStream fstream = new FileStream(GlobalConstant.GetPathBookInfo(), FileMode.OpenOrCreate);
            fstream.Close();
        }
    }
}
