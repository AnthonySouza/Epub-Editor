/// 
/// 
/// EpubEditor
/// Free and open-source EPUB editor
/// www.epubeditor.com
/// instagram: @_gabe.el
/// email: epubeditor@gmail.com
/// Gabriel Daniel
/// 2025-04-05
/// v1.0
/// 
/// 

using System;

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// EpubDateTime class represents a date and time with an associated event type.
    /// </summary>
    public class EpubDateTime
    {

        private DateTime __date;
        private DateEvent __dateEvent;

        public EpubDateTime() { }

        public EpubDateTime(DateTime date, DateEvent dateEvent)
        {
            Date = date;
            DateEvent = dateEvent;
        }

        public override string ToString()
        {
            return Date.ToString();
        }

        public static string ConvertDateEventToText(DateEvent dateEvent)
        {
            switch (dateEvent)
            {
                case DateEvent.None:
                    return "";
                case DateEvent.Creation:
                    return "creation";
                case DateEvent.Modification:
                    return "modification";
                case DateEvent.Publication:
                    return "publication";
            }
            return null;
        }

        public static DateEvent ConverStringToDateEvent(string input)
        {
            if (input != null)
            {
                switch (input)
                {
                    case "":
                        return DateEvent.None;
                    case "creation":
                        return DateEvent.Creation;
                    case "modification":
                        return DateEvent.Modification;
                    case "publication":
                        return DateEvent.Publication;
                }
            }

            return DateEvent.None;
        }

        public DateTime Date { get => __date; set => __date = value; }
        public DateEvent DateEvent { get => __dateEvent; set => __dateEvent = value; }
    }
}
