
## Praktikum Web-Programmierung
# Aufgabe 4 - PHP

In dieser Aufgabe gehen Sie erste Schritte mit PHP und implementieren danach Grundzüge eines
Online-Shopsystems. Es sind dieses mal also zwei Aufgaben zu erfüllen.

### Teilaufgabe 1: Ein einfacher Rechner

  * Gegeben ist die Datei ***calculator.php***. In dieser Datei sollen Sie einen
    einfachen Rechner implementieren, der die vier Grundrechenarten +, -,
    \* und / unterstützt. Die Operanden werden über input-Elemente in einer GET-Anfrage
    an Ihr Programm übergeben. Sie müssen also die entsprechenden Parameter aus der
    Anfrage herauslesen und die daraus resultierende Operation mit ihren Operanden durchführen.
  * Das vorgegebene HTML-Grundgerüst **darf nicht verändert**, aber um entsprechenden PHP-Code
    ergänzt werden. Damit ergibt sich der größte Teil der Anforderungen aus dem bereitgestellten
    Code von selbst.
  * Das Ergebnis der Berechnung soll in einem H2-Element in schwarzer Schrift unterhalb
    des Formulares in der Form *"Ergebnis: 2 + 2 = 4"* angezeigt werden (Beispiel für die
    Eingaben 2,2, und +).
  * Achten Sie darauf, dass fehlerhafte Eingaben abgefangen werden. Ein Fehler in der
    Eingabe soll in einem H2-Element in roter Schrift unterhalb des Formulares angezeigt
    werden.
  * Um das gewünschte Verhalten ausprobieren zu können, finden Sie eine Beispielimplementierung
    unter ***http://webprog.informatik.fh-nuernberg.de/praktikum/a4/calculator.php*** (nur aus dem IN- oder
    Hochschul-VPN erreichbar).

### Teilaufgabe 2: ToyModels Online-Shop

  * Gegeben sind mehrere Dateien, die die Grundlage für einen Online-Shop darstellen könnten und die
    Sie mit dieser Aufgabe "zum Leben erwecken" sollen. Es gibt wie immer eine Beispielimplementierung,
    die bei Unklarheiten als Referenzimplementierung dient. Sie finden diese unter
    ***http://webprog.informatik.fh-nuernberg.de/praktikum/a4/toymodels.php*** (nur aus dem IN- oder
    Hochschul-VPN erreichbar).
  * Die Daten für den Online-Shop (Artikel, Preise, usw.) kommen dabei aus der Toymodels-Datenbank,
    Sie auch in der Lehrveranstaltung Datenbanken verwenden. Das Schema der Datenbank kennen Sie aus
    der Lehrveranstaltung (DB, nicht WebProg :-). Der Zugriff auf die Datenbank erfolgt
    dabei über PHP Data Objects (PDO), welche eine Abstraktionsschicht für den Zugriff auf verschiedenste
    Datenbanken darstellt (lesen Sie dazu auch die Dokumentation zu PHP PDO auf http://php.net/). Die
    Standardinstallation von PHP kommt dabei mit PDO Treibern für mysql- oder Sqlite-Datenbanken. Sie
    können zur Implementierung der Aufgabe also beide Varianten verwenden.
  * Die vorgebenenen und für die Implementierung relevanten Dateien sind:
      * ***toymodels.php***: Die Einstiegsseite - diese Zeigt die Produktliste der ToyModels GmbH
      und enthält eine Möglichkeit, Produkte in den Warenkorb zu legen.
      * ***cart.php***: Der Warenkorb zeigt die Produkte an, die sich im Warenkorb befinden. Ein
      Klick auf "Bestellung absenden!" schliesst den Bestellvorgang ab.
      * ***config.php***: In dieser Datei wird die Konfiguration für den Datenbankzugang hinterlegt.
        Bitte denken Sie daran, den Inhalt vor der Abgabe zu löschen, insbesondere wenn Sie die
        mysql-Datenbank verwenden (wg. Nutzername & Passwort).
      * ***shopengine.php***: Der großteil der Anwendung passiert hier - die Klasse *ShopEngine*
      fungiert sozusagen als "Treiber" für den Online-Shop.
      * ***toymodels.db***: Die Toymodels Datenbank als Sqlite3 Version, falls Sie die mysql-Datenbank
      aus der Lehrveranstaltung Datenbanken für diese Aufgabe nicht nutzen wollen.
  * Ausserdem gibt es noch Dateien in den Unterverzeichnissen *css*, *img* und *webfonts*. Diese
    brauchen Sie für die Aufgabe nicht weiter zu beachten, da sie lediglich für das Aussehen der
    Webseite zuständig sind.
  * In den Dateien ***toymodels.php*** und ***cart.php*** müssen Sie jeweils nur kleinere Ergänzungen
    vornehmen. Diese Sind mit Kommentar gekennzeichnet.
  * Der Haupteil der Implementierung findet in der Datei ***shopengine.php*** statt, die eine
    Klassenschablone für die Funkionalität des Shops enthält. Auch hier geben Kommentare grob an,
    welche Funktionalität jeweils erwartet wird.
  * Die einzelnen Anforderungen an die Webseite sind:
    * Auf der Hauptseite wird die Tabelle der Waren gemäß der Vorgabe und der Beispielimplementierung
      aus der Toymodels-Datenbank (LV Datenbanken) erzeugt und dargestellt.
    * Ein klick auf den Button "In den Warenkorb" legt das entsprechende Item in den Warenkorb.
      Dabei wird der Zähler im Warenkorb-Link entsprechend erhöht (siehe Beispielimplementierung).
      Hinweis: es ist nicht nötig, das einzelne Produkte (einer Artikelnummer) mehrmals in den Warenkorb 
      gelegt werden können. Sie dürfen das natürlich implementieren, eine Anforderung ist es jedoch nicht.
    * Die Warenkorbseite zeigt dann die Elemente im Warenkorb, sofern welche vorhanden sind, sowie
      den Gesamtpreis der Waren im Warenkorb an (siehe Beispielimplementierung).
    * Die Elemente im Warenkorb sollen dort für 30 Sekunden erhalten bleiben. Danach soll die
      Sitzung gelöscht werden (Tipp: zu Testzwecken können Sie die Dauer auf 60 Sekunden erhöhen).


## Hinweise zur Bearbeitung der Aufgabe

  * **Verändern Sie die vorgegebenen Dateien, insbesondere den vorgegeben Code nicht!** Ergänzen
    Sie diese nur an den dafür vorgesehenen Stellen und füllen Sie die markierten Lücken!
  * Zur Umsetzung der Warenkorbfunktionalität benötigen Sie eine Session.
  * Überlegen Sie sich, wie Sie die Buttons "In den Warenkorb" erzeugen könnten und wie diese
    die gewünschte Funktionalität erhalten (Tipp: wenn Sie nicht weiter kommen, sehen
    Sie sich an, was die Beispielimplementierung macht, oder fragen Sie mich).
  * Wenn Sie die Sqlite3 Datenbank verwenden, benötig der PDO DSN den vollständigen Pfad
    zur Datei. Ein Nutzername und/oder ein Passwort ist nicht notwendig.
  * Für die Fortgeschrittenen: das ist eine PHP Aufgabe - Javascript ist nicht erlaubt, auch
    nicht, wenn es mit PHP erzeugt wird :-)

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * **Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.**
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.
  * Denken Sie daran, den Inhalt der Variablen in der config.php zu leeren, wenn Sie dort
    einen Nutzernamen und ein Passwort hinterlegt haben.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch mit
    der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die
    Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal
    können 0 Pukte erreicht werden.

## Quellenangaben

  * Fontawesome: https://fontawesome.com/

