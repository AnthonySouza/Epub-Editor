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

using EpubEditor.Epub.Metadata.TOC;

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// Package class represents the package element in an EPUB document.
    /// </summary>
    public class Package
    {

        private string __version;
        private string __xmlNamespace;
        private string __xmlOpfNamespace;
        private string __uniqueIdentifier;
        private MetadataDocument __metadata;
        private Manifest __manifest;
        private Spine __spine;
        private Guide __guide;
        
        public Package() { }

        public Package(string version, string xmlNamespace, string xmlOpfNamespace, string uniqueIdentifier, MetadataDocument metadata, Manifest manifest, Spine spine, Guide guide)
        {
            Version = version;
            XmlNamespace = xmlNamespace;
            XmlOpfNamespace = xmlOpfNamespace;
            UniqueIdentifier = uniqueIdentifier;
            Metadata = metadata;
            Manifest = manifest;
            Spine = spine;
            Guide = guide;
        }

        public string Version { get => __version; set => __version = value; }
        public string XmlNamespace { get => __xmlNamespace; set => __xmlNamespace = value; }
        public string XmlOpfNamespace { get => __xmlOpfNamespace; set => __xmlOpfNamespace = value; }
        public string UniqueIdentifier { get => __uniqueIdentifier; set => __uniqueIdentifier = value; }
        public MetadataDocument Metadata { get => __metadata; set => __metadata = value; }
        public Manifest Manifest { get => __manifest; set => __manifest = value; }
        public Spine Spine { get => __spine; set => __spine = value; }
        public Guide Guide { get => __guide; set => __guide = value; }
    }
}
