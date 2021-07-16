using System;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace BlackJack2
{
    class Program
    {
        #region Einsatz
        // Lässt den Spieler einen Einsatz festlegen
        static int EinsatzEingeben(int guthaben)                                                            // ref int guthaben wird als Parameter mitgenommen, damit der Einsatz mit Guthaben
        {                                                                                                   // verglichen werden kann
            string einsatz;
            int number;
            bool success;
            Console.WriteLine($"Dein Guthaben: {guthaben} Chips");
            do
            {
                Console.WriteLine("Wie viel möchten Sie setzen? Setzen Sie 0 um das Spiel zu beenden.");
                Console.WriteLine($"Bitte geben Sie einen Wert zwischen 0 und {guthaben} ein:\n");
                einsatz = Console.ReadLine();                                                               // einsatz wird eingelesen

                success = Int32.TryParse(einsatz, out number);                                              // wenn der string, welcher der einsatz einliest eine Zahl ist wird sie in int umgewandelt
                                                                                                            // und in number gespeichert
                if (success)                                                                                // wenn die Number umgewandelt werden kann, also success = true
                {
                    if (number < 0)
                    {
                        Console.WriteLine("\nZu kleiner Wert");
                    }
                    else if (number > guthaben)
                    {
                        Console.WriteLine("\nUngültige Eingabe. Einsatz ist größer als Ihr Guthaben");
                    }
                    else if (number == 0)                                                                   // wenn eine 0 umgewandelt wird, wird sofort hier die Methode beendet
                    {                                                                                       // Spiel wird dann auch beendet (siehe Play-Methode)
                        return 0;
                    }
                }
                else                                                                                        // wenn zB: abc eingegeben wird und nicht in int umgewandelt werden kann 
                {
                    Console.WriteLine("\nUngültige Eingabe. Die Eingabe ist keine Zahl gewesen.");
                }
            } while (number < 0 || number > guthaben || success != true);                                   // wiederhole solange einsatz nicht stimmt oder keine Zahl umgewandelt werden kann (success != true)
            return number;
        }
        #endregion

        #region zufällige Kartenausgabe 
        // Zufällige Ausgabe von Karten
        static int ZufallkarteAusgeben()
        {
            Random zufall = new Random();
            int karte = zufall.Next(1, 14);                      // Zufällige Ausgabe der Zahlen von 1-13

            switch (karte)
            {
                case 1:
                    Console.Write("Gezogen: A (1/11) ");         // 1 ist das Ass und hat den Wert 11 (für Spieler wird Ass nochmal angepasst in "Noch eine Karte")
                    return 11;
                case 11:
                    Console.Write("Gezogen: B  ");
                    return 10;
                case 12:
                    Console.Write("Gezogen: D  ");
                    return 10;
                case 13:
                    Console.Write("Gezogen: K  ");
                    return 10;
            }
            return karte;                                        // karten mit dem Wert 2-10 werden zurückgegeben alle anderen karten siehe cases
        }
        #endregion

        #region Noch eine Karte (j/n)
        // Frage nach noch einer Karte
        static int KarteJaNein(ref int kartenWertGesamtSp)                                                  // Punkte der Spieler wird mitgenommen und gegebenenfalls verändert
        {
            if (kartenWertGesamtSp < 21)
            {
                Console.Write("Noch eine Karte (j/J/n)? ");
                string eingabe = Console.ReadLine();
                while (kartenWertGesamtSp < 21 && (eingabe == "j" || eingabe == "J"))
                {
                    int kartenWert = ZufallkarteAusgeben();                                                 // Ruft die Methode für zufällige Karten auf
                    kartenWertGesamtSp += kartenWert;                                                       // Der Gesamtwert der Karten wird jeweils für den Spieler der diese Methode aufruft erhöht
                    if (kartenWert == 11 && kartenWertGesamtSp > 21)                                        // Wenn man bei der zufälligen Kartenausgabe ein Ass hatte war der Wert 11 
                    {                                                                                       // und wenn mit dem Ass 21 überschritten wird, dann wird Ass = 1    
                        kartenWertGesamtSp -= 10;                                                           // Ass = 1 ist hier günstiger
                        kartenWert = 1;
                    }
                    Console.WriteLine($"Karte: {kartenWert,2}, Ihr Ergebnis ist: {kartenWertGesamtSp,2}");
                    if (kartenWertGesamtSp > 21)                                                            // Wenn der Spieler mehr als 21 hat wird der Kartenwertgesamt zutückgegeben
                    {
                        return kartenWertGesamtSp;
                    }
                    else if (kartenWertGesamtSp == 21)
                    {
                        Console.WriteLine("\nWarten auf die Bank");
                        return kartenWertGesamtSp;
                    }
                    else
                    {
                        Console.Write("Noch eine Karte (j/J/n)? ");
                        eingabe = Console.ReadLine();
                    }
                }
            }
            return kartenWertGesamtSp;                                                                      // Wenn der Spiler keine Karte mehr will wird Kartenwertgesamt zurückgegebn
        }
        #endregion

        #region Computer-Part
        static int Com()
        {
            int kartenWertCOM = 0;

            Console.WriteLine("\nCroupier bin dran.");
            while (kartenWertCOM <= 16)                                                             // Zieht bis Gesamtwert von COM > 16
            {
                int kartenWert = ZufallkarteAusgeben();                                             // Com ruft zufällige Kartenausgabe auf. Hier hat Ass immer den Wert 11
                kartenWertCOM += kartenWert;
                Console.WriteLine($"Karte: {kartenWert,2}, Ihr Ergebnis ist: {kartenWertCOM,2}");
            }
            return kartenWertCOM;                                                                   // Gibt Gesamtwert der Karten von Computer zurück
        }
        #endregion

        #region Win Lose
        static void WinLose(ref int guth, int einsatz, int comPunkte, int spielerPunkte, int spieler)       // Überprüft wer gewinnt Spieler (der die Methode aufruft) oder Computer
        {
            if (comPunkte <= 21 && (comPunkte >= spielerPunkte || spielerPunkte > 21))                      
            {
                guth -= einsatz;
                Console.WriteLine($"\nSpieler {spieler} hat verloren. Jetons jetzt: {guth}");
            }
            else
            {
                guth += einsatz;
                Console.WriteLine($"\nSpieler {spieler} hat gewonnen. Jetons jetzt: {guth}");
            }
        }
        #endregion

        #region Play-Methode
        static void Play(ref int guth1, ref int guth2)                                                  // guth1/guth2 wird ersetzt durch credit1/credit2 und durch ref kann credit1/credit2 verändert werden
        {
            int einsatz1, einsatz2;
            int count = 1;                                                                              // Count für die Rundenanzahl
            do
            {
                Console.ReadKey();
                Console.Clear();                                                                        // Bereinigt die Konsole. Das ReadKey davor verhindert, dass die Konsole direkt immer bereinigt wird

                Console.WriteLine("\n~ ~ Spieler 1: ");
                einsatz1 = EinsatzEingeben(guth1);                                                      // Gibt einsatz für Spieler 1 zurück (guth1 entspricht credit1)

                if (einsatz1 == 0)                                                                      // Wenn einsatz = 0 wird gesamte Methode sofort mittels return verlassen
                {
                    return;
                }

                Console.WriteLine("\n~ ~ Spieler 2: ");
                einsatz2 = EinsatzEingeben(guth2);                                                      // Gleiches Prinzip wie bei Spieler 1 nur für Spieler 2

                Console.WriteLine("\n~~~~~ Spieler 1: ");
                int spieler1Punkte = 0;
                for (int i = 1; i <= 2; i++)                                                            // Ausgabe 2 zufäliiger Karten
                {
                    int kartenwert = ZufallkarteAusgeben();
                    spieler1Punkte += kartenwert;
                    if (kartenwert == 11 && spieler1Punkte > 21)                                        // Wenn bei den ersten beiden Karten Ass, Ass kommt ist Ass1 = 11 und Ass2 = 1 (11-10)
                    {
                        spieler1Punkte -= 10;
                        kartenwert = 1;
                    }
                    Console.WriteLine($"Karte: {kartenwert,2}, Ihr Ergebnis ist: {spieler1Punkte,2}");
                }
                spieler1Punkte = KarteJaNein(ref spieler1Punkte);                                       // Aufruf von "Noch eine Karte?" (spieler1Punkte entspricht Gesamtwert der Karten von Spieler 1)

                Console.WriteLine("\n~~~~~ Spieler 2: ");
                int spieler2Punkte = 0;
                for (int i = 1; i <= 2; i++)
                {
                    int kartenwert2 = ZufallkarteAusgeben();
                    spieler2Punkte += kartenwert2;
                    if (kartenwert2 == 11 && spieler2Punkte > 21)
                    {
                        spieler2Punkte -= 10;
                        kartenwert2 = 1;
                    }
                    Console.WriteLine($"Karte: {kartenwert2,2}, Ihr Ergebnis ist: {spieler2Punkte,2}");
                }
                spieler2Punkte = KarteJaNein(ref spieler2Punkte);

                int comPunkte;
                if (spieler1Punkte > 21 && spieler2Punkte > 21 )                                        // Wenn beide Spieler über 21 kommen zieht der COM nicht und beide haben verloren
                {                                                                                       // indem Bedingung für verlieren schon bei Aufruf der Methode WinLose erfüllt wird 
                    WinLose(ref guth1, einsatz1, 21, spieler1Punkte, 1);                                // comPunkte = 21 automatisch gesetzt und spielerPunkte > 21 --> COM gewinnt (siehe Bedingung in Mehtode)
                    WinLose(ref guth2, einsatz2, 21, spieler2Punkte, 2);
                }
                else if (spieler1Punkte > 21 && spieler2Punkte <= 21)                                   // Wenn einer der beiden Spieler über 21 kommt hat derjenige über 21 verloren
                {
                    comPunkte = Com();                                                                  // Der COM zieht trozdem Karten wegen dem Spieler der noch unter 21 ist
                    WinLose(ref guth1, einsatz1, 21, spieler1Punkte, 1);
                    WinLose(ref guth2, einsatz2, comPunkte, spieler2Punkte, 2);
                }
                else if (spieler1Punkte <= 21 && spieler2Punkte > 21)
                {
                    comPunkte = Com();
                    WinLose(ref guth1, einsatz1, comPunkte, spieler1Punkte, 1);
                    WinLose(ref guth2, einsatz2, 21, spieler2Punkte, 2);
                }
                else if (spieler1Punkte <= 21 && spieler2Punkte <= 21)                                  // Wenn beide Spieler 21 noch nicht überschritten haben, zieht COM normal und es wird normal überprüft
                {
                    comPunkte = Com();
                    WinLose(ref guth1, einsatz1, comPunkte, spieler1Punkte, 1);
                    WinLose(ref guth2, einsatz2, comPunkte, spieler2Punkte, 2);
                }

                Console.WriteLine($"Runde {count} beendet.\n");                                         // Gibt die Runden an
                count = count + 1;
                if (guth1 == 0 || guth2 == 0)                                                           // Wenn einer der Spieler keine Chips mehr hat
                {
                    Console.WriteLine("Einer von den Spielern ist pleite! Das Spiel wird beendet.");
                }
            } while ((guth1 > 0 && guth2 > 0) && (einsatz1 != 0 && einsatz2 != 0));                     // Wiederholt solange Guthaben > 0 und einsatz != 0
        }
        #endregion

        static void Main(string[] args)
        {
            int credit1 = 10;
            int credit2 = 10;
            Play(ref credit1, ref credit2);
            Console.WriteLine("\nEndergebnisse:");
            Console.WriteLine($"Spieler 1 hat aus 10 Jetons {credit1} gemacht.");
            Console.WriteLine($"Spieler 2 hat aus 10 Jetons {credit2} gemacht.");
        }
    }
}