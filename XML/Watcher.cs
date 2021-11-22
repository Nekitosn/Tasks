using FileXML;
using System;
using System.IO;
using XML.Interfaces;

namespace XML
{
    public class Watcher : IWatcher
    {
        private IParser parser;

        private Display displayer;

        public Watcher(IParser parser)
        {
            this.parser = parser;

            this.displayer = new Display(this.parser);
        }

        public void Watch()
        {
            FileSystemWatcher watcher = new();
            watcher.Path = Path.GetDirectoryName(GlobalConstant.GetFullPathCinema());
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(WatcherChanged);
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.Clear();
            this.displayer.DisplayAll();
            this.displayer.DisplayCommandOnConsole();
        }
    }
}
