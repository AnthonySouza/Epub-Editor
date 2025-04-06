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
    /// Manifest class represents a collection of manifest items in an EPUB document.
    /// </summary>

    public class Manifest
    {

        private List<ManifestItem> __items;
        
        public Manifest() { Items = new List<ManifestItem>(); }
        
        public Manifest(List<ManifestItem> items)
        {
            Items = items;
        }

        public List<ManifestItem> Items { get => __items; set => __items = value; }

    }
}
