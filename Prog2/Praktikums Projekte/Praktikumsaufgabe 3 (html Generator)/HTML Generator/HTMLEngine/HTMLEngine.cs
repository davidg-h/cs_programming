namespace HTML
{
    // HTML engine for generation of a HTML string from an array of HTML tag elements:

    public interface ITagged { string TagId { get; } }  // Used to define HTML tag element

    public interface INested { object[] Elements { get; } }  // Used to "mark" a HTML tag element as nested

    // interface for combining ITagged and INested
    public interface ITaggedAndNested : ITagged, INested { };

    public static class Engine
    {
        public static string Generate(params object[] elements)
        {
            // TODO: Your code for (recursive) generation of a HTML string from array "elements" here...

            string html = "";
            // iterates through Engine.Generate in Main
            foreach (object item in elements)
            {
                if (!(item is ITagged) || !(item is INested))
                {
                    // only items who are only ITagged or none of the both (DocType, Linebreak, numbers, strings)
                    html += item.ToString();
                    continue;
                }

                // casting to the helper class for access to the TagId...
                Helper help = item as Helper;
                html += "\n" + help.TagId;
                html += Generate(help.Elements);
                html += help.EndTag;
            }
            return html;
        }
    }
}