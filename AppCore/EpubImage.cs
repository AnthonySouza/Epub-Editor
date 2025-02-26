using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class EpubImage
    {

        private string __fileName;
        private string __filePath;
        private string __tempFilePath;
        private string __originalHash;
        private bool __hasEdited;
        private Image __imagecontent;

        public EpubImage () { }

        public EpubImage(string fileName, string filePath, string tempFilePath, string originalHash, bool hasEdited, Image imagecontent)
        {
            FileName = fileName;
            FilePath = filePath;
            TempFilePath = tempFilePath;
            OriginalHash = originalHash;
            HasEdited = hasEdited;
            Imagecontent = imagecontent;
        }

        public string FileName { get => __fileName; set => __fileName = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
        public string TempFilePath { get => __tempFilePath; set => __tempFilePath = value; }
        public string OriginalHash { get => __originalHash; set => __originalHash = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public Image Imagecontent { get => __imagecontent; set => __imagecontent = value; }
    }
}
