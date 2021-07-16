using System;

namespace Bootsverleih
{
    class Bootsverleih
    {
        Boot[] boot;

        public Bootsverleih(params Boot[] booten)
        {
            boot = booten;                                  
        }

        public int Bestand(BootArt b)
        {
            int anzahl = 0;
            for (int i = 0; i < boot.Length; i++)
            {
                if (b == boot[i].Art)                           // wenn übergebene BootArt gleich dann erhöhe anzahl
                {
                    anzahl++;
                }
            }
            return anzahl;
        }
    }


    class Boot
    {
        static int nummer = 1;                                  // eindeutige Nummer
        string typ;
        int id, anzahlPersonen;
        BootArt art;

        public BootArt Art { get; }

        public int NaechsteNr { get => nummer; }                // nächste zu vergebene Nummer

        public string Typ
        {
            get { return typ; }
            set
            {
                if (value.Length >= 4)                          // mindestens 4 Zeichen
                {
                    typ = value;
                }
                else
                {
                    throw new ArgumentException("zu wenig Zeichen");
                }
            }
        }

        public int AnzahlPersonen
        {
            get { return anzahlPersonen; }
            set
            {
                if (value < 20)                                 // Personenanzahl muss unter 20 sein
                {
                    anzahlPersonen = value;
                }
                else
                {
                    throw new ArgumentException("Personenanzahl über 20");
                }
            }
        }

        public Boot(string typ, int personen, BootArt art = BootArt.Ruder)
        {
            id = nummer;                                        // zuweisung der ID 
            nummer++;
            if (typ.Length >= 4)
            {
                Typ = typ;
            }
            else
            {
                throw new ArgumentException("zu wenig Zeichen");
            }

            if (personen < 20)
            {
                AnzahlPersonen = personen;
            }
            else
            {
                throw new ArgumentException("Personenanzahl über 20");
            }
            this.art = art;
        }

        public string ToString()                                                        // Komplette ausgabe des Objekts
        {
            string s = $"{this.id}. {Art}-Boot {Typ}, ({AnzahlPersonen} Pers.)";
            return s;
        }
    }

}
