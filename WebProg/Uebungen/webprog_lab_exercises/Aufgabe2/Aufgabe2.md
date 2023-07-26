## Praktikum Web-Programmierung
# Aufgabe 2 - CSS

In dieser Aufgabe sollen Sie eine gegebene Webseite mit CSS gestalten. Dazu ist die Datei
*index.html*, sowie ein Logo der TH Nürnberg im Unterverzeichnis *img* vorgegeben. Darüber
hinaus finden Sie im Verzeichnis *examples* verschiedene Beispielbilder, die Ihnen zeigen,
wie  das Ergebnis der Formatierung per CSS aussehen soll.

Erstellen Sie die fehlende Datei **style.css** nach folgenden Regeln:

  * Verwenden Sie kein *Grid Layout* für die Darstellung der Seite.
  * Als Schriftart soll die Schriftart *Verdana* verwendet werden. Falls diese nicht verfügbar ist,
    verwenden Sie *Roboto*, ansonsten eine beliebige andere, serifenlose Schriftart.
  * Alle farblich hervorgehobenen Boxen haben abgerundete Ecken mit dem Radius *1em*.
  * Diese Boxen sollen zueinander und zum Rand einen Abstand von *1em* einhalten.
  * Der Text in \<header> und \<footer> soll zentriert dargestellt werden.
  * Die Boxen der Navigationsliste erhalten eine feste Breite von *14em*. Der Abstand zur Seitenleiste
    darf höher als 1em sein. Umbrechen soll die Navigationsleiste jedoch erst, wenn der Abstand
    tatsächlich geringer als 1em wird (siehe Abbildungen 1 bis 3). Wird das Fenster zu schmal, um die
    Elemente der Navigationsliste angemessen unterzubringen, darf das Aussehen von den sonstigen Vorgaben
    abweichen (siehe Abbildung 4).
  * Das \<aside>-Element soll eine feste Breite von *13em* haben. Die Höhe soll sich über die volle Höhe
    der daneben positionierten \<article>-Elemente erstrecken (siehe Abbildungen 1, 5 und 6). Hinweis:
    Sie können dazu das CSS Attribut *position* verwenden.
  * Die \<article>-Elemente sollen den Text in mehreren Spalten darstellen, wenn genug Platz vorhanden ist
    (siehe verschiedene Abbildungen). Geben dazu Sie eine Spaltenbreite von *15em* an.
  * Navigationselemente sollen die Farbe wechseln, wenn der Mauszeiger über dem Element steht (siehe
    Beispielbild 7). Außerdem soll die *gesamte Box* als Link anklickbar sein, nicht nur der Text selbst.
  * Die Farben von Text und Hyperlinks sind jeweils passend zu den Beispielbildern festzulegen (siehe
    Farbcodes in Abbildung 11).
  * Alle Hyperlinks, die in einem neuen Fenster geöffnet werden, sollen einen kleinen Pfeil vorangestellt
    bekommen (siehe z.B. Abbildungen 1, 3 und 7).
  * Hyperlinks sollen unterstrichen sein, wenn der Mauszeiger über dem Link steht (vgl. Abbildungen 7 und 8).
  * Im Footer steht ein Hyperlink mit der Klasse "**zur_th**". Dieser Link soll als Hintergrundbild das
    Bild *logo_th_nuernberg.png* verwenden. Der Link soll quadratisch sein und zunächst nur die graue Hälfte
    des Hintergrundbildes zeigen. Sobald der Mauszeiger über diesem Link steht, soll das größere, blaue Logo
    gezeigt werden (siehe Abbildungen 1 und 9).
  * Die Absätze im Fuß der Seite sollen mit etwas Abstand zueinander in der Mitte des Fußbereiches stehen.
    Reicht die Breite der Seite nicht aus, aus dürfen sie mehrzeilig stehen (siehe Abbildungen 1, 6
    und 10).
  * Alle angegebenen, festen Breiten beziehen sich auf den Inhalt der entsprechenden Box (Content), ohne
    Margin, Padding oder Rahmen.

## Hinweise zur Bearbeitung der Aufgabe

  * Die in den Beispielbildern gezeigten Farben übernehmen Sie aus Abbildung 11. Gleiche Farben sind nicht
    mehrfach in der Abbildung gekennzeichnet!
  * Die Aufgabenstellung lässt einige Gestaltungselemente offen. Dies ist zum Teil Absicht. Dennoch
    ist nicht auszuschließen, dass bei der Angabe versehentlich das eine oder andere, möglicherweise
    notwendige, Detail vergessen wurde. Fragen Sie deshalb bitte nach, falls Ihnen etwas unklar ist.
  * Selbstverständlich haben Fehler in der Aufgabenstellung keinen Einfluss auf die Bewertung der Aufgabe!
  * Die vorgegebenen Dateien dürfen nicht verändert werden!

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch mit
    der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die
    Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal
    können 0 Pukte erreicht werden.
  * Ihre CSS Datei wird mit dem W3C Validator Service (https://validator.w3.org/) geprüft. Hier dürfen
    keine Warnungen oder Fehler ausgegeben werden. Warnungen führen zu einem Punktabzug von einem (1),
    Fehler zu einem Abzug von zwei (2) Punkten.
  * Je nach Fehlen funktionaler Anforderungen kann ein weiterer Punkabzug erfolgen.

## Quellenangaben

  * Siehe index.html
