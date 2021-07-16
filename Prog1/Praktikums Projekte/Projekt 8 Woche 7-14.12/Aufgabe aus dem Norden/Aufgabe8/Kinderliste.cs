using System;
using System.IO;

namespace Weihnachten
{
    class Kinderliste
    {
        #region Variablen für Klasse Kinderliste
        int anzahlLieberKind = 0;
        int kindCounter = 0;                                                                    // index für Kinder in einer Liste
        #endregion

        Kind[] liste;                                                                           // array vom typ Kind wird inziert

        public int AnzahlLieberKinder { get { return LiebAnzahl(); } }                          // read-only Property

        public Kinderliste(int anzahl)
        {
            liste = new Kind[anzahl];                                                           // erzeugt ein leeres array mit der länge = anzahl
        }

        #region Methoden

        public static Kind[] Laden(string dateName)
        {
            int zeilenAnzahl = 0;
            FileStream t = new FileStream(@$"C:\Users\David\Desktop\Schule\Prog1 Projekte\Praktikums Projekte\Projekt 8Woche 7-14.12\Aufgabe aus dem Norden\{dateName}", FileMode.Open);

            StreamReader r = new StreamReader(t);
            string line = r.ReadLine();

            while (line != null)
            {
                zeilenAnzahl++;
                line = r.ReadLine();
            }
            Kind[] neuListe = new Kind[zeilenAnzahl];
            r.Close();

            t = new FileStream(@$"C:\Users\David\Desktop\Schule\Prog1 Projekte\Praktikums Projekte\Projekt 8Woche 7-14.12\Aufgabe aus dem Norden\{dateName}", FileMode.Open);
            StreamReader s = new StreamReader(t);
            string line2 = s.ReadLine();
            while (line2 != null)
            {
                if (line2 == "")
                {
                    line2 = s.ReadLine();
                }
                else
                {
                    for (int i = 0; i < neuListe.Length; i++)
                    {
                        if (Kind.Deserialize(line2) == null)
                        {
                            return null;
                        }
                        else
                        {
                            neuListe[i] = Kind.Deserialize(line2);
                        }
                        line2 = s.ReadLine();
                    }
                }
            }

            return neuListe;
            s.Close();
        }

        public void Speichern(string dateName)
        {
            FileStream f = new FileStream(@$"C:\Users\David\Desktop\Schule\Prog1 Projekte\Praktikums Projekte\Projekt 8Woche 7-14.12\Aufgabe aus dem Norden\{dateName}", FileMode.Create);

            StreamWriter w = new StreamWriter(f);

            for (int i = 0; i < liste.Length; i++)
            {
                w.WriteLine(liste[i].Serialize());
            }
            w.Close();
        }


        public void KindEintragen(Kind kind)                                                    // trägt ein Kind in Liste ein
        {
            if (kindCounter < liste.Length)
            {
                liste[kindCounter] = kind;
                kindCounter++;
            }
            else
            {
                Console.WriteLine("Kind kann nicht eingetragen werden, Liste ist voll.");
            }
        }

        private int LiebAnzahl()                                                                // prüft wie viele Kinder lieb sind
        {
            for (int i = 0; i < liste.Length; i++)                                              // geht liste komplett durch
            {
                if (liste[i].WarLieb)                                                           // ruft für jedes element in der liste WarLieb property von Klasse Kind auf
                {
                    anzahlLieberKind++;
                }
            }
            return anzahlLieberKind;
        }

        public int ZaehleKinderMitWunsch(string wunsch)                                         // prüft bei allen Kindern in der Liste, ob wunsch ,ehrfach vorhanden
        {
            int counter2 = 0;                                                                   // nach jedem durchlauf von wunsch wird counter zurückgesetzt
            foreach (Kind k2 in liste)
            {
                if (k2.HatWunsch(wunsch))                                                       // ruft für jedes Kind HatWunsch() Methode in Klasse Kind auf
                {
                    counter2++;
                }
            }
            return counter2;                                                                    // Anzahl der gleichen Wünsche wie wunsch wird zurückgegeben
        }
        #endregion
    }
}
