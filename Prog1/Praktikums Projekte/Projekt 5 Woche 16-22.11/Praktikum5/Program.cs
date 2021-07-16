using System;

namespace Praktikum5
{
    class Program
    {
        #region Pascal Dreieck und Ausgabe
        static int[] PascalDreieck(int[] f)
        {
            if (f == null)                                                  // wenn ein array mit keinem Wert 
            {
                return new int[] { 1 };                                     // erzeuge ein array mit der Länge = 1 und dem wert = 1 an dem Index [0]
            }
            else
            {
                int länge = f.Length + 1;                                   // länge vom neuen array soll 1 länger sein als das vorherige
                int[] neuArr = new int[länge];                              // erzeugt ein neues array, dass 1 länger als altes array
                neuArr[länge - 1] = 1;                                      // am letzten index des neuen Array ist Wert = 1
                neuArr[0] = 1;

                for (int i = 1; i < f.Length; i++)                          // i steht hier für den Index
                {
                    neuArr[i] = f[i - 1] + f[i];                            // Zuweisung von neuem Wert in neues array (Bsp: f[1-1] = 1, f[1] = 2 --> neuArr[1] = 3)
                }
                return neuArr;
            }
        }

        static void Ausgabe(int[] f)                                        // ausgabe für jedes element in einem array; wird von jedem array jeweils aufgerufen
        {
            foreach (int i in f)
            {
                Console.Write($"{i} ");                                      
            }
            Console.WriteLine();
        }
        #endregion

        #region Primzahlen
        static int Primzahlen(int n, bool ausgabe = false)          // bei ausgabe = true, soll primzahlen in console ausgegeben werden
        {
            bool[] prim = new bool[n];                              // erzeugt ein array für bool aussagen
            int j;
            int index;
            int anzahl = 0;                                         // counter für die anzahl der primzahlen

            for (index = 2; index < n; index++)                     // alle Zahlen von 2 bis n sind als Primzahlen makiert                         
            {                                                       // index soll hier die primzahlen darstellen, also wenn prim[index] = true, dann ist 'index' eine primzahl
                prim[index] = true;
            }

            for (index = 2; index < n; index++)                     // wir fangen bei 2 an
            {
                for (j = 2; index * j < n; j++)                     // index * j = Vielfaches von index (Bsp: 2*2, 2*3, 2*4, ...)
                {
                    prim[index * j] = false;                        // alle Vielfachen sind keine Primzahlen
                }
                if (prim[index])                                    // wenn es eine primzahl an der stelle prim[index] gibt wird die anzahl der primzahlen erhöht
                {
                    anzahl++;

                    if (ausgabe)                                    // wenn die ausgabe = true, dann sollen die primzahlen ausgeschrieben werden, wenn nicht dann nur anzahl zurückgeben
                    {
                        Console.Write($"{index,2}  ");
                    }
                }
            }
            Console.WriteLine();
            return anzahl;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Pascalsches Dreieck:");
            int[] f = null;
            for (int i = 0; i < 8; i++)
            {
                f = PascalDreieck(f);
                Ausgabe(f);
            }
            Console.WriteLine();


            Console.WriteLine("Primzahlen bis 20");
            Primzahlen(20, true);
            const int Primzahlgrenze = 750000;
            Console.WriteLine($"Anzahl der Primzahlen bis {Primzahlgrenze}: {Primzahlen(Primzahlgrenze)}");
        }
    }
}
