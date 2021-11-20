using FileXML;
using System;
using System.IO;

namespace XML
{
    public class Watcher
    {
        private Display display=new Display();
        public void Watch(string path)
        {
            FileSystemWatcher watcher = new();
            watcher.Path = Path.GetDirectoryName(GlobalConstant.GetFullPathCinema());
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(WatcherChanged);
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.Clear();

            display.DisplayAll();
            display.DisplayCommandOnConsole();
        }
    }
}
