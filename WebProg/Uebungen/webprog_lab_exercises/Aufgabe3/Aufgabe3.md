
## Praktikum Web-Programmierung
# Aufgabe 3 - Ein einfacher Webserver

In dieser Aufgabe dreht sich alles um Webserver. Implementieren Sie einen einfachen HTTP-Server mit C#
und .NET (5.0 oder Core 3.1) in der Datei *webproghttpd.cs*!

Ihr Server soll dabei die folgenden Anforderungen erfüllen:

  * Der Server soll ein Kommandozeilenprogram sein und mit .NET erstellbar und ausführbar sein
    (dotnet build/run).
  * Die Implementierung soll ausschliesslich APIs der .NET API nutzen (keine anderen MS APIs,
    keine  Drittkomponenten).
  * Die folgenden Kommandozeilenoptionen sollen unterstützt werden:
    * -h -> Zeigt eine kurze Hilfestellung zu den Kommandozeilenoptionen an und beendet das Programm.
    * -p N -> Setzt den Port, auf dem der Webserver hört auf den Integer N (> 0!). Der Default-Port
      soll 80 sein.
    * Bei allen anderen oder zu vielen Argumenten, oder wenn das an -p übergebene Argument falsch ist
      (<0, >65535, kein Integerwert, ...), soll die Hilfe ausgegeben und das Programm beendet werden.
  * Der Server soll folgende HTTP-Anfragen beantworten können:
    * Eine Anfrage an die URL "/" (root) soll mit einer Webseite antworten, die den folgenden Inhalt hat:
      * Der Titel der Seite soll "Hello World" sein.
      * Der Inhalt der Seite soll den Besucher mit einer Überschrift (h1) begrüßen und in jeweils einem Paragraphen
        darunter das aktuelle Datum und die Uhrzeit anzeigen. Die Begrüßung des Besuchers soll nach dem ersten Aufruf
        jeweils die Anzahl der Besuche mit gleicher IP-Adresse anzeigen (z.B. "Dies ist Ihr 10. Besuch...").
      * Die Seite muss vollständig vom Webserver erzeugt werden. Die erzeugte Seite soll nur HTML beinhalten,
        kein CSS, kein Javascript.
      * Die Seite darf im W3C Validator keine Warnungen oder Fehler produzieren.
    * Eine Anfrage an die URL "/ip" soll die IP Adresse des anfragenden Clients als Plaintext zurückliefern.
    * Eine Anfrage an die URL "/error" soll den Fehler 404 zurückliefern (ohne Inhalt).
    * Eine Anfrage an die URL "/exit" soll den Status 200 zurückliefern (ohne Inhalt) und den HTTP-Server beenden.
    * In allen anderen Fällen soll ein Fehler 500 zurückgeliefert werden (ohne Inhalt).
  * Es genügt, wenn Ihr Webserver Anfragen nur sequenziell bearbeiten kann (d.h. Sie müssen kein Threading
    implementieren).
  * Sobald der Server läuft soll eine Ausgabe der Form "webproghttpd vVERSIONSNUMMER wartet auf eingehende
    Verbindungen (Port PORTNUMMER)..." die Bereitschaft, Anfragen zu verarbeiten signalisieren. Dabei sind
    VERSIONSNUMMER und PORTNUMMER durch die tatsächliche Versionsnummer und den eingestellten Port zu ersetzen.
  * Weitere Hinweise finden Sie in der Quellcodevorlage *webproghttpd.cs*. Sie sollten den existierenden Code
    nicht verändern, nur ergänzen. Sie dürfen jedoch die Versionsnummer anpassen. Sollte eine Änderung zwingend
    notwendig sein, sprechen Sie das bitte vorher mit mir ab, da sonst die Möglichkeit besteht, das kein
    automatischer Test Ihrer Abgabe möglich ist.

## Hinweise zur Bearbeitung der Aufgabe

  * Verwenden Sie ausschliesslich C# und .NET (Core 3.1 oder 5.0) für die Implementierung. Sie dürfen 
    (und sollen!) nur die grundlegenden .NET APIs nutzen (d.h. keine erweiterten APIs wie z.B. ASP.NET Core 
    und auch keine externen bzw. Bibliotheken von Dritten).
  * Falls Sie nicht wissen, wo Sie anfangen sollen, suchen Sie nach der Klasse *HttpListener* in der
    API Dokumentation.
  * Unter http://webprog.informatik.fh-nuernberg.de:8081/ finden Sie eine Beispielimplementierung
    des Servers, die Sie zum Ausprobieren verwenden können. Nur die "exit" URL verhält sich anders,
    als in der Angabe gefordert - das wäre sonst ein kurzer Test. Die URL ist nur aus dem Hochschul-
    oder Informatik-VPN erreichbar. Zugriffe werden geloggt, aber spätestens am Ende des Semesters
    wieder vollständig gelöscht. Versuchen Sie, den Server nicht kaputt zu machen ;-)
  * Behalten Sie den Quellcode Ihrer Abgabe. Möglicherweise benötigen Sie den Server im Verlauf
    des Praktikums noch einmal.

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.
  * Das Abgabeskript ignoriert die Unterverzeichnise *bin* und *obj*. Sollten Sie Ihre Buildergebnisse
    in einem anderen Verzeichnis speichern, denken Sie daran, diese Verzeichnisse zu löschen, bevor Sie
    die ZIP-Datei erstellen.
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch mit
    der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die
    Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal
    können 0 Pukte erreicht werden.

## Quellenangaben

  * .NET: https://dotnet.microsoft.com/

