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

namespace EpubEditor.Epub
{

    /// <summary>
    /// Miscellaneous settings for the EPUB editor.
    /// </summary>
    public class MiscSettings
    {

        private string __miscFileName;
        private string __filePath;
        private string __tempFilePath;
        private string __originalHash;
        private bool __hasEdited;
        private string __fileContent;

        public MiscSettings() { }

        public MiscSettings(string miscFileName, string filePath, string tempFilePath, string originalHash, bool hasEdited, string fileContent)
        {
            MiscFileName = miscFileName;
            FilePath = filePath;
            TempFilePath = tempFilePath;
            OriginalHash = originalHash;
            HasEdited = hasEdited;
            FileContent = fileContent;
        }

        public string MiscFileName { get => __miscFileName; set => __miscFileName = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
        public string TempFilePath { get => __tempFilePath; set => __tempFilePath = value; }
        public string OriginalHash { get => __originalHash; set => __originalHash = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public string FileContent { get => __fileContent; set => __fileContent = value; }
    }
}
