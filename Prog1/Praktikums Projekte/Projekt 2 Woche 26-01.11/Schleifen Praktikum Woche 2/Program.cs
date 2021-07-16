using System;

namespace Schleifen2
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 0;

            while ( zahl < 10 || zahl >= 10000)
            {
                Console.Write($"Geben Sie eine Zahl größer gleich 10 und kleiner als 10000 ein: ");
                zahl = Convert.ToInt32(Console.ReadLine());
                if ( zahl < 10 || zahl >= 10000)
                {
                    Console.WriteLine("Ungültige Eingabe, bitte wiederholen.\n");                    
                }
            }



            if (zahl < 1000)                                         //Ausgabe der ganzzahligen mehrfachen von 50-er der Zahl
            {
                Console.WriteLine($"\n50-er kleiner als {zahl}: ");
                for (int i = 1; i < zahl / 50; i++)                  //Sobald i größer wäre als die Hälfte von 50 wäre es keine ganzzahlige Teilung mehr
                {
                    Console.WriteLine(i * 50);
                }
            }
            else if (zahl > 1000 && zahl < 10000)                    //Ausgabe des ganzzahligen mehrfachen von 500 der Zahl
            {
                Console.WriteLine($"\n500-er kleiner als {zahl}: ");
                for (int i = zahl / 500; i >= 1; i--)
                {
                    Console.WriteLine(i * 500);
                }
            }
            else if (zahl == 1000)
            {
                Console.WriteLine($"\n500-er kleiner als {zahl}: \n500");
            }



            Console.WriteLine($"\nTeiler von {zahl}: ");             //Ausgabe der Summe echter Teiler von einer Zahl
            int summeTeiler = 0;
            for (int i = 2; i <= zahl / 2; i++)
            {
                if (zahl % i == 0)                                   //Wenn kein Rest übrig bleibt, dann ist {i} ein echter Teiler der Zahl
                {
                    Console.WriteLine(i);
                    summeTeiler = summeTeiler + i;
                }
            }
            if (summeTeiler == 0)                                    //Zahl ist nur mit 1 und sich selber teilbar --> Primzahl
            {
                Console.WriteLine($"{zahl} ist eine Primzahl\n");
            }
            else
            {
                Console.WriteLine($"Die Summe aller echten Teiler von {zahl} ist {summeTeiler}.\n");
            }



            int anzahlUngerade = 0;
            int anzahlGerade = 0;
            for (int i = (int)Math.Log10(zahl); i >= 0; i--)               //Laufvariable ist zu Beginn die Potenz (Nachkommastellen werden abgeschnitten) und verkleinert sich um 1
            {
                int modZahl = zahl % (int)Math.Pow(10, i);                 //Rest der Zahl bei Modulus mit 10 hoch i zB: zahl = 3587 --> modZahl = 587
                int prüfung = (zahl - modZahl) / (int)Math.Pow(10, i);     //zB: (3587 - 587) / 10 hoch i --> 3 :"Erste Ziffer"
                if (prüfung % 2 == 0)                                      //Wenn es keinen Rest gibt ist die Ziffer "gerade"
                {
                    anzahlGerade++;
                }
                else
                {
                    anzahlUngerade++;
                }
            }
            Console.WriteLine($"Die Zahl {zahl} hat {anzahlGerade} gerade und {anzahlUngerade} ungerade Ziffern.\n");


            //gleiches Prinzip wie bei Gerade Ungerade Aufgabe
            int zPotenz = (int)Math.Pow(10, (int)Math.Log10(zahl));            //10 hoch Potenz(Logarithmus der Zahl mit der Basis 10) für erste Ziffer; zB: 10 hoch [Log10(3587)=3] = 1000
            int mod = zahl % zPotenz;
            int ersteZiffer = (zahl - mod) / zPotenz;                          //Rest wird von Zahl abgezogen, da man den nicht braucht, und durch die 10 hoch Potenz geteilt, um nur die Ziffer zu bekommen
            int letzteZiffer = zahl % 10;
            Console.WriteLine($"Das Produkt der ersten und letzten Ziffer von {zahl} ist {ersteZiffer} * {letzteZiffer} = {ersteZiffer * letzteZiffer}");

        }
    }
}
