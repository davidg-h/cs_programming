using System;
using System.IO;

namespace DateiLesen
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int countmax = 0;
            int countmax2 = 0;
            int countTiefe = 0;
            int maxCountTiefe = 0;
            bool structure = true;

            string path = @"C:\Users\David\Desktop\Schule\Prog1 Projekte\Übungen\DateiLesen\Program.cs";
            FileStream s = new FileStream(path, FileMode.Open);

            StreamReader r = new StreamReader(s);

            string line = r.ReadLine();
            while (line != null)
            {
                foreach (char c in line)
                {
                    if (c == '{')
                    {
                        count++;
                        countmax++;
                        countTiefe++;
                        if (countTiefe > maxCountTiefe)
                        {
                            maxCountTiefe = countTiefe;
                        }
                    }
                    else if (c == '}')
                    {
                        count--;
                        countmax2++;
                        countTiefe--;
                        if (count < 0)
                        {
                            structure = false;
                        }
                    }
                }
                line = r.ReadLine();
            }
            Console.WriteLine($"Der Code ist richtig strukturiert: {structure} Count muss 0 sein: {count}");
            Console.WriteLine($"\nCount für offene Klammmern {countmax}");
            Console.WriteLine($"\nCount für geschlossene Klammmern {countmax2}");
            Console.WriteLine($"\nDie tiefste Verschachtelung ist {maxCountTiefe}");

            r.Close();
        }
    }
}
