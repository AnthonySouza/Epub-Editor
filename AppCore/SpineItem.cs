using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class SpineItem
    {

        private string __itemRefId;
        private bool __linear;

        public SpineItem() { }

        public SpineItem(string itemRefId, bool linear)
        {
            ItemRefId = itemRefId;
            Linear = linear;
        }

        public string ItemRefId { get => __itemRefId; set => __itemRefId = value; }
        public bool Linear { get => __linear; set => __linear = value; }
    }
}
