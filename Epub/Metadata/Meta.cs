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

namespace EpubEditor.Epub.Metadata
{

    /// <summary>
    /// Meta class represents a metadata element in an EPUB document, including its name and content.
    /// </summary>
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
