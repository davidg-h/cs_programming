using System;
using System.Net;
using System.Globalization;
using System.Collections.Generic;
namespace webproghttpd {
  class WebProgHttpd {
    const string VERSION = "0.1";
    /******************************************/
    private HttpListener m_httpListener;
    private int m_port;
    private bool m_run;
    private bool m_testMode = false;
    private Dictionary<string, int> m_vistorMap;
    WebProgHttpd(int port, bool testing) {
      m_port = port;
      m_run = true;
      m_testMode = testing;
      m_vistorMap = new Dictionary<string, int>();
    }
    private int run() {
      m_httpListener = new HttpListener();
      m_httpListener.Prefixes.Add(String.Format("http://localhost:{0}/", m_port));
      m_httpListener.Start();
      while (m_run) {
        HttpListenerContext ctx = m_httpListener.GetContext();
        HttpListenerRequest req = ctx.Request;
        HttpListenerResponse res = ctx.Response;
        string urlString = req.Url.PathAndQuery;
        int queryIndex = urlString.IndexOf("?");
        if (queryIndex != -1) {
          string query = urlString.Substring(queryIndex);
          urlString = urlString.Substring(0, queryIndex);
          Console.WriteLine("Query: {0}", query);
        }
        Console.WriteLine("{1}: Verarbeite Pfad: {0}", urlString, req.RemoteEndPoint.Address.ToString());
        string page = @"<!doctype html>
        <html lang=""de"">
        <head><title>Hello World</title></head>
        <body>
        <h1>###HELLO###</h1>
        <p>Es ist der ###DATE###.</p>
        <p>Es ist ###TIME### Uhr.</p>
        </body>
        </html>";
        string responseString = null;
        byte[] buffer = null;
        switch(urlString) {
          case "/":
            responseString = page;
            DateTime now = DateTime.Now;
            page = page.Replace("###DATE###", now.ToLocalTime().ToShortDateString());
            page = page.Replace("###TIME###", now.ToLocalTime().ToShortTimeString());
            string ipaddr = req.RemoteEndPoint.Address.ToString();
            string hellostr;
            if (m_vistorMap.ContainsKey(ipaddr)) {
              m_vistorMap[ipaddr]++;
              hellostr = String.Format("Hallo Besucher, dies ist Ihr {0}. Besuch!", m_vistorMap[ipaddr]);
            } else {
              hellostr = "Hallo Besucher!";
              m_vistorMap.Add(ipaddr, 1);
            }
            page = page.Replace("###HELLO###", hellostr);
            buffer = System.Text.Encoding.UTF8.GetBytes(page);
            res.ContentLength64 = buffer.Length;
            res.ContentType = "text/html";
            res.OutputStream.Write(buffer, 0, buffer.Length);
            res.OutputStream.Close();
            res.Close();
            break;
          case "/ip":
            responseString = req.RemoteEndPoint.Address.ToString();
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            res.ContentLength64 = buffer.Length;
            res.ContentType = "text/plain";
            res.OutputStream.Write(buffer, 0, buffer.Length);
            res.OutputStream.Close();
            res.Close();
            break;
          case "/error":
            res.StatusCode = 404;
            res.StatusDescription = "Not Found";
            res.ContentLength64 = 0;
            res.Close();
            break;
          case "/exit":
            res.StatusCode = 200;
            res.StatusDescription = "OK";
            if (!m_testMode) {
              res.ContentLength64 = 0;
              m_run = false;
            } else {
              responseString = "Waere dies keine Testumgebung, wuerde sich der Serverprozess jetzt beenden...";
              buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
              res.ContentLength64 = buffer.Length;
              res.ContentType = "text/plain";
              res.OutputStream.Write(buffer, 0, buffer.Length);
              res.OutputStream.Close();
            }
            res.Close();
            break;
          default:
            res.StatusCode = 500;
            res.StatusDescription = "Internal Server Error";
            res.ContentLength64 = 0;
            res.Close();
            break;
        }
      }
      m_httpListener.Stop();
      m_httpListener.Close();
      return 0;
    }
    static void help() {
      Console.WriteLine("Gültige Optionen sind:");
      Console.WriteLine("-h      -> zeigt diese Hilfe an");
      Console.WriteLine("-p N    -> Setzt den Port für den Webserver auf den Integer N > 0 (Default: 80)");
      Console.WriteLine("");
      Environment.Exit(-1);
    }
    /******************************************/
    static void Main(string[] args) {
      Console.WriteLine("*** webproghttpd v{0} - ein einfacher Webserver!", WebProgHttpd.VERSION);
      Console.WriteLine("");
      Console.WriteLine("Teil des Praktikums Web-Programmierung im Sommersemester 2020");
      Console.WriteLine("an der Technischen Hochschule Nürnberg Georg Simon Ohm.");
      Console.WriteLine("");
      /* Prüfen Sie auf das Vorhandensein von Optionen */
      /*
       * -h soll einen kurzen Hilfetext zu den verfügbaren Optionen ausgeben
       * und dann das Programm beenden.
       *
       * -p N nimmt einen Integer N an und setzt den Port, auf dem der Webserver
       * auf eingehende Verbindungen wartet auf diesen Wert (z.B. -P 8080).
       * Ist diese Option nicht vorhanden, soll der Default-Port 80 sein.
       *
       */
      /**** Hier sollte / kann Ihre Implementierung hin ****/
      int port = 80;
      bool testing = false;
      if (args.Length > 0) {
        if (args[0].CompareTo("-s") == 0) {
          port = 8081;
          testing = true;
        } else if (args[0].CompareTo("-p") == 0 && args.Length == 2) {
          port = Int32.Parse(args[1], NumberStyles.Integer);
          if (port <= 0)
            WebProgHttpd.help();
        } else {
          WebProgHttpd.help();
        }
      }
      WebProgHttpd webProgHttpd = new WebProgHttpd(port, testing);
      Console.WriteLine("webproghttpd v{0} wartet auf eingehende Verbindungen (Port {1})...", WebProgHttpd.VERSION, webProgHttpd.m_port);
      webProgHttpd.run();
      Console.WriteLine("Auf wiedersehen!");
    }
  }
}