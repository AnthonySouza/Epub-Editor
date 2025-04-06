/// 
/// 
/// EpubEditor
/// Free and open-source EPUB editor
/// www.epubeditor.com
/// instagram: @_gabe.el
/// email: epubeditor@gmail.com
/// Gabriel Daniel
/// 2025-04-05
/// v1.0
/// 
/// 

namespace EpubEditor.Epub.Metadata.TOC
{
    /// <summary>
    /// Represents the settings for the Table of Contents (TOC) in an EPUB document.
    /// </summary>
    public class TocSettings
    {

        private string __fileName;
        private string __filePath;
        private string __tempFilePath;
        private string __originalHash;
        private bool __hasEdited;
        private string __fileContent;

        public TocSettings () { }

        public TocSettings(string fileName, string filePath, string tempFilePath, string originalHash, bool hasEdited, string fileContent)
        {
            FileName = fileName;
            FilePath = filePath;
            TempFilePath = tempFilePath;
            OriginalHash = originalHash;
            HasEdited = hasEdited;
            FileContent = fileContent;
        }

        public string FileName { get => __fileName; set => __fileName = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
        public string TempFilePath { get => __tempFilePath; set => __tempFilePath = value; }
        public string OriginalHash { get => __originalHash; set => __originalHash = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public string FileContent { get => __fileContent; set => __fileContent = value; }
    }
}
