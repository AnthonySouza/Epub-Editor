﻿/// 
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

using System.Drawing;

namespace EpubEditor.Epub
{

    /// <summary>
    /// EpubFont class represents a font file properties in an EPUB document.
    /// </summary>
    public class EpubFont
    {

        private string __fontFileName;
        private string __filePath;
        private string __tempFilePath;
        private string __originalHash;
        private bool __hasEdited;
        private EpubFontType __epubFontType;
        private Font __fontContent;

        public EpubFont() { }

        public EpubFont(string fontFileName, string filePath, string tempFilePath, string originalHash, bool hasEdited, EpubFontType epubFontType, Font fontContent)
        {
            FontFileName = fontFileName;
            FilePath = filePath;
            TempFilePath = tempFilePath;
            OriginalHash = originalHash;
            HasEdited = hasEdited;
            EpubFontType = epubFontType;
            FontContent = fontContent;
        }

        public string FontFileName { get => __fontFileName; set => __fontFileName = value; }
        public string FilePath { get => __filePath; set => __filePath = value; }
        public string TempFilePath { get => __tempFilePath; set => __tempFilePath = value; }
        public string OriginalHash { get => __originalHash; set => __originalHash = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public Font FontContent { get => __fontContent; set => __fontContent = value; }
        public EpubFontType EpubFontType { get => __epubFontType; set => __epubFontType = value; }
    }
}
