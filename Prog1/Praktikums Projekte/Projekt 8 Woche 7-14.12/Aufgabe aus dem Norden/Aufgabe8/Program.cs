using System;

namespace Weihnachten
{
    enum Verhalten
    {
        Frech,
        OftLieb,
        MeistLieb,
        ImmerLieb,
    }

    class Program
    {
        static void Test()
        {

            Kind k = new Kind("Aris", Verhalten.MeistLieb);
            Console.WriteLine($"{k.AlsString()}");
            Console.WriteLine($"Kind {k.Name} hat keine Wünsche: {k.Wunschlos}\n");                    // beginn keine wünsche in der Liste
            Console.WriteLine("Es werden jetzt Wünsche hinzugefügt:");
            k.WunschAnhaengen("Sandspielzeug");
            k.WunschAnhaengen("Bausteine");
            k.WunschAnhaengen("Puppen");
            k.WunschAnhaengen("Tennisschläger");                                                       // Wunsch zu viel wird ignoriert
            Console.WriteLine(k.WunschAusgeben()); 
            Console.WriteLine($"\nKind {k.Name} hat keine Wünsche: {k.Wunschlos}");                    // nachdem Wünsche zugrfügt wurden ist es false
            Console.WriteLine($"\nKind {k.Name} war lieb: {k.WarLieb}");
            Console.WriteLine();
            Console.WriteLine($"Wunsch schon vorhanden: {k.HatWunsch("Bausteine")}");                  // Prüft ob Bausteine in der Wunschliste schon vorkommt
            Console.WriteLine("\nBessert sich wird aufgerufen:");
            k.BessertSich();
            Console.WriteLine($"{k.AlsString()}");
            Console.WriteLine("\nMethode Serialize():\n");
            Console.WriteLine(k.Serialize());                                                                         // übernimmt die Werte nicht
            Console.WriteLine("\nMethode Deserialize():\n");

            string s = "Aris,MeistLieb:Sandspielzeug,Bausteine,Puppen";
            Kind k2 = Kind.Deserialize(s);
            Console.WriteLine( k2.Serialize() );
            Console.WriteLine("\n\nNeuer Abschnitt: ---------------------------------------------\n");


            Kinderliste liste = new Kinderliste(10);
            liste.KindEintragen(k);                                                                                                                     // Aris wir eingetragen

            liste.KindEintragen(new Kind("Anton", Verhalten.ImmerLieb, new string[] { "Spielzeugauto", "Bausteine" }));
            liste.KindEintragen(new Kind("Emma", Verhalten.Frech, new string[] { "Spielekonsole" }));
            liste.KindEintragen(new Kind("Mehmet", Verhalten.OftLieb, new string[] { "Bausteine", "Spielesammlung", "Sandspielzeug", "Computer" }));
            liste.KindEintragen(new Kind("Esra", Verhalten.MeistLieb, new string[] { "Handy", "Kinogutschein" }));
            liste.KindEintragen(new Kind("Anna", Verhalten.OftLieb, new string[] { "Musikstream", "Chemiebaukasten" }));
            liste.KindEintragen(new Kind("Azra", Verhalten.MeistLieb, new string[] { "Elektronik-Baukasten", "Computer", "Handy" }));
            liste.KindEintragen(new Kind("Hans", Verhalten.Frech, new string[] { "Spielzeugautos", "Kinogutscheine" }));
            liste.KindEintragen(new Kind("Egon", Verhalten.ImmerLieb, new string[] { "Puppen", "Spielekonsole" }));
            liste.KindEintragen(new Kind("Marie", Verhalten.MeistLieb, new string[] { "Handy", "Spielekonsole" }));

            liste.Speichern("liste1.txt");

            
            Console.WriteLine($"Anzahl lieber Kinder: {liste.AnzahlLieberKinder}");
            Console.WriteLine("So oft wünschen sich Kinder ...");
            foreach (string wunsch in new string[] { "Handy", "Computer", "Spielekonsole", "Bausteine", "Puppen" })
                Console.WriteLine($"... {wunsch}:   {liste.ZaehleKinderMitWunsch(wunsch)}");

            Console.WriteLine("\nKinderliste laden:\n");
            Kind[] liste2 = Kinderliste.Laden("liste1.txt");
            foreach (Kind child in liste2)
            {
                Console.WriteLine(child.Serialize()); 
            }

            /*Kinderliste liste3 = new Kinderliste(20);
            foreach (Kind klein in liste2)
            {
                liste3.KindEintragen(klein);
            }*/
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
