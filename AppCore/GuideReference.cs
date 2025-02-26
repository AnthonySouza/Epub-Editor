using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class GuideReference
    {

        private string __title;
        private string __href;
        private GuideReferenceType __guideReferenceType;

        public GuideReference() { }

        public GuideReference(string title, string href, GuideReferenceType guideReferenceType)
        {
            Title = title;
            Href = href;
            GuideReferenceType = guideReferenceType;
        }

        public string Title { get => __title; set => __title = value; }
        public string Href { get => __href; set => __href = value; }
        public GuideReferenceType GuideReferenceType { get => __guideReferenceType; set => __guideReferenceType = value; }
    }
}
