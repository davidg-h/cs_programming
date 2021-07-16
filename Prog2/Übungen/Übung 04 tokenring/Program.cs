using System;

namespace Übung_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endInput = false;
            Network n1 = new Network();

            while (!endInput)
            {
                Console.WriteLine();
                Console.Clear();
                n1.Print();

                Console.WriteLine("\nMenü:");
                Console.WriteLine("(1) Neue Geräte hinzufügen");
                Console.WriteLine("(2) Gerät entfernen");
                Console.WriteLine("(3) Datenpaket versenden");
                Console.WriteLine("(4) Programm beenden");

                Console.Write("> ");
                string input = Console.ReadLine();

                if (input == "4")
                {
                    endInput = true;
                }

                if (n1.Head == null)
                {
                    Cases2(input, ref n1);
                }
                else
                {
                    Cases(input, ref n1);
                }
                Console.WriteLine("\nPress any key to clear the console.");
                Console.ReadLine();
            }
        }


        static void Cases(string input, ref Network network)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nNeue Geräte hinzufügen...");

                    Console.Write("Adresse des Vorgänger-Geräts > ");
                    string previousAdress = Console.ReadLine();
                    int adress = Int32.Parse(previousAdress);

                    Console.Write("Anzahl neuer Geräte > ");

                    int number = Int32.Parse(Console.ReadLine());

                    for (int i = 0; i < number; i++)
                    {
                        network.AddAfter(adress);
                        adress = network.Find(adress).Next.adress;
                    }

                    break;
                case "2":
                    Console.WriteLine("\nGerät entfernen...");
                    Console.Write("Adresse des Geräts > ");

                    int removeAdress = Int32.Parse(Console.ReadLine());
                    network.Remove((int)removeAdress);

                    break;

                case "3":
                    Console.WriteLine("\nDatenpaket versenden...");
                    Console.Write("Datenwert: ");
                    string data = Console.ReadLine();
                    Console.Write("Adresse des Senders: ");
                    int transmitter = Int32.Parse(Console.ReadLine());
                    Console.Write("Adresse des Empfängers: ");
                    int receiver = Int32.Parse(Console.ReadLine());

                    Simulator.Start(data, transmitter, receiver, network);
                    break;

                default:
                    Console.WriteLine("\nFalsche Eingabe. Bitte beachten Sie das Menü.");
                    break;
            }
        }

        static void Cases2(string input, ref Network network)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine("\nNeue Geräte hinzufügen...");
                    Console.Write("Anzahl neuer Geräte > ");

                    int number = Int32.Parse(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                    {
                        network.Add();
                    }

                    break;
                case "2":
                    Console.WriteLine("\nEs kann kein Element entfernt weden, dass nicht existiert.");
                    break;
                case "3":
                    Console.WriteLine("\nDatenversand nicht möglich: Keine Geräte zum Versand vorhanden.");
                    break;

                default:
                    Console.WriteLine("\nFalsche Eingabe. Bitte beachten Sie das Menü.");
                    break;
            }
        }


    }
}
