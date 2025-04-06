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

namespace EpubEditor.Epub.Metadata.TOC
{
    /// <summary>
    /// The SpineItem class represents an item in the spine of an EPUB document.
    /// </summary>
    public class SpineItem
    {

        private string __itemRefId;
        private bool __linear;

        public SpineItem() { }

        public SpineItem(string itemRefId, bool linear)
        {
            ItemRefId = itemRefId;
            Linear = linear;
        }

        public string ItemRefId { get => __itemRefId; set => __itemRefId = value; }
        public bool Linear { get => __linear; set => __linear = value; }
    }
}
