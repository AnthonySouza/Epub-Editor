using ScintillaNET;

namespace Epub_Editor.AppCore
{
    public partial class AdvancedTextBox : Scintilla
    {
        private bool _hasEdited;
        private string textHash;

        public  bool HasEdited { get => _hasEdited; set => _hasEdited = value; }
        public string Hash { get => textHash; set => textHash = value; }
    }
}
