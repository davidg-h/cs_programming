
## Praktikum Web-Programmierung
# Aufgabe 5 - JavaScript / DOM

In der fünften Aufgabe beschäftigen Sie sich mit JavaScript und den grundlegenden Möglichkeiten,
Webseiten mit Scriptcode zu verändern und weitergehende Interaktion für den Nutzer zur Verfügung
zu stellen.

Vorgegeben sind die Dateien *index.html* und *css/style.min.css*, die Sie im Rahmen der Aufgabe
**nicht verändern dürfen**! Zu diesen Dateien sollen Sie zwei Skripte erstellen, die die
Funktionalität der Seite implementieren. Weiterhin dürfen Sie zur Bearbeitung der Aufgabe
keine externen JavaScript Bibliotheken oder Frameworks verwenden!

### ***word.js***

Sie knneen siheccrlih alle das Pnmeohän, dass man eenin Txet auch dnan ncoh rceht gut
lseen und veertsehn knan, wnen nhcit mehr alle Bbcseuathn eenis Worets in der rctehiign
Rlifohgenee sehten. Wctihig ist dbaei nur, dsas der esrte und der lzete Bchsbaute eiens
Wrotes smimten. Dies ist der erste Teil der JricaapvSt Aubfage.

(Sie kennen sicherlich alle das Phänomen, dass man einen Text auch dann noch recht gut lesen
und verstehen kann, wenn nicht mehr alle Buchstaben eines Wortes in der richtigen Reihenfolge
stehen. Wichtig ist dabei nur, dass der erste und der letze Buchstabe eines Wortes stimmen. Dies
ist der erste Teil der JavaScript Aufgabe.)

  * Erstellen Sie die Datei **word.js**. Diese soll als JavaScript Modul eine Klasse *Word*
    exportieren.
  * Instanzen der Klasse *Word* erhalten als Argument im Konstrukor eine Zeichenkette (ein Wort).
    Dabei sollen Sonder- und/oder Satzzeichen am Anfang oder am Ende des Wortes erlaubt sein (z.B.
    "Hallo,", "Ende!", etc.).
  * Die Klasse *Word* soll eine Methode *randomize* erhalten, die keine Parameter bekommt und als
    Rückgabewert eine zufällige Permutation des ursprünglichen Wortes zurückliefert.
  * Dabei sollen folgende Regeln gelten:
    * Der erste und der letzte Buchstabe des ursprünglichen Wortes sollen erhalten bleiben (z.B.
      "Hallo" -> "Hlalo", "Wichtig" -> "Wctihig").
    * Sonder- und Satzzeichen am Anfang und/oder Ende des Wortes müssen erhalten bleiben (z.B.
      "Hallo!" -> "Hlalo!", ",wichtig:" -> ",wctihig:")
  * Verwenden Sie zur Implementierung die seit ES6 (ECMAScript 6) verfübare Klassensyntax der Sprache (*class*).

### ***script.js***

  * Erstellen Sie die Datei **script.js**. Diese soll *kein* JavaScript Modul sein und die restliche Logik
    für die Seite implementieren.
  * Es soll zunächst folgendes Verhalten der Webseite implementiert werden:
    * Wenn der Nutzer mit der Maus über einen Artikel (\<article\>) der Seite fährt, soll der gesamte
      Text, inklusive der Überschrift, **unter Beibehaltung des HTML Markups** unter Verwendung der
      Klasse *Word* aus dem ersten Teil der Aufgabe permutiert werden.
    * Die Permutation soll nur **einmal** pro "überfahren" mit der Maus durchgeführt werden, solange
      sich der Mauszeiger innerhalb der Box befindet.
    * Verlässt der Mauszeiger die Box, soll der Originaltext wiederhergestellt werden.
    * Dies soll für alle Artikel, existierende und *zukünftige(!)* der Webseite passieren.
  * Um die ohnehin schon äußerst interessante Webseite noch wertvoller zu machen, sollen Sie diese nun
    noch um die Möglichkeit erweitern, neue Artikel einzustellen.
     * Dazu soll innerhalb der \<aside\>-Box ein Formular erstellt werden, mit Hilfe dessen man einen
       neuen Artikel mit Titel und zugehörigem Text anlegen kann.
     * Das zu erzeugende Formular soll ein Eingabefeld für den Titel des neuen Artikels sowie eine
       Textarea für die Eingabe des Artikelinhaltes erhalten. Zusätzlich sollen zwei Buttons mit
       dem Text "Absenden" und "Seite zurücksetzen" erstellt werden.
     * Klickt der Benutzer auf "Absenden", soll ein neuer Artikel erzeugt werden und der Formularinhalt
       gelöscht werden. Die neu erzeugten Artikel sollen sich beim "Überfahren" mit der Maus genauso
       verhalten, wie die bereits existierenden (Teil 1).
     * Ein Klick auf "Seite zurücksetzen" soll die Webseite in ihren Ursprungszustand zurückversetzen.
  * Die Webseite *index.html*, die Sie nicht verändern dürfen, ruft nach dem Laden die JavaScript Funktion
    *initAssignment()* auf. Diese Funktion müssen Sie mindestens in **script.js** implementieren, um die
    notwendigen Eventhandler aufzusetzen und Ihr Programm "zum Laufen" zu bringen.

Wie immer gibt es eine Demo-Webseite zur Aufgabe. Diese finden Sie unter
  **http://webprog.informatik.fh-nuernberg.de/praktikum/a5/**.

## Hinweise zur Bearbeitung der Aufgabe

  * **Verändern Sie die vorgegebenen Dateien nicht!**
  * **Die Verwendung externer JavaScript Bibliotheken und/oder Frameworks ist nicht erlaubt!**
  * Sie dürfen die Datei *index.html* zwar nicht verändern, Sie sich anzusehen ist allerdings sehr
    hilfreich zur Lösung der Aufgabe.
  * Diese Aufgabe thematisiert u.a. die Möglichkeiten, durch JavaScript mit dem DOM-Baum der Webseite
    zu interagieren. Machen Sie sich mit dem Aufbau des Baumes vertraut, bevor Sie Anfangen zu programmieren.
  * Wie immer gilt: nutzen Sie auch die Fragestunden - dies geht aber nicht ohne Vorbereitung!
  * **Da die Aufgabe JavaScript Module verwendet, müssen Sie Ihren Code mit einem Webserver testen**, da Module
    nicht über das file://-Schema eingebunden werden dürfen.

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * **Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.**
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch mit
    der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die
    Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal
    können 0 Pukte erreicht werden.

## Quellenangaben

  * Siehe index.html

