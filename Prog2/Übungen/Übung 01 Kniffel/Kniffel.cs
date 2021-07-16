using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Kniffel
    {
        public static void Kniffeln()
        {
            string input = "j";
            do
            {
                int trys = 1;
                int counter = 0;

                do
                {
                    int[] arr = Again();
                    Console.Write($"{trys}.Versuch: ");
                    Print(arr);
                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        if (arr[i] == arr[i + 1])
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                        }
                    }

                    if (counter != 5)
                    {
                        trys++;
                    }

                } while (counter != 5);

                Console.WriteLine("Kniffel");

                Console.WriteLine("Again? j/n\n");
                input = Console.ReadLine();
            } while (input == "j");

        }

        static int[] Again()
        {
            Random rnd = new Random();
            int[] wuerfel = new int[5];
            for (int i = 0; i < wuerfel.Length; i++)
            {
                wuerfel[i] = rnd.Next(1, 7);
            }
            return wuerfel;
        }

        static void Print(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
