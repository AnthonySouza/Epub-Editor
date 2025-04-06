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

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// GuideReference class represents a reference to a specific guide item in an EPUB document.
    /// </summary>

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
