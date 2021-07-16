using System;
using System.Diagnostics;	// Stopwatch class (Eventually add project reference "System")

using Example.Tools;

namespace Example
{
    class Programm
    {
        const string sentence = "Programmieren in C# macht Spaß!";

        static void Main()
        {
            ValueQueue[] arr = new ValueQueue[5];
            int arrCounter = 0;
            do
            {
                uint countMax = (uint)sentence.Length;
                // Initialization:

                ValueQueue queue = new ValueQueue(countMax);

                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                // Main loop:

                Console.WriteLine($"Tippe diesen Satz so schnell es geht ab: {sentence}");
                Console.WriteLine("Please press a key to start... (End with ESCAPE)");

                bool firstTime = true;
                int i = 1;

                ConsoleKeyInfo key = Console.ReadKey();

                while (key.KeyChar == sentence[i - 1] && key.Key != ConsoleKey.Escape && !queue.Full)   // Use of property
                {
                    if (firstTime)
                    {
                        firstTime = false;
                    }
                    else
                    {
                        queue.Add(stopWatch.ElapsedMilliseconds);
                    }

                    stopWatch.Restart();
                    if (i < countMax)
                    {
                        i++;
                        key = Console.ReadKey();
                    }
                }
                if (arrCounter < arr.Length)
                {
                    arr[arrCounter] = queue;
                }
                arrCounter++;
                Console.WriteLine("\nAverage time span: {0} ms", queue.Average());
                Console.WriteLine("\nTry Again? (j/n)\n");
            } while (arrCounter < arr.Length && Console.ReadLine() == "j");

            ValueQueue[] temp = new ValueQueue[arr.Length];
            int x = 0;

            while (x < arr.Length)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i + 1].Average() > arr[i].Average())
                    {
                        temp[x] = arr[i + 1];
                    }
                }
                x++;
            }

            Console.WriteLine($"High Score: {temp[0].Average()}");
            Console.WriteLine("High Score Summary:");
            Summary(temp[0]);

            // Wait for ESCAPE:

            Console.WriteLine("Please quit application with ESCAPE...");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }

        public static void Summary(ValueQueue v)
        {
            // Summary:
            if (v.Count > 0)
            {
                Console.WriteLine("\nSummary:");

                for (uint index = 0; index < v.Count; index++)  // Use of property
                {
                    Console.WriteLine("{0}. Time span: {1} ms", index + 1, v[index]);   // Use of indexer
                }
            }
            else
            {
                Console.WriteLine("\nNot enough values measured.");
            }
        }
    }
}