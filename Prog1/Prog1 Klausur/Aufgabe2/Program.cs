using System;

namespace Aufgabe2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Matrikelnummer eingeben: ");
            string matNummer = Console.ReadLine();
            int laengeNummer = matNummer.Length;
            int[] x1 = FeldFuellen1D(laengeNummer);
            int[] zaehler = Vorkommen(x1, matNummer);
            FeldAusgeben(x1);
            FeldAusgeben(zaehler);
        }

        static int[] Vorkommen(int[] arr1, string matNR)
        {
            int[] zufallArr = arr1;
            int[] matArray = new int[matNR.Length];
            int[] anzahlArr = new int[10];                                  // array für ziffern
            int nummer = Int32.Parse(matNR);

            for (int i = 0; i < matArray.Length; i++)                       // bestücken des array für ziffern mit den einzelnen ziffern
            {
                matArray[i] = nummer % 10;
                nummer = nummer / 10;
            }

            for (int i = 0; i < 10; i++)                                    // anzahl der ziffern 0-9 wird ausgerechnet
            {
                anzahlArr[i] = Überprüfen(i, zufallArr, matArray);          // für die i-te ziffer wird das vorkommen gespeichert
            }

            return anzahlArr;
        }


        static int[] FeldFuellen1D(int länge)                               // füllt array mit zufallszahlen
        {
            int[] arr = new int[länge];
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10);
            }
            return arr;
        }

        static int Überprüfen(int x, int[] arr1, int[] arr2)
        {
            int vorhandenIn1 = 0;
            int vorhandenIn2 = 0;

            for (int i = 0; i < arr1.Length; i++)                       // geht das erste array durch und schaut wie oft ziffer 'x' vorkommt
            {
                if (arr1[i] == x)
                {
                    vorhandenIn1++;
                }
                
            }

            for (int i = 0; i < arr2.Length; i++)                       // geht das zweite array durch und schaut wie oft ziffer 'x' vorkommt
            {
                if (arr2[i] == x)
                {
                    vorhandenIn2++;
                }
            }

            return vorhandenIn1 + vorhandenIn2;                         // addiert vorkommen insgesamt
        }

        static void FeldAusgeben(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
