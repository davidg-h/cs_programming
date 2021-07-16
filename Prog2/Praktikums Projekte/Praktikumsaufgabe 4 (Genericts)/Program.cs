using System;

namespace Praktikumsaufgabe_4__Generics_
{
    class Program
    {
        static void Main(string[] args)
        {
            VaccPerson p1 = new VaccPerson("Meier", "Möhrenweg 3", "049");
            VaccPerson p2 = new VaccPerson("Nils", "Zambellistr. 15", "050");
            VaccPerson p3 = new VaccPerson("Hans", "Odenwalsalle 2", "051");
            VaccPerson p4 = new VaccPerson("Sofie", "Mond 3", "052");


            VaccinationQueue<VaccPerson, VaccCat> vQ1 = new VaccinationQueue<VaccPerson, VaccCat>();

            vQ1.RegisterPerson(p1, VaccCat.eighty);
            vQ1.RegisterPerson(p2, VaccCat.sixtyOrLower);
            vQ1.RegisterPerson(p3, VaccCat.eighty);
            vQ1.RegisterPerson(p4, VaccCat.seventy);

            Console.WriteLine("Vaccination-Queue:");
            Console.WriteLine(vQ1);
            /* Console.WriteLine("Vaccinating the first in Queue");  //comment out for Vaccinate()
             Console.WriteLine(vQ1.Vaccinate());
             Console.WriteLine(vQ1);*/

            Console.WriteLine("Vaccinating whole category:\n");
            Console.WriteLine("Array of vaccinated people:");
            VaccPerson[] vacArr = vQ1.VaccinateWholeCat();
            foreach (var item in vacArr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("The rest of the VaccinationQueue:");
            Console.WriteLine(vQ1);

            Console.WriteLine("Vaccinating the last two and printing the list again:\n");
            vQ1.Vaccinate();
            vQ1.Vaccinate();
            try
            {
                Console.WriteLine(vQ1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
