using System;

namespace Übung_6_Vererbung
{
    class Item
    {
        protected int id;
        protected double price;
        protected static int counter = 0;

        public double Price => price;
        public int ID => id;

        protected Item(double price)
        {
            this.price = price;
            id = counter;
            counter++;
        }
    }

    class Book : Item
    {
        string autor, titel, publisher;

        public string FullInfo { get { return $"Buch\nID : {ID}\nPreis: {Price}\n{FullTitel}"; } }
        public string FullTitel { get { return "Autor: "+ autor + ", " + "Titel: " + titel + ", " + "Verlag: " + publisher; } }

        public Book(string autor, string titel, string publisher, double price) : base(price)
        {
            this.autor = autor;
            this.titel = titel;
            this.publisher = publisher;
        }
    }

    class CD : Item
    {
        string artist, recordName;
        int trackCount;

        public string FullInfo { get { return $"CD\nID : {ID}\nPreis: {Price}\n{FullTitel} \nAnzahl der Lieder: {TrackCount}"; } }
        public string FullTitel { get { return "Künstler: " + artist + ", " + "Albumname: " + recordName; } }
        public int TrackCount => trackCount;

        public CD(string artist, string recordName, int trackCount, double price) : base(price)
        {
            this.artist = artist;
            this.recordName = recordName;
            this.trackCount = trackCount;
        }
    }

    class Video : Item
    {
        string titel, director;
        bool dlc;

        public string FullInfo { get { return $"Video\nID : {ID}\nPreis: {Price}\n{FullTitel} \nAls Dlc verfügbar: {Dlc}"; } }
        public string FullTitel { get { return "Titel: "+ titel + ", " + "Regisseur: " + director; } }
        public bool Dlc { get { return dlc; } }

        public Video(string titel, string director, bool dlc, double price) : base(price)
        {
            this.titel = titel;
            this.director = director;
            this.dlc = dlc;
        }
    }
}
