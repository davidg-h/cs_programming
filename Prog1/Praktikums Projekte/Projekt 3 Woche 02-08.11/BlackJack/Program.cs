using System;
using System.Security.Cryptography;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            int startGuthaben = 10;

            while (startGuthaben > 0)
            {
                //Spieler-Part
                Console.WriteLine($"\nDein Guthaben: {startGuthaben} Chips");

                int einsatz;
                do                                                                                                 //lässt 1 mal durchlaufen 
                {
                    Console.Write($"Dein Einsatz: ");                                                              //fragt nach dem Einsatz und wiederholt bei falscher Eingabe
                    einsatz = Convert.ToInt32(Console.ReadLine());
                    if (einsatz <= 0 || einsatz > startGuthaben)
                    {
                        Console.Write($"Du musst mindestens 1 und kannst max. {startGuthaben} Chips setzen. \n");
                    }
                } while (einsatz <= 0 || einsatz > startGuthaben);

                Console.WriteLine("\nDer Spieler bekommt jetzt 2 Karten:\n");

                int kartenWertGesamtSp = 0;
                Random zufall = new Random();

                for (int i = 1; i <= 2; i++)                                                                       //gibt 2 zufällige Karten aus
                {
                    int karte = zufall.Next(2, 12);
                    kartenWertGesamtSp += karte;                                                                   //Summiert den Wert der Karten für den Spieler
                    Console.WriteLine($"Karte: {karte,2}, Gesamt: {kartenWertGesamtSp,2}");
                }

                Console.Write("Noch eine Karte (j/n)? ");                                                          //fragt ob Spieler noch eine Karte will
                string eingabe = Console.ReadLine();
                while (kartenWertGesamtSp < 21 && eingabe == "j")
                {
                    if (eingabe == "j")
                    {
                        int kartenWert = zufall.Next(2, 12);                                                       //eine weitere Zufallskarte wird ausgegeben
                        kartenWertGesamtSp += kartenWert;
                        Console.WriteLine($"Karte: {kartenWert,2}, Gesamt: {kartenWertGesamtSp,2}");
                        if (kartenWertGesamtSp > 21)                                                               //wenn der Wert der Summe > 21 ist hat Spieler verloren und verliert den Einsatz
                        {
                            Console.WriteLine("\nLeider verloren \n");
                            startGuthaben -= einsatz;
                            Console.WriteLine($"Dein Guthaben: {startGuthaben} Chips");
                        }
                        else if (kartenWertGesamtSp == 21)                                                         //wenn Spieler genau den Wert 21 hat wartet er auf die Bank 
                        {
                            Console.WriteLine("\nWarten auf die Bank");
                            eingabe = "n";
                        }
                        else                                                                                       //hier wird die Abfrage für eine weitere Karte wiederholt, solange "j" ist
                        {
                            Console.Write("Noch eine Karte (j/n)? ");
                            eingabe = Console.ReadLine();
                        }
                    }
                }

                if (eingabe == "n")                                                                                //bei "n" ist der COM/Bank dran
                {
                    //Croupier-Part
                    Console.WriteLine($"\nDer Croupier ist an der Reihe:");
                    int kartenGesamtWertCOM = 0;

                    while (kartenGesamtWertCOM <= 22 && kartenGesamtWertCOM <= 17)                                 //COM zieht solange bis Wert der Summe > 16
                    {
                        int kartenWert = zufall.Next(2, 12);
                        kartenGesamtWertCOM += kartenWert;
                        Console.WriteLine($"Karte: {kartenWert,2}, Gesamt: {kartenGesamtWertCOM,2}");
                    }

                    if (kartenGesamtWertCOM > 21)                                                                  //wenn COM Kartensumme > 21 hat Spieler gewonnen
                    {
                        Console.WriteLine("\nDu hast gewonnen!\n");
                        startGuthaben += einsatz;
                        Console.WriteLine($"Dein Guthaben: {startGuthaben} Chips\n");
                    }
                    else if (kartenGesamtWertCOM <= 21 && kartenWertGesamtSp <= 21)                                //wenn beide <= 21 wird verglichen
                    {
                        if (kartenGesamtWertCOM >= kartenWertGesamtSp)                                             //COM gewinnt immer bei gleichen Summenwerten
                        {                                                                                          //oder wenn Summenwert von COM > Summenwert von Spieler, aber beide Summenwerte jeweils <= 21 
                            Console.WriteLine("\nLeider verloren. :( \n");
                            startGuthaben -= einsatz;
                            Console.WriteLine($"Dein Guthaben: {startGuthaben} Chips\n");
                        }
                        else                                                                                       //bei allen anderen Möglichkeiten gewinnt Spieler
                        {
                            Console.WriteLine("\nDu hast gewonnen!\n");
                            startGuthaben += einsatz;
                            Console.WriteLine($"Dein Guthaben: {startGuthaben} Chips\n");
                        }
                    }
                }

                Console.Write("\nMöchten Sie aufhören? (j/n) ");                                                   //Vor jeder neuen Runde wird gefragt, ob man aufhören will
                string stop = Console.ReadLine();
                if (stop == "j")
                {
                    Environment.Exit(0);                                                                           
                }

                if (startGuthaben == 0)
                {
                    Console.WriteLine("\nLeider haben Sie keine Chips mehr");
                }
            }
        }
    }
}
