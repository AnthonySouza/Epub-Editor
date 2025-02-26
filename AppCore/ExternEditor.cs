using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class ExternEditor
    {

        private string __name;
        private string __version;
        private string __exec_attributes;
        private string __icon_path;
        private string __directory;

        public ExternEditor () { }
        public ExternEditor(string name, string version, string exec_attributes, string icon_path, string directory)
        {
            Name = name;
            Version = version;
            Exec_attributes = exec_attributes;
            Icon_path = icon_path;
            Directory = directory;
        }

        public Image GetIconImage()
        {
            if (File.Exists(Icon_path))
            {

                return Image.FromFile(Icon_path);

            }

            return null;

        }

        public string Version { get => __version; set => __version = value; }
        public string Exec_attributes { get => __exec_attributes; set => __exec_attributes = value; }
        public string Icon_path { get => __icon_path; set => __icon_path = value; }
        public string Directory { get => __directory; set => __directory = value; }
        public string Name { get => __name; set => __name = value; }
    }
}
