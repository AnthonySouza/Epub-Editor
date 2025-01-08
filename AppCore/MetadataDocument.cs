using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public class MetadataDocument
    {

        private string _generator;
        private string _cover;
        private string _title;
        private string _creator;
        private string _subject;
        private string _description;
        private string _publisher;
        private EpubDateTime _date;
        private string _source;
        private string _relation;
        private string _coverage;
        private string _rights;
        private Language[] _language;
        private Identifier[] _identifier;

        public MetadataDocument(string generator)
        {
            Generator = generator;
        }

        public MetadataDocument(string generator, string cover)
        {
            Generator = generator;
            Cover = cover;
        }

        public MetadataDocument(string generator, string cover, string title)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
        }

        public MetadataDocument(string generator, string cover, string title, string creator)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source, string relation)
        {
            Generator = generator;
            Cover = cover;
            Title = title;
            Creator = creator;
            Subject = subject;
            Description = description;
            Publisher = publisher;
            Date = date;
            Source = source;
            Relation = relation;
        }

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source, string relation, string coverage)
        {
            Generator = generator;
            Cover = cover;
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

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source, string relation, string coverage, string rights)
        {
            Generator = generator;
            Cover = cover;
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

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source, string relation, string coverage, string rights, Language[] language)
        {
            Generator = generator;
            Cover = cover;
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

        public MetadataDocument(string generator, string cover, string title, string creator, string subject, string description, string publisher, EpubDateTime date, string source, string relation, string coverage, string rights, Language[] language, Identifier[] identifier)
        {
            Generator = generator;
            Cover = cover;
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

        public string Generator { get => _generator; set => _generator = value; }
        public string Cover { get => _cover; set => _cover = value; }
        public string Title { get => _title; set => _title = value; }
        public string Creator { get => _creator; set => _creator = value; }
        public string Subject { get => _subject; set => _subject = value; }
        public string Description { get => _description; set => _description = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public EpubDateTime Date { get => _date; set => _date = value; }
        public string Source { get => _source; set => _source = value; }
        public string Relation { get => _relation; set => _relation = value; }
        public string Coverage { get => _coverage; set => _coverage = value; }
        public string Rights { get => _rights; set => _rights = value; }
        public Language[] Language { get => _language; set => _language = value; }
        public Identifier[] Identifier { get => _identifier; set => _identifier = value; }
    }
}
