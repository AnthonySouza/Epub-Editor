using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Manifest
    {

        private List<ManifestItem> __items;
        
        public Manifest() { Items = new List<ManifestItem>(); }
        
        public Manifest(List<ManifestItem> items)
        {
            Items = items;
        }

        public List<ManifestItem> Items { get => __items; set => __items = value; }

    }
}
