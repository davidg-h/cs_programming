using HTML;

using static System.Console;

class Program
{
    // Test program for HTML generation:

    static void Main()
    {
        // Generate HTML document and store result in string:

        string html = Engine.Generate
        (
          new DocumentType(),

          new Html
          (
            new Head
            (
              new Title("Generated HTML5 Example")
            ),

            new Body
            (
              new Heading1("Welcome to the Technical University oAS Nuremberg"),

              new Paragraph
              (
                "We have a distinct profile ", new Underline("and"), " strive to maintain ", new Underline("our"), " leading position among comparable universities."

              ),

              new Heading2("Study for your future"),

              new Paragraph
              (
                12, " departments provide more than ", 40, " degree programs in ", new Bold("engineering, business, design and social sciences."),
                new LineBreak(),
                "If you have questions, please contact the ", new Italic("Student Counseling Service"), " or the ", new Italic("Student Office.")
              )
            )
          )
        );

        // Write resulting HTML string:

        WriteLine("GENERATED HTML DOCUMENT:");

        WriteLine(html);

        WriteLine("\nPlease press a key to continue...");

        ReadKey(true);


        // Write reformatted HTML string:

        WriteLine("\nREFORMATTED HTML DOCUMENT:");

        WriteLine("\n<" + new DocumentType().TagId + ">\n" + System.Xml.Linq.XElement.Parse(html.Replace("\n", "")));

        WriteLine("\nPlease press a key to continue...");

        ReadKey(true);


        // Show (original) HTML string in default browser:

        WriteLine("\nSTARTING BROWSER WITH GENERATED DOCUMENT...");

        System.IO.File.WriteAllText("Example.html", html);

        System.Diagnostics.Process.Start("Example.html");
    }
}