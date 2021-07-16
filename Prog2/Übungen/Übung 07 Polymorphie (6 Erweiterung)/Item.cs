using System;

namespace Übung_6_Vererbung
{
    class Cart
    {
        Item[] shoppingCart;
        public Cart(params Item[] cartItems)
        {
            shoppingCart = cartItems;
        }

        public void AllPrice()
        {
            double allPrice = 0;
            foreach (var item in shoppingCart)
            {
                allPrice += item.Price;
            }
            Console.WriteLine($"\nGesamtpreis: {allPrice}");
        }

        public void AllInfo()
        {
            Console.WriteLine("\nAlle Infos aus dem Warenkorb:");
            string all = "";
            foreach (var item in shoppingCart)
            {
                all += item.FullInfo();
            }
            Console.WriteLine(all);
        }
    }

    class Item
    {
        protected int id;
        protected double price;
        protected static int counter = 0;

        public double Price { get { return price; } set { price = value; } }
        public int ID => id;

        protected Item(double price)
        {
            Price = price;
            id = counter;
            counter++;
        }

        public virtual string FullInfo()
        {
            return $"ID: {ID}\nPreis: {Price}";
        }
    }

    class Book : Item
    {
        string autor, titel, publisher;

        //public string FullInfo { get { return $"Buch\nID : {ID}\nPreis: {Price}\n{FullTitel}"; } }
        public string FullTitel { get { return "Autor: "+ autor + ", " + "Titel: " + titel + ", " + "Verlag: " + publisher; } }

        public Book(string autor, string titel, string publisher, double price) : base(price)
        {
            this.autor = autor;
            this.titel = titel;
            this.publisher = publisher;
        }

        public override string FullInfo()
        {
            return $"\nBuch\n{base.FullInfo()}\n{FullTitel}";
        }
    }

    class CD : Item
    {
        string artist, recordName;
        int trackCount;

        //public string FullInfo { get { return $"CD\nID : {ID}\nPreis: {Price}\n{FullTitel} \nAnzahl der Lieder: {TrackCount}"; } }
        public string FullTitel { get { return "Künstler: " + artist + ", " + "Albumname: " + recordName; } }
        public int TrackCount => trackCount;

        public CD(string artist, string recordName, int trackCount, double price) : base(price)
        {
            this.artist = artist;
            this.recordName = recordName;
            this.trackCount = trackCount;
        }

        public override string FullInfo()
        {
            return $"\nCD\n{base.FullInfo()}\n{FullTitel}\nAnzahl der Lieder: {TrackCount}";
        }
    }

    class Video : Item
    {
        string titel, director;
        bool dlc;

        //public string FullInfo { get { return $"Video\nID : {ID}\nPreis: {Price}\n{FullTitel} \nAls Dlc verfügbar: {Dlc}"; } }
        public string FullTitel { get { return "Titel: "+ titel + ", " + "Regisseur: " + director; } }
        public bool Dlc { get { return dlc; } }

        public Video(string titel, string director, bool dlc, double price) : base(price)
        {
            this.titel = titel;
            this.director = director;
            this.dlc = dlc;
        }

        public override string FullInfo()
        {
            return $"\nVideo\n{base.FullInfo()}\n{FullTitel}\nAls Dlc verfügbar: {Dlc}";
        }
    }
}
