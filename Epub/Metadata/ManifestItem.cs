/// 
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

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// ManifestItem class represents an item in the manifest of an EPUB document.
    /// </summary>

    public class ManifestItem
    {

        private string __itemId;
        private string __itemHref;
        private string __mediaType;

        public ManifestItem() { }

        public ManifestItem(string itemId, string itemHref, string mediaType)
        {
            ItemId = itemId;
            ItemHref = itemHref;
            MediaType = mediaType;
        }

        public string ItemId { get => __itemId; set => __itemId = value; }
        public string ItemHref { get => __itemHref; set => __itemHref = value; }
        public string MediaType { get => __mediaType; set => __mediaType = value; }

    }
}
