using System;
using Übung_4;

class Simulator
{
    static public void Start(string data, int transmitter, int receiver, Network list)
    {
        Token t1 = new Token(data, transmitter, receiver);

        Console.WriteLine("\nStarte Simulation...");
        Console.WriteLine($"Gerät {t1.Transmitter} sendet Datenpaket (\"{t1.Data}\", {t1.Transmitter}, {t1.Receiver})");

        list.Find(t1.Transmitter).upload ++;

        Network.Device nodeAdress = list.Find(t1.Transmitter);

        while (nodeAdress.Next.adress != t1.Receiver && nodeAdress.Next.adress != t1.Transmitter)
        {
            Console.WriteLine($"Gerät {nodeAdress.Next.adress} leitet Datenpaket (\"{t1.Data}\", {t1.Transmitter}, {t1.Receiver}) weiter");
            nodeAdress = nodeAdress.Next;
        }

        if (list.Find(receiver) == null)
        {
            Console.WriteLine($"Gerät {t1.Transmitter} vernichtet Datenpaket (\"{t1.Data}\", {t1.Transmitter}, {t1.Receiver})");
        }
        else
        {
            Console.WriteLine($"Gerät {t1.Receiver} empfängt Datenpaket (\"{t1.Data}\", {t1.Transmitter}, {t1.Receiver})");
            list.Find(t1.Receiver).download ++;
        }

        Console.WriteLine("\nSimulation beendet. Bitte eine Taste drücken...");
        Console.ReadLine();
    }
}
/*• welches Gerät sendet, …
• welches Gerät das Datenpaket weiterleitet und…
• welches Gerät das Datenpaket (erfolgreich) empfängt oder…
• wenn ein Datenpaket nicht zugestellt werden konnte.*/