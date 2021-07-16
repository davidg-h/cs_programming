using System;
using System.Threading;

namespace Scharfe_Küche
{
    class Program
    {
        static void Main(string[] args)
        {
            //lässt Programm mehrmals durchlaufen, damit nicht immer debugged werden muss, außer bei nicht Erreichen des Mindesbestellwert oder bei der Frage ob Versand gespart werden soll
            for (int i = 0; i < 4; i++) 
            {
                double Pfeffer = 5.10;
                double Paprika = 3.90;
                double Curry = 4.50;
                double Versandpauschale = Math.Round(3.90, 2);

                Console.WriteLine("Herzlich Willkommen bei Scharfe Küche!");
                Console.WriteLine("Wie viele Dosen Pfeffer, Paprika, Curry möchten Sie kaufen");
                Console.WriteLine();

                Console.Write("Pfeffer-Preis pro Dose: " + $"{Pfeffer:f2}" + " Euro x ");
                double DosenanzahlPfeffer = Convert.ToInt32(Console.ReadLine());
                Console.Write("Paprika-Preis pro Dose: " + $"{Paprika:f2}" + " Euro x ");
                double DosenanzahlPaprika = Convert.ToInt32(Console.ReadLine());
                Console.Write("Curry-Preis   pro Dose: " + $"{Curry:f2}" + " Euro x ");
                double DosenanzahlCurry = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Ausgabe der Anzahl von Pfeffer, Paprika, Curry Dosen mit Preis und Verkaufsbetrag
                Console.WriteLine("Bestellbestätigung durch Scharfe Küche:");
                Console.WriteLine("Pfeffer: " + $"{DosenanzahlPfeffer + " x " + $"{Pfeffer:f2}" + " = " + $"{DosenanzahlPfeffer * Pfeffer,10:f2}" + " Euro",93}");
                Console.WriteLine("Paprika: " + $"{DosenanzahlPaprika + " x " + $"{Paprika:f2}" + " = " + $"{DosenanzahlPaprika * Paprika,10:f2}" + " Euro",93}");
                Console.WriteLine("Curry  : " + $"{DosenanzahlCurry + " x " + $"{Curry:f2}" + " = " + $"{DosenanzahlCurry * Curry,10:f2}" + " Euro",93}");
                Console.WriteLine();

                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                double Zwischensumme = DosenanzahlPfeffer * Pfeffer + DosenanzahlPaprika * Paprika + DosenanzahlCurry * Curry;

                Console.WriteLine("Zwischensumme: " + $"{$"{Zwischensumme:f2}" + " Euro",87}");

                if (Zwischensumme < 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ihre Bestellung erreicht nicht den Mindestbestellwert von 10,00 Euro");
                    Environment.Exit(0);
                    Console.WriteLine();
                }

                double steuer = Zwischensumme - (Zwischensumme / 1.16);

                if (25 <= Zwischensumme && Zwischensumme <= 29)
                {
                    double differrenz = 30 - Zwischensumme;
                    Console.WriteLine();
                    Console.WriteLine("Ihnen fehlt nur noch " + $"{differrenz:f2}" + " Euro bis zum kostenfreien Versand! Wollen Sie noch eine Dose Pfeffer mehr bestellen und den Versand sparen (ja/nein)?");
                    Console.WriteLine();
                    String a = "ja";
                    String b = Console.ReadLine();
                    Console.WriteLine();

                    //Bei Bestätigung mit ja wird eine Pfefferdose draufgerechnet und der Endbtrag ausgegeben
                    if (a == b)
                    {
                        double summe3 = Zwischensumme + Pfeffer;
                        double steuer2 = summe3 - (summe3 / 1.16);
                        double DosenanzahlPfeffer1 = DosenanzahlPfeffer + 1;
                        Console.WriteLine("Bestellbestätigung durch Scharfe Küche:");
                        Console.WriteLine("Pfeffer: " + $"{DosenanzahlPfeffer1 + " x " + $"{Pfeffer:f2}" + " = " + $"{DosenanzahlPfeffer1 * Pfeffer,10:f2}" + " Euro",93}");
                        Console.WriteLine("Paprika: " + $"{DosenanzahlPaprika + " x " + $"{Paprika:f2}" + " = " + $"{DosenanzahlPaprika * Paprika,10:f2}" + " Euro",93}");
                        Console.WriteLine("Curry  : " + $"{DosenanzahlCurry + " x " + $"{Curry:f2}" + " = " + $"{DosenanzahlCurry * Curry,10:f2}" + " Euro",93}");
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Neue Zwischensumme: " + $"{summe3,77:f2}" + " Euro");
                        Console.WriteLine("Keine Versandkosten: " + $"{0.00,76:f2}" + " Euro");
                        Console.WriteLine("Enthaltene MwSt (16%): " + $"{steuer2,74:f2}" + " Euro");
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Endbetrag:" + $"{summe3,87:f2}" + " Euro");
                        Environment.Exit(0);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }


                }
                //Versandpauschale für einen Einkaufswert unter 30 Euro
                if (Zwischensumme < 30)
                {
                    double summe = Zwischensumme + Versandpauschale;
                    Console.WriteLine("Versandpauschale: " + $"{3.90,79:f2}" + " Euro");
                    Console.WriteLine("Enthaltene MwSt (16%): " + $"{steuer,74:f2}" + " Euro");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Endbetrag: " + $"{summe,86:f2}" + " Euro");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Keine Versandkosten: " + $"{0.00,76:f2}" + " Euro");
                    Console.WriteLine("Enthaltene MwSt (16%): " + $"{steuer,74:f2}" + " Euro");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Endbetrag: " + $"{Zwischensumme,86:f2}" + " Euro");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.ReadKey(); 
            }
         
        } 
    }
}
