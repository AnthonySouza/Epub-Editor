using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class EpubDateTime
    {

        private DateTime _date;
        private DateTime _createdDate;
        private DateTime _publishedDate;
        private DateTime _modifiedDate;

        public EpubDateTime() { }

        public EpubDateTime(DateTime date)
        {
            Date = date;
        }

        public EpubDateTime(DateTime date, DateTime createdDate)
        {
            Date = date;
            CreatedDate = createdDate;
        }

        public EpubDateTime(DateTime date, DateTime createdDate, DateTime publishedDate)
        {
            Date = date;
            CreatedDate = createdDate;
            PublishedDate = publishedDate;
        }

        public EpubDateTime(DateTime date, DateTime createdDate, DateTime publishedDate, DateTime modifiedDate)
        {
            Date = date;
            CreatedDate = createdDate;
            PublishedDate = publishedDate;
            ModifiedDate = modifiedDate;
        }

        public DateTime Date { get => _date; set => _date = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime PublishedDate { get => _publishedDate; set => _publishedDate = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
    }
}
