using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public enum IdentifierScheme
    {
        ISBN    = 0,
        ISSN    = 1,
        DOI     = 2,
        AMAZON  = 3,
        UUID    = 4,
        CUSTOM  = 5,
        BOOK_ID  = 6
    }
}
