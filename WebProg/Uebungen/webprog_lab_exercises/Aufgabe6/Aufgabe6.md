
## Praktikum Web-Programmierung
# Aufgabe 6 - DOM / PHP / FETCH

In dieser Aufgabe beschäftigen wir uns mit Webservices und asynchronen Anfragen.

### Ein einfacher Rechner - die Webservice Version

  * Gegeben ist die Datei ***calculator_service.php***. In dieser Datei sollen Sie einen
    einfachen Rechner implementieren, der die vier Grundrechenarten +, -,
    \* und / unterstützt. Die Operanden werden in einer GET-Anfrage an Ihr Programm übergeben. Sie müssen also die entsprechenden Parameter aus der Anfrage herauslesen und die daraus resultierende
    Operation mit den Operanden durchführen.
  * Die Parameter, die an den Service übergeben werden müssen, sind "method", "op", "va" und
    "vb". Der Parameter "method" muss den Wert "calculate" enthalten. "va" und "vb" sollen Zahlen sein und "op" ist ein Wert aus der Menge ("+","-","*","/"). Vergleichen Sie dazu auch Aufgabe 4.
  * Das Ergebnis soll als JSON-Zeichenkette zurückgegeben werden. Das JSON-Objekt soll
    die Form

        {
           "error": True | False,
           "result": 0 falls Fehler | Berechnungsergebnis andernfalls,
           "message": Fehlermeldung falls Fehler | OK andernfalls
        }

      haben.
  * Die Datei ***calculator.html*** enthält das Web-Frontend, welches den Webservice ansprechen
    soll. Der Dienst soll mit einem **fetch**-Request beim drücken des Buttons, welches die von
    Ihnen zu implementierende Funktion **sendRequest()** aufruft, angesteuert werden. Sobald die
    Antwort vorliegt, nehmen Sie entsprechende DOM-Manipulationen vor, um das Ergebnis
    anzuzeigen. Verwenden Sie für Ihre Implementierung die Service-URL ***http://webprog.informatik.fh-nuernberg.de/praktikum/a6/calculator_service.php***.
  * Das Ergebnis der Berechnung soll in dem H2-Element mit der ID "result" in schwarzer Schrift
    unterhalb des Formulares in der Form *"Ergebnis: 2 + 2 = 4"* angezeigt werden (Beispiel für die Eingaben 2,2, und +).
  * Achten Sie darauf, dass fehlerhafte Eingaben abgefangen werden. Ein Fehler in der Eingabe
    soll in dem H2-Element mit der ID "result" in roter Schrift unterhalb des Formulares angezeigt werden.
  * Das vorgegebene HTML-Grundgerüst **darf nicht verändert**, aber um entsprechenden Code
    ergänzt werden.
  * Um das gewünschte Verhalten ausprobieren zu können, finden Sie eine Beispielimplementierung
    unter ***http://webprog.informatik.fh-nuernberg.de/praktikum/a6/calculator.html***. Den Web-Service finden Sie unter ***http://webprog.informatik.fh-nuernberg.de/praktikum/a6/calculator_service.php*** (nur aus dem IN- oder Hochschul-VPN erreichbar).

## Hinweise zur Bearbeitung der Aufgabe

  * **Verändern Sie die vorgegebenen Dateien, insbesondere den vorgegeben Code nicht!** Ergänzen
    Sie diese nur an den dafür vorgesehenen Stellen und füllen Sie die markierten Lücken!

## Hinweise zur Abgabe und Bewertung

### Abgabe

  * **Verwenden Sie zu Erstellung des Abgabepaketes unbedingt das create_submission.py Skript.**
  * Denken Sie daran, die projects.config mit den korrekten Daten zu füllen.

### Bewertung

  * Die maximale Punktzahl für diese Aufgabe beträgt 20 Punkte. Jede Abgabe startet automatisch
    mit der vollen Bewertungszahl. Mittels eines semiautomatischen Prüfverfahrens wird ermittelt, ob die Abgabe den Anforderungen entspricht. Für Fehler in der Implementierung gibt es Punktabzug. Minimal können 0 Pukte erreicht werden.

## Zusätzliche Informationen

  * Beachten Sie bei dieser Aufgabe insbesondere die jetzt anders verteilte Ablaufstruktur des
    Progamms. Überlegen Sie sich genau, welcher Code wann und wo ausgeführt wird und was das Ergebnis ist.
  * Wenn Sie zusätzlich noch Üben wollen, können Sie z.B. eine andere Form der Parameterübergabe implementieren
    (z.B. POST als Query-String und/oder JSON-Objekt). Geben Sie diese Varianten aber nicht mit ab.
  * Eine weitere Möglichkeit, mehr Erfahrung zu sammeln und sich auf die Klausur gut vorzubereiten, wäre auch,
    den Webshop aus Aufgabe 4 so zumzubauen, dass der Backend-Teil (also die PHP Skripten) als Dienst laufen
    und von einem JavaScript-Frontend verwendet werden.
