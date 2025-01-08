using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class MetadataProperty
    {
        private string _name;
        private string _info;
        private string _id;
        private bool _hasSubProperties;

        public MetadataProperty(string name, string info, string id, bool hasSubProperties)
        {
            Name = name;
            Info = info;
            Id = id;
            HasSubProperties = hasSubProperties;
        }

        public string Name { get => _name; set => _name = value; }
        public string Info { get => _info; set => _info = value; }
        public string Id { get => _id; set => _id = value; }
        public bool HasSubProperties { get => _hasSubProperties; set => _hasSubProperties = value; }
    }
}
