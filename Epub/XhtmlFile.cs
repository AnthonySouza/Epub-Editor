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

namespace EpubEditor.Epub
{

    /// <summary>
    /// Represents an XHTML file in an EPUB document.
    /// </summary>
    public class XhtmlFile : IDisposable
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

        public void Dispose() 
        {

            Dispose();

        }
    }
}
