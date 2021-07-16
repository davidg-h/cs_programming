using System;

namespace Übung_9__Fehlerbehandlung_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] newArray;
            Console.WriteLine("Gebe die Länge des Arrays an:");
            Console.Write("> ");
            newArray = new int[InputTesting(Console.ReadLine())];

            int count = 0;
            Console.WriteLine("\nFülle dein Array");

            Console.Write("> ");
            int number = InputTesting(Console.ReadLine());
            while (number != 0 && count < newArray.Length)
            {
                newArray[count] = number;
                count++;
                if (count < newArray.Length)
                {
                    Console.Write("> ");
                    number = InputTesting(Console.ReadLine());
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine("\nGebe einen Präfix");
            Console.Write("> ");
            newArray = SqrtRoot(InputTesting(Console.ReadLine()), newArray);

            Console.WriteLine("\nArray mit wurzel:");
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// Test input if it can convert to a number (loops if wrong input)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static int InputTesting(string value)
        {
            while (ParsingintNumber(value).Equals(double.NaN))
            {
                value = Console.ReadLine();
            } 
            // returns number
            return ((int)ParsingintNumber(value));
        }
        /// <summary>
        /// Parses input in int 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static double ParsingintNumber(string input)
        {
            try
            {
                return Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.Write("Falscher Input\n> ");
                return double.NaN;
            }
        }
        /// <summary>
        /// return array with sqrt values
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int[] SqrtRoot(int prefix, int[] arr)
        {
            int[] temp = new int[arr.Length];

            for (int i = 0; i < prefix; i++)
            {
                try
                {
                    double z = Math.Sqrt(arr[i]);
                    // for negative numbers --> exeption
                    if (z.Equals(double.NaN))
                    {
                        throw new Exception();
                    }
                    temp[i] = (int)z;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception("Dein Präfix ist zu groß");
                }
                catch (Exception)
                {
                    throw new InvalidSqrtException("Negative Zahl unter der Wurzel");
                }
            }

            // copying the rest of the array
            for (int i = prefix; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }

            return temp;
        }
    }

    class InvalidSqrtException : Exception
    {
        public InvalidSqrtException(string message) : base(message)
        {
            //Console.WriteLine(message);
            //some code
        }
    }
}
