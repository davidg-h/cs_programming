using System;

namespace Regeln_von_Sarrus
{
    class Program
    {
        static void Main(string[] args)
        {
            Zufallszahlen();
        }

        static int[,] Zufallszahlen()
        {
            int[,] arr = new int[3, 3];
            int[,] arr2 = new int[3, 5];
            Random ran = new Random();

            // bestücken 3x3 array
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = ran.Next(0, 10);
                }
            }

            // bestücken 3x5 array
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = arr[i, j % 3];
                }
            }

            Augabe(arr2);
            int deterSumme = 0;
            int deterAbzug = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i <= 2)
                {
                    deterSumme += Determinieren(arr2, i);
                }
                else
                {
                    deterAbzug += Determinieren(arr2, i);
                }
            }

            int gessamt = deterSumme - deterAbzug;
            Console.WriteLine($"\nDeterminante: {gessamt}");

            return arr;
        }

        static int Determinieren(int[,] array, int indexSpalte)
        {
            // rechnen determinante
            int produkt = 1;

            if (indexSpalte <= 2)
            {
                for (int j = indexSpalte, i = 0; i < array.GetLength(0); j++, i++)
                {
                    produkt *= array[i, j];
                }
            }
            else
            {
                indexSpalte %= 3;
                for (int j = indexSpalte, i = array.GetLength(0) - 1; i >= 0; j++, i--)
                {
                    produkt *= array[i, j];
                }
            }

            return produkt;
        }

        static void Augabe(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
