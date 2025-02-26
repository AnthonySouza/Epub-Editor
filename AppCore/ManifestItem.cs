using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class ManifestItem
    {

        private string __itemId;
        private string __itemHref;
        private string __mediaType;

        public ManifestItem() { }

        public ManifestItem(string itemId, string itemHref, string mediaType)
        {
            ItemId = itemId;
            ItemHref = itemHref;
            MediaType = mediaType;
        }

        public string ItemId { get => __itemId; set => __itemId = value; }
        public string ItemHref { get => __itemHref; set => __itemHref = value; }
        public string MediaType { get => __mediaType; set => __mediaType = value; }

    }
}
