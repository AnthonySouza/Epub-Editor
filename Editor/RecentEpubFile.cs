/// 
/// 
/// EpubEditor
/// Free and open-source EPUB editor
/// www.epubeditor.com
/// instagram: @_gabe.el
/// email: epubeditor@gmail.com
/// Gabriel Daniel
/// 2025-04-06
/// v1.0
/// 
/// 

using System;

namespace EpubEditor.Editor
{

    /// <summary>
    /// Class representing a recent EPUB file openned in EpubEditor.
    /// </summary>
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
