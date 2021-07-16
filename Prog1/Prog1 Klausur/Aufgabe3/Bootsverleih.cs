using System;

namespace Bootsverleih
{
    enum BootArt { Ruder, Paddel, Segel}


    class Program
    {
        static void Main(string[] args)
        {
            Boot b1 = new Boot("Flipper", 4, BootArt.Ruder);
            Boot b2 = new Boot("420er", 2, BootArt.Segel);
            Boot b3 = new Boot("2er-Kajak", 2, BootArt.Paddel);
            Boot b4 = new Boot("3er-Kanu", 3, BootArt.Paddel);
            Boot b5 = new Boot("Schlauchboot", 2, BootArt.Ruder);
            Boot b6 = new Boot("Sailart", 6, BootArt.Segel);
            Boot b7 = new Boot("1er-Kajak", 1, BootArt.Paddel);

            Console.WriteLine(b1);
            Console.WriteLine(b1.Art);
            Console.WriteLine(b1.NaechsteNr);
            Console.WriteLine(b1.ToString());

            Boot[] boote = new Boot[] { b1, b2, b3, b4, b5, b6, b7 };
            Bootsverleih verleih = new Bootsverleih(boote);

            Console.WriteLine(verleih.Bestand(BootArt.Ruder));

            Console.WriteLine($"Hier :{b1.Art}");
        }
    }
}
