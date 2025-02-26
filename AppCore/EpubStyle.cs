﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class EpubStyle
    {

        private string __cssFileName;
        private string __cssFileContent;
        private string __originalFileHash;
        private string __fileTempPath;
        private string __filePath;
        private bool __hasEdited;

        public EpubStyle() { }

        public EpubStyle(string cssFileName, string cssFileContent, string originalFileHash, string fileTempPath, string filePath, bool hasEdited)
        {
            CssFileName = cssFileName;
            CssFileContent = cssFileContent;
            OriginalFileHash = originalFileHash;
            FileTempPath = fileTempPath;
            FilePath = filePath;
            HasEdited = hasEdited;
        }

        public string CssFileName { get => __cssFileName; set => __cssFileName = value; }
        public string CssFileContent { get => __cssFileContent; set => __cssFileContent = value; }
        public string OriginalFileHash { get => __originalFileHash; set => __originalFileHash = value; }
        public string FileTempPath { get => __fileTempPath; set => __fileTempPath = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
    }
}
