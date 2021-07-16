using System;

namespace Mandelbrot
{
    class Mandelbrot
    {
        const string zeichenvorrat = " Programmieren!";
        // ... auch hübsch:
        //const string zeichenvorrat = "\u263b                  ";

        const int breite = 95;
        const int hoehe = 30;
        const double minX = -2;
        const double maxX = 0.8;
        const double minY = -1.5;
        const double maxY = 1.5;
        const double xSchritt = (maxX - minX) / breite;
        const double ySchritt = (maxY - minY) / hoehe;



        /// <summary>
        /// Berechnung der Folge z = z*z + c
        /// </summary>
        /// <param name="zeile">Zeile</param>
        /// <param name="spalte">Spalte</param>
        /// <returns>0, falls c Element der Mandelbrot-Menge; sonst: Anzahl der Iterationen, bis |z| > 2</returns>
        static int Mandel(int zeile, int spalte)
        {
            // Die entsprechende komplexe Zahl c:
            double x = minX + spalte * xSchritt;
            double y = minY + zeile * ySchritt;
            System.Numerics.Complex c = new System.Numerics.Complex(x, y);

            // Folge berechnen:
            System.Numerics.Complex z = c;
            for (int i = 0; i < zeichenvorrat.Length; i++)
            {
                if (z.Magnitude > 2)
                {
                    // Die Folge ist nicht beschränkt
                    // => c ist nicht Element der Mandelbrot-Menge
                    return i;
                }
                z = z * z + c;
            }
            // Die Folge ist beschränkt (|z| bleibt <= 2)
            // => c ist Element der Mandelbrot-Menge
            return 0;
        }


        static void Ausgabe(char[,] feld)                                               // Ausgabe jedes Element eines zweidim. Array
        {
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    Console.Write(feld[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] Spiegeln(char[,] feld2)
        {
            char[,] newFeld = new char[hoehe, breite];                                  // neues Array zum abspeichern
            int lastChar = feld2.GetLength(0) - 1;                                      // letzte Zeile
            int lastChar2 = feld2.GetLength(1) - 1;                                     // letzte Spalte

            for (int i = 0; i < feld2.GetLength(0); i++)
            {
                for (int j = 0; j < feld2.GetLength(1); j++)
                {
                    newFeld[i, j] = feld2[lastChar - i, lastChar2 - j];                 // Elemente von letzter Zeile wird "rückwärts" gespeichert in erste, gleiches Prinzip für andere Zeilen
                }
            }
            return newFeld;
        }

        static char[,] Scrollen(char[,] feld3)
        {
            char[] arr = new char[feld3.GetLength(1)];

            for (int i = 0; i < feld3.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < feld3.GetLength(1); j++)
                {
                    arr[j] = feld3[0, j];                                               // erste Zeile von feld3 in eindim. Array gespeichert
                    feld3[i, j] = feld3[i + 1, j];                                      // Zeilen werden nach oben gerückt
                    feld3[feld3.GetLength(0) - 1, j] = arr[j];                          // letzte zeile hat wert von erster Zeile
                }
            }
            return feld3;
        }

        static void Main(string[] args)
        {
            char[,] meinFeld = new char[hoehe, breite];

            for (int i = 0; i < meinFeld.GetLength(0); i++)
            {
                for (int j = 0; j < meinFeld.GetLength(1); j++)
                {
                    meinFeld[i, j] = zeichenvorrat[Mandel(i, j)];                       // bestücken des Array
                }
            }
            Console.WriteLine($" Apfelmänchen wird ausgegeben: \n");
            Ausgabe(meinFeld);
            Console.WriteLine("\nFeld wird jetzt gespiegelt: \n");
            Ausgabe(Spiegeln(meinFeld));
            //meinFeld = Spiegeln(meinFeld);                                            // gespiegeltes Array wird abgespeichert
                                                                                        // falls mir jemand erklären kann wieso beim Spiegeln der das Feld nicht speichert, aber beim Scrollen schon, wäre es sehr nett
            Console.Write($"\nWie oft willst du scrollen? Deine Eingabe bitte: ");      // um zu sehen was ich meine einmal ohne 'meinFeld = Spiegeln(meinFeld);' ausführen und einmal mit
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {
              Scrollen(meinFeld);
            }
            Console.WriteLine();
            Ausgabe(meinFeld);
        }
    }
}
