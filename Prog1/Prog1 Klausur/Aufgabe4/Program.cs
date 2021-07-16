using System;

namespace Aufgabe4
{
    enum FieldType { Empty, Machinery, ProhibitedArea, Connection, Staffroom }

    class Program
    {
        static double RateMachinery(FieldType[,] map)
        {
            int alleQuadrate = map.Length;                             
            int anzahlMachinery = 0;                                    // Zähler für Machinery

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == FieldType.Machinery)
                    {
                        anzahlMachinery++;
                    }
                }
            }

            double anteil = (double)anzahlMachinery / alleQuadrate;

            return anteil;
        }

        static void PrintField(FieldType[,] map, int x, int y)
        {
            if (x < 0)
            {
                int mod = (-1 * x) % map.GetLength(1);          // wenn x negativ --> x mod 20 
                x = map.GetLength(1) + (-1 * mod);              // nach rest auflösen
            }
            else if (x > map.GetLength(1) - 1)
            {
                x = x % map.GetLength(1);
            }

            if (y < 0)
            {
                int mod = (-1 * y) % map.GetLength(0);
                y = map.GetLength(0) + (-1 * mod);
            }
            else if (y > map.GetLength(0) - 1)
            {
                y = y % map.GetLength(0);
            }

            switch (map[y, x])                              // Zeichen für verschiedene FieldTypes
            {
                case FieldType.Empty:
                    Console.Write("  ");
                    break;
                case FieldType.Machinery:
                    Console.Write("▓▓");
                    break;
                case FieldType.ProhibitedArea:
                    Console.Write("XX");
                    break;
                case FieldType.Connection:
                    Console.Write("<>");
                    break;
                case FieldType.Staffroom:
                    Console.Write(":)");
                    break;
                default:
                    Console.Write("??");
                    break;
            }
        }

        static void Print(FieldType[,] map)
        {
            // Dies sind die Zeichen für die Ausgaben:
            //
            // Empty:           "  "
            //
            // Machinery:        ▓▓
            //
            // ProhibitedArea:   XX
            //
            // Connection:       <>
            //
            // Staffroom:        :)
            //
            // alles andere:     ??
            //

            for (int i = 0; i < map.GetLength(0); i++)              // gibt das Feld im Quadrat aus
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    PrintField(map, j, i);
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            FieldType[,] map = new FieldType[,] {
                    { FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery }, //  1
                    { FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Staffroom, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery },
                    { FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery },
                    { FieldType.Machinery, FieldType.Machinery, FieldType.ProhibitedArea, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Connection, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Connection, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery }, //  5
                    { FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty,FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty }, //  6
                    { FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery,FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty,FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty },
                    { FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.ProhibitedArea, FieldType.ProhibitedArea, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery,FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Staffroom, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Staffroom, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery,FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery }, // 10
                    { FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery }, // 11
                    { FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery },
                    { FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Connection, FieldType.Machinery,FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty,FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Connection, FieldType.Machinery, FieldType.Staffroom, FieldType.Machinery },
                    { FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Connection, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery,FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Connection, FieldType.Staffroom, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Machinery }, // 15
                    { FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty,FieldType.Empty, FieldType.Empty, FieldType.ProhibitedArea, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty }, // 16
                    { FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery,FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.ProhibitedArea, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery,FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty },
                    { FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery,FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Empty, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery, FieldType.Machinery },
                    { FieldType.Empty, FieldType.Staffroom, FieldType.Machinery, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery,FieldType.Empty, FieldType.Empty, FieldType.Machinery, FieldType.Empty, FieldType.Staffroom, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Empty, FieldType.Machinery }  // 20
                };

            Console.WriteLine("Anteil Maschinen: {0:#0.0}%", RateMachinery(map) * 100);

            Console.Write("oben links: ");
            PrintField(map, 0, 0);
            Console.WriteLine();

            Console.Write("unten rechts: ");
            PrintField(map, -1, -1);
            Console.WriteLine();

            Console.Write("irgendwo weit: ");
            PrintField(map, 6524558, -72347); // Sollte ein seltenes Quadrat zeigen
            Console.WriteLine();

            Print(map);
        }
    }
}
