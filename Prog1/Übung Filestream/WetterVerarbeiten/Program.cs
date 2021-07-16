using System;
using System.IO;

namespace WetterVerarbeiten
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] durchschnitte = Monatswerte("München", 2010);
            double[] durchschnitte2 = Monatswerte("Nürnberg", 2010);
            double[] durchschnitte3 = Monatswerte("Würzburg", 2010);
            for (int i = 0; i < durchschnitte.Length; i++)
            {
                Console.WriteLine($"Monat {i + 1}: {durchschnitte[i]:f2} °C");
                Console.WriteLine($"Monat {i + 1}: {durchschnitte2[i]:f2} °C");
                Console.WriteLine($"Monat {i + 1}: {durchschnitte3[i]:f2} °C");
            }

        }

        public static double[] Monatswerte(string stadt, int jahr)
        {
            string path = @"C:\Users\David\Desktop\Schule\Prog1 Projekte\Übungen\DateiLesen\WetterVerarbeiten\wetter.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader r = new StreamReader(stream);
            string line = r.ReadLine();

            double[] middle = new double[12];
            double[] counter = new double[12];

            while (line != null)
            {
                string[] neuLine = line.Split("\t");
                string[] date = neuLine[1].Split("-");
                if (neuLine[0] == stadt && date[0] == jahr.ToString())
                {
                    middle[Convert.ToInt32(date[1]) - 1] += Convert.ToDouble(neuLine[3]);
                    counter[Convert.ToInt32(date[1]) - 1]++;
                }
                line = r.ReadLine();
            }

            for (int i = 0; i < middle.Length; i++)
            {
                middle[i] = middle[i] / counter[i];
            }

            r.Close();
            return middle;
        }
    }
}
