using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class XhtmlFile
    {

        private string fileTempPath;
        private string fileName;
        private string originalFileHash;
        private string xhtmlContends;
        private bool hasEdited;

        public XhtmlFile() { }

        public XhtmlFile(string fileTempPath, string fileName, string originalFileHash, string xhtmlContends, bool hasEdited)
        {
            FileTempPath = fileTempPath;
            FileName = fileName;
            OriginalFileHash = originalFileHash;
            XhtmlContends = xhtmlContends;
            HasEdited = hasEdited;
        }

        public string FileTempPath { get => fileTempPath; set => fileTempPath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string OriginalFileHash { get => originalFileHash; set => originalFileHash = value; }
        public string XhtmlContends { get => xhtmlContends; set => xhtmlContends = value; }
        public bool HasEdited { get => hasEdited; set => hasEdited = value; }
    }
}
