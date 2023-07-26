# BINGO! 
## Javascript Übung - Web-Anwendungen - **Lösungsvorschlag**

In diesem Branch finden Sie einen möglichen Lösungsvorschlag.
Dies ist natürlich nicht die einzig mögliche Vorgehensweise.

### Aufgabenstellung

Implementieren Sie ein "Bingo"-Spiel in Javascript. Dabei soll
sowohl das UI als auch die Spiel-Logik komplett skriptbasiert
entwickelt werden. Nutzen Sie das <main>-Element der bingo.html
als "Einstiegspunkt". Ggf. müssen Sie im HTML Links zu CSS und
notwendigen JS Dateien ergänzen.

#### Spielablauf

Es soll ein Gitter mit einem NxM-Kacheln großen Spielfeld erzeugt 
werden. Der Inhalt der Kacheln  (Text) soll dabei aus einem
(vorab zu erstellendem) Array mit mindestens NxM Einträgen
gelesen werden. Zum Beispiel für ein 2x2 großes Spielfeld:

const DATA = [ "foo", "bar", "foobar", "baz" ];

let game = new Game(2,2, DATA);

Die Darstellung des Spielfeldes (CSS) sowie die Wahl der dazu
notwendigen HTML-Elemente bleibt Ihnen überlassen.

Nach dem Laden des Spielfeldes soll der Nutzer die einzelnen
Kacheln anklicken können - selektierte Kacheln sollen sich
optisch von den unselektierten unterscheiden.

Sobald der Spieler eine ganze Zeile, Spalte oder Diagonale von 
Kacheln selektiert hat gilt das Spiel als gewonnen. Dies soll
ebenfalls optisch (und/oder akkustisch? :-) kenntlich gemacht
werden.

#### Vorgaben

- Verwenden Sie keine HTML/JS Frameworks. Nutzen Sie nur die
Möglichkeiten, die Ihnen der Browser bietet.
- Erzeugen Sie das Spielfeld (HTML-Elemente) mit Javascript,
nicht durch das Einfügen von HTML-Elementen in der bingo.html
- CSS müssen Sie nicht mit Javascript erzeugen. Erstellen Sie
wie gewohnt eine externe CSS Datei.
- Idealerweise ergänzen Sie also die bingo.html nur um externe
CSS und Skriptdateien sowie ggf. notwendige Event-Handler für 
den Start des Spiels (aber auch das ist nicht zwingend notwendig,
überlegen Sie sich, wie Sie das "Startup" anders lösen können)

#### Tipps

- Es bietet sich an, die Implementierung ggf. auf mehrere
Dateien aufzuteilen und die Logik der Anwendung auf entsprechende
Objekte zu verteilen
- Auch hier ist ggf. ein an MVC angelehntes Muster hilfreich
(z.B. Game -> Spiellogik/Modell, GameView -> Ansicht/HTML, 
GameController -> Nutzerinteraktion/Koordination v. Modell und View)
- Sie können die Implementierung aber grundsätzlich angehen, wie Sie
möchten 
- Testen Sie, ob Ihre Implementierung auch auf einem Mobilgerät mit
Touch-Eingabe funktioniert
- Für die ganz wagemutigen: implementieren Sie die einzelnen Komponenten
als Javascript Module. Was ändert sich hier? Welche Schwierigkeiten treten
dabei auf? Wie kann man die lösen?
- Ansonsten dürfen Sie sich auch gerne "austoben" (Drag&Drop anyone?) und 
viel Spass bei der Implementierung!

#### Abgedeckte Themenfelder

Die Aufgabe Deckt folgende Themenfelder ab:

- DOM Manipulation
- Eventverarbeitung
- Softwareentwicklung und Strukur allgemein