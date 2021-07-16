using System;

namespace Hangman
{
    class Program
    {
        #region Zufallswort
        static string randomWord()
        {
            // Wörter die zur Auswahl stehen
            string[] wordsTablle = new string[] 
            { "Kokosnuss", "Glurak", "Audi", "Baseball", "Tohuwabohu", "Aftershave", "Wassersuppe", "Eis", "Flitzpiepe", "Lappen", "Endboss Superkalifragilistikexpialigetisch" };

            // erzeugt eine zufällige zahl die dann das Wort am Index der Tabelle aufruft
            Random wuerfeln = new Random();
            int zufallsZahl = wuerfeln.Next(wordsTablle.Length);
            string secretWord = wordsTablle[zufallsZahl];
            return secretWord;
        }
        #endregion

        #region Spielverlauf
        static void Spielverlauf(string suchwort, string geheimwort, int count = 0)                         // hier wird verglichen ob ein richtiger buchstabe eingegeben wird
        {
            while (count < 5 && suchwort != geheimwort)                                                     // schleife die wiederholt solange Fehler < 5 und das wort nicht erraten wurde
            {
                Console.Write("\nBuchstaben eingeben: ");

                char user = Char.ToLower(Console.ReadKey().KeyChar);                                        // user gibt einen Buchstaben ein; Groß- und Kleinschreibung wird hier immer auf klein umgewandelt

                string zwSpeicher = "";                                                                     // Zwischenspeicher für das suchwort
                bool treffer = false;
                for (int i = 0; i < geheimwort.Length; i++)                                                 // das Wort ist im Prinzip ein array von chars, also werden die chars einzeln durchgegangen
                {
                    if (user == geheimwort[i])                                                              // wenn die eingabe vom user dem char an der stelle i des string array entspricht hat er richtig geraten                                      
                    {
                        treffer = true;
                        zwSpeicher += user;                                                                 // blendet den richtig eratenen buchstaben auf
                    }
                    else
                    {
                        zwSpeicher += suchwort[i];                                                          // alle anderen stellen/chars werden mit '-' weiter dargestellt
                    }
                }
                suchwort = zwSpeicher;                                                                      // suchwort wird überschrieben, damit eingeblendeter buchstabe bleibt

                if (treffer == false)
                {
                    count++;                                                                                // fehlerzähler erhöht
                    Console.WriteLine($"\nDas geheime Wort ist: {suchwort} --> {user} ist falsch!");
                    Console.WriteLine($"{count} von 5 Fehlern\n");
                }
                else
                {
                    Console.WriteLine($"\nDas geheime Wort ist: {suchwort} --> {user} ist richtig!");
                }
            }
            if (suchwort == geheimwort)
            {
                Console.WriteLine("Du hast gewonnen");
            }
            else                                                                                            // beendet das spiel bei 5 fehlern
            {
                Console.WriteLine("VERLOREN! Das Spiel wird jetzt beendet.");
                Environment.Exit(0);
            }
        }
        #endregion

        #region Wiederholen
        static bool Loop(ref int repeater)                                                                  // repeater gibt rundenanzahl an
        {
            Console.Write("\nNochmal? (j/n): ");
            string eingabe = Console.ReadLine();
            if (eingabe.ToLower() == "j" || eingabe.ToLower() == "ja")                                      // eingabe wird auf kleinbuchstaben umgewandelt
            {
                repeater++;
                Console.Clear();                                                                            // leert die console
                return true;
            }
            else
            {
                Console.WriteLine("Sie haben etwas anders außer 'j'/'ja' eingegeben. Spiel wird beendet.");
                return false;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            int repeater = 0;                                                                       
            do
            {
                Console.WriteLine("Hangman\n=======\n");

                string zwischenSpeicher = randomWord();                                                 // zufallswort wird aufgerufen
                string geheimWort = zwischenSpeicher.ToLower();                                         // komplettes zufallswort wird in kleinbuchstaben umgewandelt
                Console.WriteLine($"Gesucht ist ein Wort mit {geheimWort.Length} Buchstaben");

                string suchWort = "";
                for (int i = 0; i < geheimWort.Length; i++)                                             // schleife läuft die länge des geheimwortes durch 
                {
                    suchWort += "-";                                                                    // ein string wird erstellt mit '-' an der stelle von einem buchstaben 
                }
                Console.WriteLine($"Das geheime Wort ist: {suchWort}\n");

                Console.WriteLine($"\nRunde: {repeater+1}");
                Spielverlauf(suchWort, geheimWort);
            } while (Loop(ref repeater));
        }
    }
}
