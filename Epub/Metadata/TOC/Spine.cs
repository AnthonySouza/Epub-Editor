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

namespace EpubEditor.Epub.Metadata.TOC
{
    /// <summary>
    /// The Spine class represents the spine of an EPUB document,
    /// which contains the reading order of the content. The spine 
    /// is a required element in an EPUB document and defines the 
    /// order in which the content documents are presented to the 
    /// </summary>
    public class Spine
    {

        private string __toc;
        private List<SpineItem> __items;

        public Spine() { Items = new List<SpineItem>(); }

        public Spine(string toc, List<SpineItem> items)
        {
            Toc = toc;
            Items = items;
        }

        public string Toc { get => __toc; set => __toc = value; }
        public List<SpineItem> Items { get => __items; set => __items = value; }

    }
}
