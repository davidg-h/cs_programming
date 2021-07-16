namespace HTML
{
    // TODO: Define classes for HTML tag elements (using interfaces "ITagged" and eventually "INested") here...

    #region Helper Class
    class Helper : ITaggedAndNested
    {
        private object[] elements;
        private string tagId;
        private string endTag;

        protected Helper(string tagId, string endTag, params object[] elements)
        {
            this.tagId = tagId;
            this.endTag = endTag;
            this.elements = elements;
        }

        // Properties
        public string TagId => tagId;
        public string EndTag => endTag;
        public object[] Elements => elements;
    }
    #endregion

    #region ITagged Only
    class DocumentType : ITagged
    {
        public string TagId => "<!DOCTYPE html>";
        public override string ToString() => TagId;
    }

    class LineBreak : ITagged
    {
        public string TagId => "<br/>";
        public override string ToString() => TagId;
    }
    #endregion

    #region Element Classes
    // each Element Class inherits from Helper for ITagged and INested
    class Html : Helper
    {
        // Constructor calling the Helper Constructor while giving the Helper his elements
        public Html(params object[] elements) : base("<html>", "</html>", elements) { }
    }

    class Head : Helper
    {
        public Head(params object[] elements) : base("<head>", "</head>", elements) { }
    }

    class Title : Helper
    {
        public Title(params object[] elements) : base("<title>", "</title>", elements) { }
    }

    class Body : Helper
    {
        public Body(params object[] elements) : base("<body>", "</body>", elements) { }
    }

    class Heading1 : Helper
    {
        public Heading1(params object[] elements) : base("<h1>", "</h1>", elements) { }
    }

    class Heading2 : Helper
    {
        public Heading2(params object[] elements) : base("<h2>", "</h2>", elements) { }
    }

    class Paragraph : Helper
    {
        public Paragraph(params object[] elements) : base("<p>", "</p>", elements) { }
    }

    class Italic : Helper
    {
        public Italic(params object[] elements) : base("<i>", "</i>", elements) { }
    }

    class Bold : Helper
    {
        public Bold(params object[] elements) : base("<b>", "</b>", elements) { }
    }

    class Underline : Helper
    {
        public Underline(params object[] elements) : base("<u>", "</u>", elements) { }
    }
    #endregion
}