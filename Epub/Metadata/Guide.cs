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

using System.Collections.Generic;

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// Guide class represents a collection of guide references in an EPUB document.
    /// </summary>

    public class Guide
    {

        private List<GuideReference> __guideReferenceItems;

        public Guide() { GuideReferenceItems = new List<GuideReference>(); }

        public Guide(List<GuideReference> guideReferenceItems)
        {
            GuideReferenceItems = guideReferenceItems;
        }

        public List<GuideReference> GuideReferenceItems { get => __guideReferenceItems; set => __guideReferenceItems = value; }

    }
}
