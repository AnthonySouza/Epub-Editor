using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Content
    {

        private string __fileName;
        private string __enconding;
        private string __filePath;
        private string __tempFilePath;
        private string __originalHash;
        private bool __hasEdited;
        private Package __package;

        public Content() { }
        public Content(string fileName, string enconding, string filePath, string tempFilePath, string originalHash, bool hasEdited, Package package, MetadataDocument metadata, Manifest manifest, Spine spine, Guide guide)
        {
            FileName = fileName;
            Enconding = enconding;
            FilePath = filePath;
            TempFilePath = tempFilePath;
            OriginalHash = originalHash;
            HasEdited = hasEdited;
            Package = package;
        }

        public string FileName { get => __fileName; set => __fileName = value; }
        public string Enconding { get => __enconding; set => __enconding = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
        public string TempFilePath { get => __tempFilePath; set => __tempFilePath = value; }
        public string OriginalHash { get => __originalHash; set => __originalHash = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public Package Package { get => __package; set => __package = value; }

    }
}
