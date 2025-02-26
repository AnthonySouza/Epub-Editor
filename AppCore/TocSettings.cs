using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
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
