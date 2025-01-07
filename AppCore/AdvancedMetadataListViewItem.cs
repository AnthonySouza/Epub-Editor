using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epub_Editor.AppCore
{
    public partial class AdvancedMetadataListViewItem : ListViewItem
    {

        private MetadataItem metadataItem;

        public MetadataItem MetadataItem { get => metadataItem; set => metadataItem = value; }
    }
}
