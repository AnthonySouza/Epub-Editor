using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class RecentEpubFile
    {

        private string __name;
        private string __directory;
        private bool __found;
        private DateTime __openned;

        public RecentEpubFile() { }

        public RecentEpubFile(string name, string directory, DateTime openned, bool found)
        {
            Name = name;
            Directory = directory;
            Openned = openned;
            IsFound = found;
        }

        public string Name { get => __name; set => __name = value; }
        public string Directory { get => __directory; set => __directory = value; }
        public DateTime Openned { get => __openned; set => __openned = value; }
        public bool IsFound { get => __found; set => __found = value; }
    }
}
