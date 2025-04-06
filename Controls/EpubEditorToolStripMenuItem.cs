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

using System.Windows.Forms;
using EpubEditor.Editor;

namespace EpubEditor.Controls
{

    /// <summary>
    /// EpubEditorToolStripMenuItem is a custom ToolStripMenuItem 
    /// that represents an EPUB editor or a recent EPUB file.
    /// </summary>
    public partial class EpubEditorToolStripMenuItem : ToolStripMenuItem
    {

        private RecentEpubFile recentEpubFile;
        private ExternEditor externEditor;

        public EpubEditorToolStripMenuItem() { }

        public EpubEditorToolStripMenuItem(string text)
        {
            Text = text;
        }

        public EpubEditorToolStripMenuItem(RecentEpubFile file)
        {
            RecentEpubFile = file;
            Text = RecentEpubFile.Name;
        }

        public EpubEditorToolStripMenuItem(ExternEditor editor)
        {
            ExternEditor = editor;
            Text = ExternEditor.Name;
        }

        public RecentEpubFile RecentEpubFile { get => recentEpubFile; set => recentEpubFile = value; }
        public ExternEditor ExternEditor { get => externEditor; set => externEditor = value; }
    }
}
