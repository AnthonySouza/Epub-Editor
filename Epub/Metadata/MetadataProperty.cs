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
    /// MetadataProperty class represents a metadata property in an EPUB document.
    /// </summary>
    public class MetadataProperty
    {
        private string _name;
        private string _info;
        private string _id;
        private bool _hasSubProperties;

        public MetadataProperty(string name, string info, string id, bool hasSubProperties)
        {
            Name = name;
            Info = info;
            Id = id;
            HasSubProperties = hasSubProperties;
        }

        public string Name { get => _name; set => _name = value; }
        public string Info { get => _info; set => _info = value; }
        public string Id { get => _id; set => _id = value; }
        public bool HasSubProperties { get => _hasSubProperties; set => _hasSubProperties = value; }
    }
}
