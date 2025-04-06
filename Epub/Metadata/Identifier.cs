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
    /// Identifier class represents a unique identifier for an EPUB document, including its number and scheme.
    /// </summary>
    public class Identifier
    {

        private string _identifiernumber;
        private IdentifierScheme _scheme;

        public Identifier() { }

        public Identifier(string identifiernumber, IdentifierScheme scheme)
        {
            IdentifierNumber = identifiernumber;
            Scheme = scheme;
        }

        public string IdentifierNumber { get => _identifiernumber; set => _identifiernumber = value; }
        public IdentifierScheme Scheme { get => _scheme; set => _scheme = value; }
    }
}
