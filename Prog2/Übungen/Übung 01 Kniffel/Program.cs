using System;
using static Test.Kniffel;
namespace Übung_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Zahlenfeld();
            Print(arr);
            /*int summ = Sum(arr);
            Console.WriteLine($"Summe des Zahlenfeldes: {summ}");
            Console.WriteLine($"Durchschnitt des Zahlenfeldes: {Average(arr)}");*//*

            Sorted(arr);*/

            int[] b = { 2, 5, 3, 10 };
            //Chart(arr);

            Kniffeln();
        }

        static void Chart(int[] arr)
        {
            foreach (int i in arr)
            {
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Sorted(int[] arr)
        {
            int counter = 1;
            int counter2 = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] <= arr[i + 1])
                {
                    counter++;
                }
                if (arr[i] >= arr[i + 1])
                {
                    counter2++;
                }
            }

            if (counter == arr.Length)
            {
                Console.WriteLine("Sotiert klein nach groß");
            }
            else if(counter2 == arr.Length)
            {
                Console.WriteLine("Sotiert groß klein");
            }
            else
            {
                Console.WriteLine("nicht sotiert");
            }
        }

        static double Average(int[] arr)
        {
            int x = Sum(arr);
            return (double)x / arr.Length;
        }

        static int Sum(int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }

            return sum;
        }

        static int[] Zahlenfeld()
        {
            Random rnd = new Random();

            int[] arr = new int[rnd.Next(2, 10)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10);
            }
            return arr;
        }

        static void Print(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
