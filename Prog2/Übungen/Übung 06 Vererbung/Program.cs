using System;

namespace Übung_6_Vererbung
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Astrid Lingred", "Pipi Langstrumpf", "BuchVerlagOrg", 3.45);
            Console.WriteLine(b1.FullInfo);

            Book b2 = new Book("Tokin", "Harry Potter", "Laser", 3.90);
            Console.WriteLine();
            Console.WriteLine(b2.FullInfo);

            CD c1 = new CD("Bob Dillan", "Heaven Sky", 6, 9.99);
            Console.WriteLine();
            Console.WriteLine(c1.FullInfo);

            CD c2 = new CD("ACDC", "Highwax to Hell", 12, 15.99);
            Console.WriteLine();
            Console.WriteLine(c2.FullInfo);

            Video v1 = new Video("How to summon Satan", "Bobo", false, 20.15);
            Console.WriteLine();
            Console.WriteLine(v1.FullInfo);

            Video v2 = new Video("Transformers", "Micheal Bay", true, 29.15);
            Console.WriteLine();
            Console.WriteLine(v2.FullInfo);
        }
    }
}
