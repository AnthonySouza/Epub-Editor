using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Epub_Editor.AppCore
{
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
