using System;

namespace Übung_8__Schnittstellen_
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Aufgabe a) Main
            /* double[] arr = { (double)1 / 3, (double)4 / 6, (double)-4 / 69, (double)9 / 5, (double)-316 / 459, (double)100 / 4994 };
             Fracture[] frac = new Fracture[arr.Length];

             for (int i = 0; i < arr.Length; i++)
             {
                 frac[i] = new Fracture(arr[i]);
             }

             Array.Sort(frac);

             foreach (var item in frac)
             {
                 Console.WriteLine(item);
             }*/

            /// Aufgabe b) Main
            /*RandomNumber ran = new RandomNumber(5);

            foreach (var item in ran)
            {
                Console.Write(item + " ");
            }*/

            ///Aufgabe c) Main
            RandomNumber2 ran2 = new RandomNumber2(5);

            foreach (var item in ran2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
