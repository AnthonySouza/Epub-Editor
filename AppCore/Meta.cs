using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Meta
    {

        private string __name;
        private string __content;

        public Meta() { }

        public Meta(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public string Name { get => __name; set => __name = value; }
        public string Content { get => __content; set => __content = value; }
    }
}
