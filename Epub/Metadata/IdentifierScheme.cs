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
    /// IdentifierScheme enumeration represents different schemes for identifying an EPUB document.
    /// </summary>
    public enum IdentifierScheme
    {
        ISBN    = 0,
        ISSN    = 1,
        DOI     = 2,
        AMAZON  = 3,
        UUID    = 4,
        CUSTOM  = 5,
        BOOK_ID  = 6
    }
}
