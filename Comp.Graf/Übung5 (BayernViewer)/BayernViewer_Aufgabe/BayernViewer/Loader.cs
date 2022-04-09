using Microsoft.Win32; // OpenFileDialog
using System;
using System.Collections.Generic;
using System.Diagnostics; // Debug
using System.Globalization;
using System.IO;

namespace BayernViewer
{
    struct DgmHeixel
    {
        public int eastM;
        public int northM;
        public double heightM;
        public DgmHeixel(int eastM, int northM, double heightM) =>
            (this.eastM, this.northM, this.heightM) = (eastM, northM, heightM);
    };

    class Loader
    {
        static OpenFileDialog ofd = null;

        public static string GetFilePath(string filename, string defaultExt, string filter)
        {
            // Instantiate the dialog box
            if (ofd == null) ofd = new OpenFileDialog();

            // Configure open file dialog box
            ofd.InitialDirectory = Path.GetFullPath(@"..\..\..\");
            ofd.FileName = filename; // Default file name
            ofd.DefaultExt = defaultExt; // Default file extension
            ofd.Filter = filter; // Filter files by extension

            // Open the dialog box modally
            Nullable<bool> result = ofd.ShowDialog();

            // Process open file dialog box results
            return result == true ? ofd.FileName : null;
        }

        public static List<DgmHeixel> ReadDgmFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<DgmHeixel> coords = new List<DgmHeixel>(lines.Length);

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                try
                {
                    int eastM = Int32.Parse(words[0]);
                    int northM = Int32.Parse(words[1]);
                    double heightM = Double.Parse(words[2], culture);
                    coords.Add(new DgmHeixel(eastM, northM, heightM));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{words}'.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Unable to parse '{words}'.");
                }
            }

            return coords;
        }
    }
}
