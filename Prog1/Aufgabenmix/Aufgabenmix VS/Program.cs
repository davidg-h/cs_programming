using System;

namespace Quersumme_und_Querprodukt
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 10; i < 100; i++)
            {
                Querzahlen(i);
            }
        }

        static void Querzahlen(int zahl)
        {
            int einer = zahl % 10;
            int zehner = zahl / 10;

            int querprodukt = zehner * einer;
            int quersumme = einer + zehner;

            int querzahl = quersumme + querprodukt;
            if (zahl == querzahl)
            {
                Console.WriteLine(querzahl);
            }
        }
    }
}
