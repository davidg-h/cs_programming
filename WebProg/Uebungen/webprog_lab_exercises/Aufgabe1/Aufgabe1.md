## Praktikum Web-Programmierung
# Aufgabe 1 - HTML

Die Toy Models GmbH vertreibt in verschiedenen Ländern original- und maßstabsgetreue Nachbildungen
historischer Automobile, Eisenbahnen, Schiffe und Flugzeuge. Das Unternehmen betreibt Filialen
in mehreren Städten weltweit. Die Kunden der Firma sind lokale Einzelhändler, die die entsprechenden
Modelle weitervertreiben. Sie werden damit beauftragt, ein Online-Shop-System auf Basis eines bereits
existierenden Informationssystems zu entwickeln, um die Bestellvorgänge und Zahlungen effektiver
abwickeln zu können.

In der ersten Aufgabe soll ein HTML5 Grundgerüst für ein Online-Shopsystem erstellt werden.
Dazu sind HTML5 Seiten zu entwickeln, die sich an den Anforderungen der Auftraggeberin, der ToyModels
GmbH orientieren.

**index.html**: Implementieren Sie in der Datei *index.html*:

  * Einen Kopfbereich, der das Firmenlogo (img/toymodels.png) enthält.
  * Einen Navigationsbereich, der Links in einer ungeordneten Liste enthält, die auf die
    Unterseiten *about.html* und *contact.html* führen. Beschriften Sie die Links mit "Über"
    und "Kontakt".
  * Eine kurze, textuelle Einführung darüber, welche Inhalte der Shop bietet.
  * Eine Produktanzeige in tabellarischer Form. Enthalten sein sollen: Artikelnummer, Bezeichnung,
    Beschreibung, Preis und ein Button, um den Artikel in den Warenkorb zu legen. Denken Sie daran,
    die Tabellenspalten über Kopfzeilen entsprechend zu beschriften. Da Sie in der ersten Aufgabe
    noch keinen richtigen Inhalt haben, erstellen Sie drei Tabellenzeilen mit Beispielinhalten. Der
    Button soll vorhanden sein, aber noch keine Funktion erfüllen.
  * Einen Fußbereich, welcher einen Rechtehinweis (Copyright) enthält.

**about.html**: Implementieren Sie in der Datei *about.html*:

  * Ein kurzes Firmenstatement mit Anschrift und Impressum - seien Sie kreativ, das ist kein *echter* Shop :-)
  * Die Seite soll den gleichen Kopf- und Fußbereich wie die Hauptseite erhalten.
  * Die Seite soll einen Navigationsbereich erhalten, der Links in einer ungeordneten Liste enthält,
    die auf die Seiten *contact.html* und *index.html* führen. Beschriften Sie die Links mit "Kontakt" und
    "Zurück".

**contact.html**: Implementieren Sie in der Datei *contact.html*:

  * Ein Kontaktformular (Variablennamen in Klammern!), um die ToyModels GmbH zu kontaktieren. Das Formular soll
    Eingabefelder für Name (*name*), Vorname (*vorname*), E-Mail-Adresse (*mail*) und ein 20-zeiliges und 40 Zeichen
    breites Textfeld für die Nachricht (*message*), sowie jeweils einen Button zum Absenden und Zurücksetzen des
    Formulars enthalten (Beschriftung: "Absenden" und "Zurücksetzen"). Die einzelnen Formularelemente sollen jeweils
    in einem eigenen Absatz stehen. Alle Felder zwingend ausgefüllt werden müssen, bevor das Formular abgesendet
    werden kann. Vergessen Sie auch nicht, jedem Formularelement eine passende Bezeichnung zu geben. Fügen Sie dem
    Formular noch ein **verstecktes(!)** Eingabefeld mit dem Variablennamen *studentid* hinzu, welches Ihren
    Login-Namen enthält (Bsp.: foobar1234)!

    Beim Absenden des Formulars sollen die Formulardaten als **POST**-Request an die URL

        http://webprog.informatik.fh-nuernberg.de/praktikum/a1/contact.php

    übertragen werden. Wenn die Übertragung erfolgreich war, erhalten Sie eine entsprechende Antwort in Form einer
    einfachen Webseite vom Server. **HINWEIS**: Das Absenden des Formulars funktioniert nur aus den Informatik-Laboren
    oder aus dem IN-VPN!

  * Die Seite soll den gleichen Kopf- und Fußbereich wie die Hauptseite erhalten.
  * Die Seite soll einen Navigationsbereich erhalten, der Links in einer ungeordneten Liste enthält,
    die auf die Seiten *about.html* und *index.html* führen. Beschriften Sie die Links mit "Über" und
    "Zurück".

## Hinweise zur Bearbeitung der Aufgabe

  * Implementieren Sie Ihre Lösung ausschliesslich innerhalb der vorgegebenen Dateien und ändern Sie
    deren Namen und Speicherort nicht, da sonst keine Bewertung erfolgen kann.
  * Verwenden Sie nur HTML5 in dieser Aufgabe, kein CSS oder Javascript.
  * Verwenden Sie die semantischen HTML5-Elemente sinnvoll und angemessen.
    Auch wenn einige Elemente einen gewissen Interpretationsspielraum zulassen, ist in den allermeisten
    Fällen der Zweck einzelner Elemente sehr klar definiert. **Lesen Sie die Dokumentation bzw. Spezifikation
    der Elemente**!
  * Versuchen Sie nicht, HTML zu verwenden, um das Aussehen der Seite zu beeinflussen (Punktabzug!).
  * Verwenden Sie keine *div*- oder *span*-Elemente (Punktabzug!).
  * Das Table-Element hat *keine Attribute*, die Sie in dieser Aufgabe verwenden sollten (nein, kein border! -> Punktabzug!).
  * Achten Sie darauf, Umlaute und andere Sonderzeichen entsprechend zu codieren.
  * Der erstellte HTML5 Quellcode ist angemessen zu dokumentieren.

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch mit
    der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die
    Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal
    können 0 Pukte erreicht werden.
  * Ihre HTML5 Dateien werden mit dem W3C Validator Service (https://validator.w3.org/) geprüft. Hier
    dürfen keine Warnungen oder Fehler ausgegeben werden. Warnungen führen zu einem Punktabzug von einem (1),
    Fehler zu einem Abzug von zwei (2) Punkten.
  * Jedes div- oder span-Element im Code führt zu einem Abzug von einem (1) Punkt.
  * Je nach Fehlen weiterer funktionaler Anforderungen gemäß der Aufgabenstellung kann ein weiterer Punkabzug
    erfolgen (z.B. führt das fehlen des geforderten Kopfbereiches zum Abzug eines Punktes).

## Quellenangaben

  * Logo Clipart von http://clipart-library.com/clipart/269482.htm
