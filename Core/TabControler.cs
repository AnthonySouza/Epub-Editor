using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epub_Editor.Core
{
    public partial class TabControler : TabControl
    {
        private string _tabName;
        private string _tabFileNamePath;

        public string TabName { get => _tabName; set => _tabName = value; }
        public string TabFileNamePath { get => _tabFileNamePath; set => _tabFileNamePath = value; }
    }
}
