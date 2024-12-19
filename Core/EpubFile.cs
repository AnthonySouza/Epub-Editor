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
        private bool hasEdited;
        private XhtmlFile[] xhtmlFiles;


        public EpubFile() { }

        public EpubFile(string originalPath, string tempPath, string fileName, XhtmlFile[] xhtmlFiles, bool hasEdited)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            XhtmlFiles = xhtmlFiles;
            HasEdited = hasEdited;
        }

        public string OriginalPath { get => originalPath; set => originalPath = value; }
        public string TempPath { get => tempPath; set => tempPath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public bool HasEdited { get => hasEdited; set => hasEdited = value; }
        public XhtmlFile[] XhtmlFiles { get => xhtmlFiles; set => xhtmlFiles = value; }
    }
}
