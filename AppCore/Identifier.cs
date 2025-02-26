using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Identifier
    {

        private string _identifiernumber;
        private IdentifierScheme _scheme;

        public Identifier() { }

        public Identifier(string identifiernumber, IdentifierScheme scheme)
        {
            IdentifierNumber = identifiernumber;
            Scheme = scheme;
        }

        public string IdentifierNumber { get => _identifiernumber; set => _identifiernumber = value; }
        public IdentifierScheme Scheme { get => _scheme; set => _scheme = value; }
    }
}
