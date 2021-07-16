using System;

namespace Weihnachten
{
    class Kind
    {
        #region Variablen für Klasse Kind
        private bool aussage;                                               // Speicher für Wunschlos angaben (true/false)                                                                
        private bool aussage2;                                              // Speicher für WarLieb property
        string[] wunschListe = new string[3];                               // Jedes Kind hat kann 3 Wünsche angeben
        #endregion

        #region Propertys
        public string Name { get; private set; }                            // Name des Kindes muss beim instanzieren angegeben werden und kann nicht mehr verändert werden vom objekt
        public int Benehmen { get; private set; }                           // gleiches gilt für das Verhalten
        public bool Wunschlos
        {
            get { return aussage; }
            set
            {
                foreach (string s in wunschListe)
                {
                    if (s == null)                                          // falls kein Wunsch im Array wunschListe vorhanden ist, wird die aussage = true gesetzt und somit ist Wunschlos auch true
                    {
                        aussage = true;
                    }
                    else
                    {
                        aussage = false;
                    }
                }
            }
        }

        public bool WarLieb
        {
            get { return aussage2; }
            private set
            {
                if (Benehmen != 0)                                          // alles außer Frech ist Lieb, also aussage2 = true;
                {
                    aussage2 = true;
                }
                else
                {
                    aussage2 = false;
                }
            }
        }
        #endregion

        #region Konstruktoren


        public Kind(string name, Verhalten v)                                                       // Konstruktor für Kinder die nicht sofort eine Wunschliste mitgeben 
        {
            Name = name;
            Benehmen = (int)v;                                                                      // Enum Verhalten wird in eine int umgewandelt. (zählen fängt immer bei 0 an)
            Wunschlos = aussage;                                                                    // prüft zu Beginn, ob das Kind eine Wunschliste hat oder nicht und wird aufgerufen, damit property es setzten kann
            WarLieb = aussage2;                                                                     // Property warlieb setzt hier die aussage2
        }

        public Kind(string name, Verhalten v, string[] geschenkListe)                               // Überladen des Konstruktor für Kinder die gleich eine Wunschliste mitgeben
        {
            Name = name;
            Benehmen = (int)v;
            WarLieb = aussage2;

            for (int i = 0, s = 0; i < wunschListe.Length && s < geschenkListe.Length; i++, s++)    // Wiederholt solange <= 3 Wünschen sind, alle anderen werden ignoriert
            {
                wunschListe[i] = geschenkListe[s];                                                  // Wünsche werden in die Liste eingespeichert
            }
            Wunschlos = aussage;
        }
        #endregion

        #region Methoden

        public static Kind Deserialize(string s)
        {
            char[] seperators = new char[] { ',', ':' };

            string[] subs = s.Split(seperators, StringSplitOptions.RemoveEmptyEntries);                 // trennt den string auf
            string[] nameVerhalten = { subs[0], subs[1] };                                              // enthält name an [0] und Verhalten an [1]
            Kind neuk;

            if (subs[0] != "" && Enum.TryParse(typeof(Verhalten), subs[1], out object result))          // wenn es einen namen gibt und das Verhalten umgewandelt werden kann
            {
                Verhalten v = (Verhalten)result;
                //Console.WriteLine(v);
                if (subs.Length == 2)                                                                   // wenn keine Geschenke angegeben wurden
                {
                    neuk = new Kind(nameVerhalten[0], v);
                }
                else
                {
                    string[] liste = new string[subs.Length - 2];                                       // geschenke in eine string array übertragen
                    for (int i = 0; i < subs.Length - 2; i++)
                    {
                        liste[i] = subs[2 + i];
                    }
                    neuk = new Kind(nameVerhalten[0], v, liste);
                }
                return neuk;
            }
            else
            {
                return null;
            }
        }



        public string Serialize()
        {
            string line = $"{AlsString()}:{WunschAusgeben()}" ;
            return line;
        }


        public bool WunschAnhaengen(string wunsch)                          // fügt Wünsche der Liste hinzu
        {
            bool klappt = false;
            for (int i = 0; i < wunschListe.Length; i++)                    // geht die Elemnte der Wunschliste durch
            {
                if (wunschListe[i] == null)                                 // wenn an dem Index 'i' kein Wunsch ist soll er den neuen Wunsch hinzufügen und true zurückgeben
                {
                    wunschListe[i] = wunsch;
                    Wunschlos = aussage;                                    // ruft das Property Wunschlos auf bzw setzt es
                    return true;
                }
                else
                {
                    klappt = false;
                }
            }
            return klappt;
        }

        public string WunschAusgeben()                                        // gibt alle elemente in der wunschListe aus
        {
            string geschenke = "";
            int commaCounter = 1;
            foreach (string s in wunschListe)
            {
                
                if (commaCounter < wunschListe.Length && s!=null)
                {
                    geschenke += s;
                    geschenke += ",";
                }
                commaCounter++;
            }
           return geschenke;
        }

        public bool HatWunsch(string bezeichner)                            // prüft ob der Wunsch schon mal in der Liste vorkommt
        {
            int counter = 0;                                                // counter für die Anzahl des Vorkommens
            foreach (string item in wunschListe)
            {
                if (item == bezeichner)
                {
                    counter++;                                              // erhöht wenn Wunsch vorkommt
                }
            }

            if (counter > 0)                                                // wenn gleicher Wunsch vorkommt dann return true
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int BessertSich()                                            // erhöht das Verhalten um eine Stufe
        {
            Benehmen += 1;
            return Benehmen;
        }

        public string AlsString()                                           // gibt namen und Verhalten zurück
        {
            string ausgabe = $"{Name},{(Verhalten)Benehmen}";              // aufruf von Verhalten am index Benehmen
            return ausgabe;
        }
        #endregion
    }
}
