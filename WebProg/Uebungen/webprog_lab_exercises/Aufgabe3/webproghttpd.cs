
using System;

/* Diese Namensräume benötigen Sie vermutlich zusätzlich... */
using System.Net;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
// Lösung: https://git.informatik.fh-nuernberg.de/lehre/webprog/webaw_exercises/-/blob/sose2022/webproghttpd/webproghttpd_loesung_a3.cs
namespace webproghttpd
{
    class WebProgHttpd
    {
        const string VERSION = "0.2";
        static Dictionary<string, int> visitorMap = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Console.WriteLine("*** webproghttpd v{0} - ein einfacher Webserver!", WebProgHttpd.VERSION);
            Console.WriteLine("");
            Console.WriteLine("Teil des Praktikums Web-Programmierung im Sommersemester 2020");
            Console.WriteLine("an der Technischen Hochschule Nürnberg Georg Simon Ohm.");
            Console.WriteLine("");

            /* 1. Prüfen Sie auf das Vorhandensein von Optionen */
            /*
             * -h soll einen kurzen Hilfetext zu den verfügbaren Optionen ausgeben
             * und dann das Programm beenden.
             *
             * -p N nimmt einen Integer N an und setzt den Port, auf dem der Webserver
             * auf eingehende Verbindungen wartet auf diesen Wert (z.B. -P 8080).
             * Ist diese Option nicht vorhanden, soll der Default-Port 80 sein.
             *
             */
            int portNumber = 8081;
            foreach (string s in args)
            {
                string envVariable = s.ToLower();
                if (envVariable.Contains("-p") && Int32.Parse(envVariable.Substring(2)) > 0)
                {
                    portNumber = Int32.Parse(envVariable.Substring(2));
                }
                else
                {
                    System.Console.WriteLine("Portnumber invalid!! Please enter a Portnumber greater than 0\n");
                    Environment.Exit(0);
                }

                if (envVariable == "-h")
                {
                    System.Console.WriteLine("After the .exe add your -pN or \"-p N\" ");
                    System.Console.WriteLine("N = your Portnumber\n\nExample: webproghttpd.exe -p8082\n");
                    Environment.Exit(0);
                }
            }

            /* 2. Starten Sie den Server und warten auf eingehende Verbindungen. */

            /* 3. Bearbeiten Sie die Verbindungsanfragen entsprechend der Vorgaben. */

            /* 4. Zurück zu 2., es sei denn die Anfrage war "/exit". */
            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add($"http://localhost:{portNumber}/");
            listener.Start();

            Console.WriteLine("Listening...");

            int nRequest = 0;
            bool run = true;
            string slot = "";
            while (run)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;

                nRequest++;
                string urlStr = request.Url.PathAndQuery;
                string ipAddress = request.RemoteEndPoint.Address.MapToIPv4().ToString();
                Console.WriteLine(urlStr + "\n");

                switch (urlStr)
                {
                    case "/favicon.ico":
                    case "/":
                        if (visitorMap.ContainsKey(ipAddress))
                        {
                            visitorMap[ipAddress]++;
                        }else
                        {
                            visitorMap[ipAddress] = 1;
                        }
                        slot = $"<!doctype html><HTML><title>Hello World C#</title><BODY> <h1>Willkommen</h1> <p>{DateTime.Now}</p> <p>Dies ist {visitorMap[ipAddress] - 1}.Besuch...</p> </BODY></HTML>";
                        break;

                    case "/quit":
                         run = false;
                        break;

                    case "/calc":
                        Process.Start("calc.exe");
                        break;

                    case "/ip":
                        slot = $"<!doctype html><HTML><title>Hello World C#</title><BODY> <h1>Willkommen</h1> <p>{DateTime.Now}</p> <p>IP:= {ipAddress}</p> </BODY></HTML>";
                        break;

                    case "/error":
                        response.StatusCode = 404;
                        response.StatusDescription = "Not found";
                        response.Close();
                        break;

                     case "/exit":
                        response.StatusCode = 200;
                        response.StatusDescription = "ok terminate application";
                        response.Close();
                        break;

                    default:
                        response.StatusCode = 500;
                        response.StatusDescription = "default terminate application";
                        response.Close();
                        break;
                }
                
                // Construct a response.
                string responseString = slot;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
                System.Console.WriteLine($"{nRequest} Request ...\n");
                System.Console.WriteLine(Dns.GetHostName());
            }
            listener.Stop();
        }
    }
}
