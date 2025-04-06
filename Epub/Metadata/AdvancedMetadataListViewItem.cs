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

using System.Windows.Forms;

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// Represents an item in the advanced metadata list view.
    /// </summary>
    public partial class AdvancedMetadataListViewItem : ListViewItem
    {

        private MetadataItem metadataItem;
        private MetadataProperty metadataProperty;

        public MetadataItem MetadataItem { get => metadataItem; set => metadataItem = value; }
        public MetadataProperty MetadataProperty { get => metadataProperty; set => metadataProperty = value; }
    }
}
