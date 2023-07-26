
# Toymodels as a Service (TAAS? ;-)! 

## Javascript/PHP Übung - Web-Anwendungen

### Aufgabenstellung

In dieser Aufgabe sollen Sie unseren Toymodels-Webshop
so umstellen, dass die Toymodels Shop-Webseite sich 
verhält, wie eine "Single-Page"-Anwendung. Diese kommuniziert
dann mit dem Shop-Backend, welches zu einem Web-Service 
weiterentwickelt werden soll.

#### Ablauf

Als Startpunkt sollten Sie den aktuellen Stand der Toymodels-Shop-Seite
verwenden. Das PHP-Backend kann im Grunde ohne viel Aufwand so umgestellt
werden, dass statt HTML lediglich Daten transportiert werden. Verwenden
Sie als Transportdatenstruktur das **JSON** Format.

Da die Webseite nun keine serverseitig erzeugte Webseite mehr sein soll,
benötigen wir als Einstiegspunkt auch nur noch eine ***html***-Datei und
kein PHP-Skript mehr. Die HTML-Hauptseite muss natürlich den entsprechenden
JavaScript-Programmcode enthalten, welcher ***asynchron*** mit dem Shop-Service
kommuniziert und die Webseite dann entsprechend der erhaltenen Daten aufbaut.
Hier können Sie als Startpunkt die ursprüngliche index.html (ohne Funktionalität)
verwenden.

Es soll so alle bisher implementierte Funktionalität erhalten bleiben: 

  - Hauptseite mit Artikelansicht
  - Artikel in den Warenkorb legen
  - Warenkorb seite
  - Artikelsuche auf der Hauptseite

#### Vorgaben

- Verwenden Sie keine HTML/JS Frameworks. Nutzen Sie nur die
Möglichkeiten, die Ihnen der Browser bietet.

#### Tipps & Spoiler 

- Die index.php benötigen Sie jetzt nicht mehr als Startpunkt
für die Webseite. Dennoch sollten Sie sie nicht einfach "wegwerfen".
Sie kann als Startpunkt für den Service dienen (sollte dann aber anders
heißen!).
- Überlegen Sie sich vorab auf welche Requests (HTTP-Anfragen, URLs, Parameter)
Ihr Service wie antworten soll und wie JavaScript im Anschluss die Antwort
weiterverarbeiten muss (Tabelle erzeugen, Buttons, Clickhandler usw.). Es gibt
hier keine starren Regeln, Sie können selbst entscheiden, wie Ihre API aussehen soll.
- Versuchen Sie so viel wie möglich des existierenden Codes wiederzuverwenden. Das
geht bei einigen Teilen sehr gut, bei anderen nicht.

#### Abgedeckte Themenfelder

Die Aufgabe Deckt folgende Themenfelder ab:

- DOM Manipulation
- Eventverarbeitung
- Softwareentwicklung und Strukur allgemein
- Asynchrone Requests / Responses (fetch + config)
- JSON
- Web-Services