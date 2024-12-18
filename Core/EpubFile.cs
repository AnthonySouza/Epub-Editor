using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Epub_Editor.Core
{
    public class EpubFile
    {

        private string originalPath;
        private string tempPath;
        private string fileName;


        public EpubFile() { }

        public EpubFile(string originalPath, string tempPath, string fileName)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
        }

        public string OriginalPath { get => originalPath; set => originalPath = value; }
        public string TempPath { get => tempPath; set => tempPath = value; }
        public string FileName { get => fileName; set => fileName = value; }

    }
}
