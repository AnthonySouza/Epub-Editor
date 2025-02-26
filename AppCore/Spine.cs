using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Spine
    {

        private string __toc;
        private List<SpineItem> __items;

        public Spine() { Items = new List<SpineItem>(); }

        public Spine(string toc, List<SpineItem> items)
        {
            Toc = toc;
            Items = items;
        }

        public string Toc { get => __toc; set => __toc = value; }
        public List<SpineItem> Items { get => __items; set => __items = value; }

    }
}
