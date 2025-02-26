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

        private string __originalPath;
        private string __tempPath;
        private string __fileName;
        private bool __hasEdited;
        private Content __content;
        private XhtmlFile[] __xhtmlFiles;
        private EpubStyle[] __styles;
        private EpubFont[] __fonts;
        private EpubImage[] __images;
        private MiscSettings[] __miscSettings;
        private TocSettings[] __tocSettings;


        public EpubFile() { }

        public EpubFile(string originalPath, string tempPath, string fileName, XhtmlFile[] xhtmlFiles, bool hasEdited)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            XhtmlFiles = xhtmlFiles;
            HasEdited = hasEdited;
        }

        public EpubFile(string originalPath, string tempPath, string fileName, XhtmlFile[] xhtmlFiles, bool hasEdited, EpubStyle[] styles, EpubFont[] fonts, EpubImage[] images, MiscSettings[] miscSettings, TocSettings[] tocSettings)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            HasEdited = hasEdited;
            XhtmlFiles = xhtmlFiles;
            Styles = styles;
            Fonts = fonts;
            Images = images;
            MiscSettings = miscSettings;
            TocSettings = tocSettings;
        }

        public EpubFile(string originalPath, string tempPath, string fileName, bool hasEdited, XhtmlFile[] xhtmlFiles, EpubStyle[] styles, EpubFont[] fonts, EpubImage[] images, MiscSettings[] miscSettings, TocSettings[] tocSettings, Content content)
        {
            OriginalPath = originalPath;
            TempPath = tempPath;
            FileName = fileName;
            HasEdited = hasEdited;
            XhtmlFiles = xhtmlFiles;
            Styles = styles;
            Fonts = fonts;
            Images = images;
            MiscSettings = miscSettings;
            TocSettings = tocSettings;
            Content = content;
        }

        public string OriginalPath { get => __originalPath; set => __originalPath = value; }
        public string TempPath { get => __tempPath; set => __tempPath = value; }
        public string FileName { get => __fileName; set => __fileName = value; }
        public bool HasEdited { get => __hasEdited; set => __hasEdited = value; }
        public XhtmlFile[] XhtmlFiles { get => __xhtmlFiles; set => __xhtmlFiles = value; }
        public EpubStyle[] Styles { get => __styles; set => __styles = value; }
        public EpubFont[] Fonts { get => __fonts; set => __fonts = value; }
        public EpubImage[] Images { get => __images; set => __images = value; }
        public MiscSettings[] MiscSettings { get => __miscSettings; set => __miscSettings = value; }
        public TocSettings[] TocSettings { get => __tocSettings; set => __tocSettings = value; }
        public Content Content { get => __content; set => __content = value; }
    }
}
