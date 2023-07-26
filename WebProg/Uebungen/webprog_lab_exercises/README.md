
# Web-Programmierung Praktikum

In diesem Repository finden Sie die Aufgaben zum Praktikum im Fach Web-Programmierung.
Bitte lesen Sie die folgenden Informationen Aufmerksam durch!

## Git Projektstruktur

Dieses Projekt (webprog_lab_projects) ist das "Hauptprojekt" für alle Praktikumsaufgaben.
Die einzelnen Aufgaben sind als Untermodule Bestandteil dieses Hauptprojektes, werden aber
nicht automatisch ausgecheckt. Sie können das Hauptprojekt und alle Untermodule mit folgendem
Befehl zusammen auschecken:

    git clone --recurse-submodules git@git.informatik.fh-nuernberg.de:lehre/webprog/webprog_lab_projects.git

Damit das klonen des Repositories und der entsprechenden Untermodule reibungslos klappt, sollten Sie
einen SSH-Schlüssel zum Zugriff auf Gitlab verwenden. Eine Anleitung dazu finden Sie hier:

    https://git.informatik.fh-nuernberg.de/help/ssh/README#generating-a-new-ssh-key-pair

Falls Sie keinen SSH-Schlüssel verwenden wollen oder können, ist etwas manueller Aufwand notwendig.
Klonen Sie zunächst das Basis-Repository unter Angabe Ihres Benutzernamens und initialisieren Sie die
Untermodulkonfiguration:

    git clone https://USERNAME@git.informatik.fh-nuernberg.de/lehre/webprog/webprog_lab_projects.git
    git submodule init

Dabei ersetzen Sie `USERNAME` durch Ihren Nutzernamen, den Sie für den Zugriff auf die IT-Dienste der
Fakultät Informatik benutzen. Danach editieren Sie die die Datei `.gitmodules` und ersetzen für *jedes*
Untermodul den Inhalt der Variablen `url` durch die äquivalente `https://USERNAME@...` URL. Schliesslich sollten Sie
durch

    git submodule sync
    git submodule update

klonen können.

### Updates

Da die Untermodule im Laufe des Semesters vermutlich Änderungen erfahren (Bugfixes, neue Aufgaben...),
sollten Sie das geklonte Repository regelmäßig aktualisieren. Während allerdings `git pull` zwar das
Hauptrepository aktualisiert, werden Untermodule nicht automatisch auf den neuesten Stand gebracht.
Sie können alle Untermodule eines Projektes mit folgendem Befehl automatisch aktualisieren lassen:

    git pull
    git submodule update --init --recursive

Hinweis: das funktioniert auch nur reibungslos, wenn Sie SSH zum Zugriff auf das Gitlab verwenden. Weitere
Informationen zur Arbeit mit Git-Untermodulen finden Sie in der Dokumentation unter
https://git-scm.com/book/en/v2/Git-Tools-Submodules.

## Aufgaben

Die Aufgaben finden Sie jeweils in einem Unterverzeichnis des Namens 'AufgabeX', wobei
X für die Nummer der Aufgabe steht. Innerhalb der Aufgabenverzeichnisse finden Sie die
Aufgabendstellung als Markdown-Dokument (AufgabeX.md). Weiterhin ist für die Aufgaben
meistens eine Verzeichnisstruktur bereits vorgegeben und bei einigen Dateien auch
Implementierungsschablonen bzw. Dateien in denen Ihre Implementierung erfolgen soll.

**Ändern Sie die vorgegebene Verzeichnisstruktur sowie die vorgegebenen Dateinamen nicht,
da Ihre Abgabe sonst nicht bewertet werden kann!**

Soweit einzelne Aufgaben es vorsehen, dass Sie selbst beliebige Dateien erstellen und der
Abgabe hinzufügen dürfen, ist dies in der Regel in der Aufgabenstellung angegeben.

## Allgemeine Konfiguration und Abgabe

Im Hauptverzeichnis des Projektes finden Sie eine Datei mit dem Namen "projects.config".
In diese Datei tragen Sie bitte nach dem vorgegebenen Schema Ihren Namen, Ihre Matrikelnummer
und Ihren Loginnamen (Benutzername an IT-Systemen der Hochschule) ein.

Sobald Sie eine Aufgabe fertiggestellt haben, können (und sollten) Sie das Python-Skript
"create_submission.py" verwenden, um eine ZIP-Datei zur Abgabe zu erstellen. Dieses
Skript befindet sich ebenfalls im Hauptverzeichnis des Projektrepositories. Um das
Skript auszuführen, benötigen Sie einen Python 3 Interpreter mit installiertem
zipfile-Package (z.B. aus der Anaconda-Installation auf den Labor PCs).

Sie können das Skript wie folgt aufrufen:

    python create_submission.py AufgabeX

Dabei müssen Sie das X durch die konkrete Aufgabennummer ersetzen. Der Aufruf erzeugt,
sofern keine Fehler passieren, eine ZIP-Datei mit dem Namen *ihrLogin_aX_wpsose21.zip*,
welche Sie dann über das Abgabeinterface im zugehörigen Moodle-Kurs abgeben können.

**HINWEIS**: Das Python-Skript ist ein Kommandozeilen-Tool. Sie müssen es in einer
Konsole (Shell, Eingabeaufforderung, ...) aufrufen. Sie können das Skript **nicht**
über die grafische Benutzerschnittstelle von Windows nutzen! Auf unixoiden
Betriebssystemen (Linux, OS X, BSD, o.ä.) können Sie das Flag "ausführbar" für die
Datei setzen und das Skript wie ein gewöhnliches Kommandozeilentool verwenden.

## Sonstige Hinweise

  * Rechnen Sie damit, dass das Projektrepository relativ häufig aktualisiert wird. Zum
    Einen werden neue Aufgaben hinzugefügt, zum Anderen wird es ggf. notwendig sein,
    Fehler in den Werkzeugen, Angaben oder Codeschablonen zu beheben. Aktualisieren Sie
    deshalb den master-Branch regelmäßig!
  * Es empfiehlt sich, nach dem Auschecken des Repositories einen Branch anzulegen
    und auf diesem zu Arbeiten. Dann können Sie bei Änderungen bzw. Aktualisierungen
    des master-Branches diese recht einfach zu Ihren Änderungen hinzufügen.
  * Falls Sie nicht auf einem separaten Branch arbeiten kann es passieren, dass Sie
    aufgrund von notwendugen Änderungen an den im Repository enthaltenen Dateien,
    Aktualisierungen des master-Branches nicht einspielen können (git pull schlägt dann
    fehl). Falls das passiert, sollten Sie zunächst Ihre Änderungen stashen (git stash)
    und nach dem Update, die Änderungen aus dem Stash wieder anwenden (git stash apply).
