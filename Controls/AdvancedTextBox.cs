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

using ScintillaNET;

namespace EpubEditor.Controls
{

    /// <summary>
    /// Represents an advanced text box control that extends the Scintilla control.
    /// </summary>
    public partial class AdvancedTextBox : Scintilla
    {
        private bool _hasEdited;
        private string textHash;

        public  bool HasEdited { get => _hasEdited; set => _hasEdited = value; }
        public string Hash { get => textHash; set => textHash = value; }
    }
}
