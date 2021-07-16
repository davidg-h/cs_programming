using System;
using System.IO;

namespace Aufgabe5
{

    ////////////////////////////////////////////////////////////////////////////////
    /// Aufgabe 5 - Dateiauswertung
    /// David Nguyen Matrikelnummer: 3548145
    /// Erreichte Punktzahl:
    ////////////////////////////////////////////////////////////////////////////////

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dateiauswertung! VIEL ERFOLG!");
            Console.WriteLine("Bitte oben Name und Matrikelnummer eintragen!!!");

            FileStream f = new FileStream(@"..\..\..\Wetterdaten.txt", FileMode.Open);
            StreamReader s = new StreamReader(f);

            int langerSonnenschein = 0;
            bool istSonnenschein = false;
            s.ReadLine();                                                                                           // erste Zeile wird übersprungen
            string line = s.ReadLine();
            string date = "";

            while (line != null)
            {
                line = line.Replace('.', ',');
                string[] subs = line.Split(';');

                double sonnenscheinDauer = Double.Parse(subs[subs.Length - 3]);

                if (sonnenscheinDauer >= 10)
                {
                    if (istSonnenschein == false)
                    {
                        date = $"{subs[1].Substring(6, 2)}.{ subs[1].Substring(4, 2)}.{subs[1].Substring(0, 4)}";   // date wird überschieben
                    }
                    istSonnenschein = true;
                }
                else
                {
                    istSonnenschein = false;
                }

                if (istSonnenschein)
                {
                    langerSonnenschein++;
                }
                else
                {
                    if (langerSonnenschein >= 10)
                    {
                        Console.WriteLine($"{langerSonnenschein} Tage Schönwetter ab dem {date}");
                    }
                    langerSonnenschein = 0;
                }
                line = s.ReadLine();
            }
            s.Close();
        }
    }
}
/*12 Tage Schönwetter ab dem 28.06.1957
11 Tage Schönwetter ab dem 28.08.1958
10 Tage Schönwetter ab dem 05.07.1959
10 Tage Schönwetter ab dem 08.08.1973
13 Tage Schönwetter ab dem 30.06.1976
10 Tage Schönwetter ab dem 23.05.1977
11 Tage Schönwetter ab dem 09.07.1983
11 Tage Schönwetter ab dem 25.06.1986
10 Tage Schönwetter ab dem 20.07.1990
10 Tage Schönwetter ab dem 13.05.1992
13 Tage Schönwetter ab dem 01.08.2003
10 Tage Schönwetter ab dem 01.09.2004
13 Tage Schönwetter ab dem 09.07.2006
10 Tage Schönwetter ab dem 05.09.2006
10 Tage Schönwetter ab dem 24.06.2010*/