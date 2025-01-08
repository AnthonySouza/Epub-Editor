using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Epub_Editor.AppCore
{
    public class EpubFile
    {

        private string originalPath;
        private string tempPath;
        private string fileName;
        private bool hasEdited;
        private XhtmlFile[] xhtmlFiles;
        private MetadataDocument metadata;


        public EpubFile() { }

        public EpubFile(string originalPath, string tempPath, string fileName, XhtmlFile[] xhtmlFiles, bool hasEdited)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            XhtmlFiles = xhtmlFiles;
            HasEdited = hasEdited;
        }

        public EpubFile(string originalPath, string tempPath, string fileName, XhtmlFile[] xhtmlFiles, bool hasEdited, MetadataDocument metadataDocument)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            XhtmlFiles = xhtmlFiles;
            HasEdited = hasEdited;
            Metadata = metadataDocument;
        }

        public string OriginalPath { get => originalPath; set => originalPath = value; }
        public string TempPath { get => tempPath; set => tempPath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public bool HasEdited { get => hasEdited; set => hasEdited = value; }
        public XhtmlFile[] XhtmlFiles { get => xhtmlFiles; set => xhtmlFiles = value; }
        public MetadataDocument Metadata { get => metadata; set => metadata = value; }
    }
}
