using System;

namespace _3548145_Aufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sparen(1000, 155, 0.001);
        }

        static void Sparen(double wunschBetrag, double sparbetrag, double zinsSatz)
        {
            int jahrCounter = 1;
            double konto = 0;

            do
            {
                if (jahrCounter == 1)
                {
                    Console.WriteLine($"{jahrCounter}. Jahr: {sparbetrag:f}, eingezahlt: {sparbetrag:f}");
                    konto = (sparbetrag * zinsSatz + sparbetrag) + sparbetrag;                                              // Zinsen werden zum Kapital hinzugefügt und Sparbetrag addiert
                    jahrCounter++;
                    Console.WriteLine($"{jahrCounter}. Jahr: {konto:f}, eingezahlt: {sparbetrag * jahrCounter:f}");
                }

                double neuKonto = (konto * zinsSatz + konto) + sparbetrag;                                                  // Zinsen für neues kapital

                konto = neuKonto;


                if (konto > wunschBetrag)                                                                                                           // errechnet Summe genau für den Wunschbetrag
                {
                    double abzug = konto - wunschBetrag;                                                                                              
                    konto = konto - abzug;
                    Console.WriteLine($"{jahrCounter + 1}. Jahr: {konto:f}, eingezahlt: {(sparbetrag * jahrCounter) + (sparbetrag-abzug):f}");
                    Console.WriteLine($"Summe: {(sparbetrag * jahrCounter) + (sparbetrag - abzug):f} in {jahrCounter+1} Jahren");
                }
                else
                {
                    jahrCounter++;
                    Console.WriteLine($"{jahrCounter}. Jahr: {neuKonto:f}, eingezahlt: {sparbetrag * jahrCounter:f}");
                }

            } while (konto < wunschBetrag);                                                                                                         // solange wunschbetrag nicht erreicht wiederhole
        }
    }
}
