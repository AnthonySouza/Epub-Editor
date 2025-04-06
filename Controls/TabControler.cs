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

namespace EpubEditor.Controls
{

    /// <summary>
    /// TabControler is a custom TabControl that represents a tab in the EPUB editor.
    /// </summary>
    public partial class TabControler : TabControl
    {
        private string _tabName;
        private string _tabFileNamePath;
        //private AdvancedTabPage _tabPage;

        public string TabName { get => _tabName; set => _tabName = value; }
        public string TabFileNamePath { get => _tabFileNamePath; set => _tabFileNamePath = value; }
        //public AdvancedTabPage AdvancedTabPage { get => _tabPage; set => _tabPage = value; }
    }
}
