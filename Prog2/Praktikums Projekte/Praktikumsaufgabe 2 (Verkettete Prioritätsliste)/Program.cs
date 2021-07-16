using System;

namespace Praktikumsaufgabe_2__Verkettete_Prioritätsliste_
{
    class Program
    {
        static void Main(string[] args)
        {
            PrioListe pl = new PrioListe();
            pl.Einfuegen(" 9 Auto waschen", Prioritaet.niedrig);
            pl.Einfuegen(" 6 Milch kaufen");
            pl.Einfuegen(" 2 Brot nicht vergessen", Prioritaet.hoch);
            pl.Einfuegen(" 3 Brief einwerfen", Prioritaet.hoch);
            pl.Einfuegen(" 1 Praktikumsaufgabe hochladen", Prioritaet.top);
            pl.Einfuegen(" 7 Praktikumsergebnisse anschauen");
            pl.Einfuegen(" 4 Muttertagsgeschenk 9.5.", Prioritaet.hoch);
            pl.Einfuegen("10 Weihnachtsgeschenke überlegen", Prioritaet.niedrig);
            pl.Einfuegen(" 8 Listenstrukturen noch einmal durcharbeiten");
            pl.Einfuegen(" 5 Steuererklärung bis 2.8.2021", Prioritaet.hoch);
           /* pl.Einfuegen(" test4", Prioritaet.niedrig);
            pl.Einfuegen(" test1");
            pl.Einfuegen(" test2", Prioritaet.top);
            pl.Einfuegen(" test3", Prioritaet.hoch);*/
            pl.Ausgeben();

            // NaechsteAufgabe() Test

           /* Console.WriteLine();
            pl.NaechsteAufgabe();
            Console.WriteLine();
            pl.Ausgeben();
            Console.WriteLine();
            pl.NaechsteAufgabe();
            Console.WriteLine();
            pl.Ausgeben();*/
        }
    }
}
