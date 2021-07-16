using System;

namespace Praktikumsaufgabe_1
{
    class CMySentence
    {
        CMyWord[] myWords;

        public CMyWord[] MyWords => myWords;

        public CMySentence(string s)
        {
            string[] arr = s.Split(' ');                        // Der Satz wird in Einzelteile aufgespalten

            myWords = new CMyWord[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                myWords[i] = new CMyWord(arr[i]);               // Jedem Wort (string) wird ein Objekt zugewiesen und in der Objekt-Liste gepeichert
            }
        }

        public CMyWord this[int index]                          // Gibt das Objekt von der myWords Liste am Index zurück
        {
            get { return myWords[index]; }                      // Objekte von Typ CMyWord mit einem string
        }

        public static explicit operator int(CMySentence s)      // überladung von int für Zeile 22 in der Main
        {
            return s.MyWords.Length;
        }
    }
}
