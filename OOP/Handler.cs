using Input_and_handler.FileTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Input_and_handler
{
    public class Handler
    {
        private readonly List<File> files;

        private readonly Dictionary<string, Func<string, File>> fileTypes;
        public Handler()
        {
            this.files = new List<File>();

            this.fileTypes = new Dictionary<string, Func<string, File>>()
            {
                {nameof(Text), str => new Text().GetFileInfo(str) },
                {nameof(Image), str => new Image().GetFileInfo(str) },
                {nameof(Movie), str => new Movie().GetFileInfo(str) },
            };
        }
        public void Start(string str)
        {
            var list = this.GetSeparateTypes(str);
            list.ForEach(x => x.Display());
        }
        private List<File> GetSeparateTypes(string strTest)
        {
            var parseList = strTest.Split('\n').OrderByDescending(fileType => fileType);

            foreach (var fileInfo in parseList)
            {
                var fileType = this.fileTypes.Keys.FirstOrDefault(key => fileInfo.Contains(key));

                if (fileType != null) this.files.Add(this.fileTypes[fileType](fileInfo));
            }
            return files;
        }
    }
}
