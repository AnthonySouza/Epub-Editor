/// 
/// 
/// EpubEditor
/// Free and open-source EPUB editor
/// www.epubeditor.com
/// instagram: @_gabe.el
/// email: epubeditor@gmail.com
/// Gabriel Daniel
/// 2025-04-06
/// v1.0
/// 
/// 

using EpubEditor.Lang;

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// MetadataDocument class represents the metadata of an EPUB document,
    /// including title, creator, subject, and other properties.
    /// </summary>  
    public class MetadataDocument
    {

        private string __title;
        private string __creator;
        private string __subject;
        private string __description;
        private string __publisher;
        private EpubDateTime[] __date;
        private string __source;
        private string __relation;
        private string __coverage;
        private string __rights;
        private Language[] __language;
        private Identifier[] __identifier;
        private Meta[] __meta;

        public MetadataDocument()
        {
            
        }

        public MetadataDocument(string title)
        {
            Title = title;
        }

        public MetadataDocument(string title, string creator)
        {
            Title = title;
            Creator = creator;
        }

        public MetadataDocument(string title, string creator, string subject)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
        }

        public MetadataDocument(string title, string creator, string subject, string description)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation, string coverage)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
            Coverage = coverage;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation, string coverage, string rights)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
            Coverage = coverage;
            Rights = rights;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation, string coverage, string rights, Language[] language)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
            Coverage = coverage;
            Rights = rights;
            Language = language;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation, string coverage, string rights, Language[] language, Identifier[] identifier)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
            Coverage = coverage;
            Rights = rights;
            Language = language;
            Identifier = identifier;
        }

        public MetadataDocument(string title, string creator, string subject, string description, string publisher, EpubDateTime[] date, string source, string relation, string coverage, string rights, Language[] language, Identifier[] identifier, Meta[] meta)
        {
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
            Coverage = coverage;
            Rights = rights;
            Language = language;
            Identifier = identifier;
            Meta = meta;
        }


        public string Title { get => __title; set => __title = value; }
        public string Creator { get => __creator; set => __creator = value; }
        public string Subject { get => __subject; set => __subject = value; }
        public string Description { get => __description; set => __description = value; }
        public string Publisher { get => __publisher; set => __publisher = value; }
        public EpubDateTime[] Date { get => __date; set => __date = value; }
        public string Source { get => __source; set => __source = value; }
        public string Relation { get => __relation; set => __relation = value; }
        public string Coverage { get => __coverage; set => __coverage = value; }
        public string Rights { get => __rights; set => __rights = value; }
        public Language[] Language { get => __language; set => __language = value; }
        public Identifier[] Identifier { get => __identifier; set => __identifier = value; }
        public Meta[] Meta { get => __meta; set => __meta = value; }
    }
}
