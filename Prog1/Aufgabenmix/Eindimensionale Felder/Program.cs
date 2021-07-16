using System;

namespace Eindimensionale_Felder
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] array = new int[10];
            int[] arr2 = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                int zahl = rnd.Next(1, 21);
                array[i] = zahl;
                arr2[array.Length - 1 - i] = zahl;
            }

            int summe = 0;
            Console.WriteLine("Gibt das Array aus:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
                summe += i;

            }
            double durchschnitt = (double)summe / array.Length;
            Console.WriteLine($"Durchscnitt: {durchschnitt}");



            Console.WriteLine("Gebe eine Zahl ein Zahl ein");
            int vergleich = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gibt alle Zahlen im Array aus die größer als deine Zahl sind");
            foreach (int item in array)
            {
                if (vergleich < item)
                {
                    Console.Write($"{item}  ");
                }
            }

            int größte = array[0];
            int kleinste = größte;
            foreach (int j in array)
            {
                if (j > größte)
                {
                    größte = j;
                }

                if (j<kleinste)
                {
                    kleinste = j;
                }
            }

            Console.WriteLine($"\nKleinste Zahl: {kleinste}, größste Zahl: {größte}");

        }
    }
}
