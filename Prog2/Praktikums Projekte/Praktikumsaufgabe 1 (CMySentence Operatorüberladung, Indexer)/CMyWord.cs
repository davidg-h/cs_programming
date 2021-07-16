using System;

namespace Praktikumsaufgabe_1
{
    class CMyWord
    {
        String zeichenkette;
        public String Zeichenkette
        {
            get { return zeichenkette; }
            set { zeichenkette = value; }
        }
        public CMyWord()
        {
            zeichenkette = "";
        }
        public CMyWord(String s)
        {
            zeichenkette = s;
        }
        public CMyWord(CMySentence s)                           // Liste der Wörter in s enthalten
        {
            string sentence = "";
            for (int i = 0; i < s.MyWords.Length; i++)
            {
                sentence += s.MyWords[i].Zeichenkette;          // Satz wird wieder zusammengesetzt
                if (i < s.MyWords.Length - 1)
                {
                    sentence += " ";
                }
            }
            Zeichenkette = sentence;                            // übertrag des satzes auf CMyWord objekt
        }

        public CMyWord(CMyWord w): this(w.Zeichenkette)         // Konstruktor ruft Konstruktor mit string als parameter auf
        {
        }

        public override string ToString()                       // Überschreiben der Methode, damit WriteLine in Main Zeile 12 und folgende funktionieren
        {
            return Zeichenkette;
        }

       /* public static implicit operator string(CMyWord word)
        {
            return word.Zeichenkette;
        }*/

        public string this[string s]                            // Indexer für die Shakespeare Zeile
        {
            get
            {
                string zeichenkette = "";
                for (int i = s.Length - 1; i > 0; i--)
                {
                    zeichenkette += s[i];                       // string wird umgedreht
                }
                return zeichenkette;                            // Aufrufer wird als string zurückgegeben
            }
        }

        public static CMyWord operator +(CMyWord s, CMyWord t)          // Addieren 2 Objekte zu einem Objekt
        {
            return new CMyWord($"{s.Zeichenkette} {t.Zeichenkette}");
        }
        public static CMyWord operator +(string s, CMyWord t)           // Addieren von string und Objekt (Main Zeile 15)
        {
            return new CMyWord($"{s}{t.Zeichenkette}");
        }
        public static CMyWord operator +(CMyWord s, string t)           // Objekt und string (Main zeile 15)
        {
            return new CMyWord($"{s.Zeichenkette}{t}");
        }


        public static string operator -(CMyWord s, CMyWord t)           // 2 Objekte mit string
        {
            return s.Zeichenkette.Replace(t.Zeichenkette, "");          // string eines Objektes wird auf das vorkommen des anderen strings untersucht und ersetzt
        }                                                               // gibt dann string für die Ausgabe zurück

        public static string operator |(CMyWord w, string t)
        {
            return w.Zeichenkette + "oder " + t;                        // wenn (objekt | string) dann wird | ersetzt durch string
        }

        public static string operator !(CMyWord s)
        {
            return "nicht " + s.Zeichenkette;
        }

        public static bool operator true(CMyWord s)                     // nimmt an dass objekt s true ist
        {                                                               // prüft dann Länge von string von s auf deren Wahrheitswert
            return s.Zeichenkette.Length > 20;                          // bei true wird ausgeführt sonst nicht
        }

        public static bool operator false(CMyWord s)
        {
            return s.Zeichenkette.Length <= 20;
        }

        public static CMyWord operator *(CMyWord s, int x)              // wiederholt zeichenkette um x mal
        {
            string temp = "";
            for (int i = 0; i < x; i++)
            {
                temp += s.Zeichenkette;                                 // wird immer neu ergänzt
                if (i < x - 1)
                {
                    temp += " ";
                }
            }
            s.Zeichenkette = temp;
            return s;
        }

        public static bool operator ==(CMyWord s, CMyWord t)            // vergleicht die strings 2er Objekte
        {
            if (s.Zeichenkette == t.Zeichenkette)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(CMyWord s, CMyWord t)            // weil == nicht alleine überladen werden kann
        {
            return false;
        }
    }
}
