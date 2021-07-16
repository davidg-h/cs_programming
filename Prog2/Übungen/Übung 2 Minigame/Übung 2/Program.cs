using System;

namespace Übung_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geben Sie bitte die Studentenazhal ein: ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string[,] daten = new string[(int)a, 2];
            for (int i = 0; i < daten.GetLength(0); i++)
            {
                for (int j = 0; j < daten.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        bool b = false;
                        do
                        {
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            try
                            {
                                Convert.ToInt32(name);
                                Console.WriteLine("Ein Name darf nur Buchstaben enthalten");
                            }
                            catch (Exception)
                            {
                                daten[i, j] = name;
                                b = true;
                            }
                        } while (!b);
                    }
                    else
                    {
                        bool b = false;
                        do
                        {
                            Console.Write($"Note: ");
                            string note = Console.ReadLine();

                            try
                            {
                                if (Convert.ToDouble(note) < 1 || Convert.ToDouble(note) > 4)
                                    Console.WriteLine("Du darfst nur Noten im Berecih von 1.0 bis 4.0 eingeben");
                                else
                                {
                                    daten[i, j] = note;
                                    b = true;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Du darfst nur Noten im Berecih von 1.0 bis 4.0 eingeben");
                            }
                        } while (!b);
                        Console.WriteLine("-------------");
                    }

                }
            }

            double summe = 0.0;
            double min = Convert.ToDouble(daten[0, 1]);
            double max = Convert.ToDouble(daten[0, 1]);

            for (int i = 0; i < daten.GetLength(0); i++)
            {
                summe += Convert.ToDouble(daten[i, 1]);
                if (Convert.ToDouble(daten[i, 1]) < min)
                {
                    min = Convert.ToDouble(daten[i, 1]);
                }
                if (Convert.ToDouble(daten[i, 1]) > max)
                {
                    max = Convert.ToDouble(daten[i, 1]);
                }
            }

            Console.WriteLine($"Der Durchscnitt ist: {summe / a:f2} \nDie beste Note ist: {min:f1}\nDie schlechteste Note ist: {max:f1}");

            Console.WriteLine();
            Console.Write("Bitte geben Sie einen gewünschten NC ein: ");
            double nc = Convert.ToDouble(Console.ReadLine());

            int zugelassen = 0;
            for (int i = 0; i < daten.GetLength(0); i++)
            {
                if (Convert.ToDouble(daten[i, 1]) <= nc)
                {
                    zugelassen++;
                }
            }
            Console.WriteLine($"Es sind {((zugelassen / a) * 100):f2}% Zugelassen");


            //Aufgabe b)
            Console.Write("Geben Sie Mindestprozentzahl der Zugelassnen Studenten an: ");
            double bestehquote = Convert.ToDouble(Console.ReadLine());
            double ncMindest = 1.0;
            for (double i = ncMindest; i < 4.1; i += 0.1)
            {
                zugelassen = 0;
                for (int j = 0; j < daten.GetLength(0); j++)
                {
                    if (Convert.ToDouble(daten[j, 1]) <= i)
                    {
                        zugelassen++;
                    }
                }
                if (((zugelassen / a) * 100) >= bestehquote)
                {
                    ncMindest = i;
                    i = 5.0;
                }
            }
            Console.WriteLine($"Der NC müsste bei einer Bestehquote von {bestehquote}% bei {ncMindest:f2} liegen");
            Console.WriteLine();

            //Aufgabe c)
            Console.Clear();
            Console.WriteLine("Hier kommt das Minigame, deine Spielfigur ist ein X \n Wenn du nicht mehr spielen möchtest drücke ä");
            Console.WriteLine("Steuere mittels W A S D");
            char[,] area = new char[10, 20];
            for (int i = 0; i < area.GetLength(0); i++)
            {

                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (i == 0 || i == area.GetLength(0) - 1)
                    {
                        area[i, j] = '-';
                    }
                    else if (j == 0 || j == area.GetLength(1) - 1)
                    {
                        area[i, j] = '|';
                    }
                    else
                    {
                        area[i, j] = ' ';
                    }
                }
            }
            area[2, 4] = 'X';
            MatrixPrint(area);

            while (CheckKey(area))
            {
                Console.Clear();
                Console.WriteLine("Hier kommt das Minigame, deine Spielfigur ist ein X \nWenn du nicht mehr spielen möchtest drücke ä");
                Console.WriteLine("Steuere mittels W A S D");
                MatrixPrint(area);
            }
        }

        static bool CheckKey(char[,] area)
        {
            char input = Console.ReadKey().KeyChar;

            if (input == 'ä')
                return false;
            else
            {
                int zeile = 0;
                int spalte = 0;

                for (int i = 0; i < area.GetLength(0); i++)
                {
                    for (int j = 0; j < area.GetLength(1); j++)
                    {
                        if (area[i, j] == 'X')
                        {
                            zeile = i;
                            spalte = j;
                            area[i, j] = ' ';
                        }
                    }
                }

                if (input == 'w')
                {
                    if (zeile == 1)
                        area[zeile, spalte] = 'X';
                    else
                        area[--zeile, spalte] = 'X';
                }
                else if (input == 'a')
                {
                    if (spalte == 1)
                        area[zeile, spalte] = 'X';
                    else
                        area[zeile, --spalte] = 'X';
                }
                else if (input == 's')
                {
                    if (zeile == area.GetLength(0) - 2)
                        area[zeile, spalte] = 'X';
                    else
                        area[++zeile, spalte] = 'X';
                }
                else if (input == 'd')
                {
                    if (spalte == area.GetLength(1) - 2)
                        area[zeile, spalte] = 'X';
                    else
                        area[zeile, ++spalte] = 'X';
                }
                return true;
            }
        }

        static void MatrixPrint(char[,] area)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    Console.Write(area[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}