using System;

namespace Übung_3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Part a
            /*Zeitangabe z1 = new Zeitangabe(1, 2, 5, 5);
            Console.Write("Alles in Sekunden: ");
            Console.WriteLine(z1.TimeInSeconds());
            z1.Print();

            Zeitangabe z2 = new Zeitangabe(1, 2, 5, 10);
            Zeitangabe z3 = z1 + z2;
            Console.WriteLine($"z1+z2 = {z3.Sec}");
            z3.Print();

            ++z3;
            z3.Print();*/
            #endregion

            #region Part b
            Vektor a = new Vektor(1, 2, 3);
            Vektor b = new Vektor(1, 2, 4);

            Vektor c = a + b;
            c.Print();

            int x = a * b;
            Console.WriteLine(x);

            c = a | b;
            c.Print();

            double z = -a;
            Console.WriteLine(z);
            #endregion
        }
    }
}
