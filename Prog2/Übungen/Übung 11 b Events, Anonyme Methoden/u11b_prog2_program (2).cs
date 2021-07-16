using System;
using System.IO;	// Required for the FileSystemWatcher class

namespace Exercise
{
    class Program
    {
        private static void MyRenameEvent(object sender, RenamedEventArgs args) // Event handler based on .NET delegate "RenameEventHandler" (See .NET documentation for more)
        {
            Console.WriteLine(args.OldName + " was renamed to " + args.Name);
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) => Console.WriteLine($"Deleted: {e.FullPath}");

        static void Main(string[] args)
        {
            /*FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = Directory.GetCurrentDirectory(); // Directory for the watcher

            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;    // Type of notfications (See NotifyFilters in .NET documentation for more)

            watcher.Filter = "";    // Filter for the watcher (Empty string = Watch all)

            watcher.Renamed += MyRenameEvent;   // Register own event handlers

            // Aufgabe ii) 
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;

            watcher.EnableRaisingEvents = true; // Start watching

            Console.WriteLine("Starting watcher in directory \"" + watcher.Path + "\"");

            Console.WriteLine("Please press a key to quit...");

            Console.ReadKey(true);*/

            // 11 b.b)

            Calculate(0, 5, 1);
        }

        delegate void MyCalculation();

        public static void Calculate(double start, double end, double steps)
        {
            MyCalculation cal = () =>
               {
                   Console.WriteLine("(x, (f(x))-Paar; f(x) = x:");
                   double result = 0;
                   for (double i = start; i <= end; i += steps)
                   {
                       result = i;
                       Console.WriteLine($"({i},{result})");
                   }
               };

            cal();

            MyCalculation cal2 = () =>
            {
                Console.WriteLine("(x, (f(x))-Paar; f(x) = 0.5 * x² + 1:");
                double result = 0;
                for (double i = start; i <= end; i += steps)
                {
                    result = 0.5 * Math.Pow(i, 2) + 1;
                    Console.WriteLine($"({i},{result})");
                }
            };

            cal2();

            MyCalculation ca3 = () =>
            {
                Console.WriteLine("(x, (f(x))-Paar; f(x) = sin(x):");
                double result = 0;
                for (double i = start; i <= end; i += steps)
                {
                    result = Math.Sin(i);
                    Console.WriteLine($"({i},{result})");
                }
            };

            ca3();
        }
    }
}
