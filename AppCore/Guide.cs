using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class Guide
    {

        private List<GuideReference> __guideReferenceItems;

        public Guide() { GuideReferenceItems = new List<GuideReference>(); }

        public Guide(List<GuideReference> guideReferenceItems)
        {
            GuideReferenceItems = guideReferenceItems;
        }

        public List<GuideReference> GuideReferenceItems { get => __guideReferenceItems; set => __guideReferenceItems = value; }

    }
}
