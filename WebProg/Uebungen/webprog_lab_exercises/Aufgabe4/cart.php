<!--

    HIER MÜSSEN SIE CODE ERGÄNZEN!

    Hier sollten Sie eine Instanz der Ihrer ShopEngine implementierung erstellen.
    Speichern Sie die Instanz in der Variablen $shopEngine.

-->
<?php
error_reporting(E_ALL);

session_start(["cookie_lifetime" => 30]);
include_once("shopEngine.php");
$shopEngine = new ShopEngine();
?>
<!doctype html>
<html lang="de">

<head>
  <title>Web-Programmierung Praktikum Aufgabe 4</title>
  <link rel="stylesheet" href="css/toymodels.css">
  <style>
    td:nth-child(2),
    td:nth-child(7) {
      width: 200px;
    }

    td:nth-child(3) {
      text-align: left;
    }

    td:nth-child(3) {
      text-align: right;
      width: 70%;
      font-weight: bold;
    }
  </style>
</head>

<body>
  <header>
    <nav>
      <ul>
        <li><a href="toymodels.php">Zur&uuml;ck</a></li>
      </ul>
    </nav>
    <img class="hdrbox" src="img/toymodels.png" alt="Hier ist das Firmenlogo">
    <section class="hdrbox">
      <h1>Willkommen bei der ToyModels GmbH</h1>
      <p>Wir freuen uns auf Ihren Einkauf!</p>
    </section>
  </header>

  <main>
    <section>
      <h1>Warenkorb</h1>

      <?php
      /* Vervollständigen Sie die Abfrage */
      if (/* Der Warenkorb keine Elemente enthält */$shopEngine->numberOfItemsInCart() === 0) { // <----- HIER MÜSSEN SIE CODE ERGÄNZEN!
        echo "<h2 style='color:red;'>Ihr Warenkorb ist leider leer :-(</h2>";
      } else { /* Den Code hier sollten Sie so stehen lassen. generateCartTable() erzeugt ja die Tabelle! */
        echo $shopEngine->generateCartTable();
        echo "<br>";
        echo "<form action='http://www.endedesinternets.de/'><button type='submit'>Bestellung absenden!</button></form>";
      }
      ?>
    </section>

  </main>
  <footer>
    <p>This page is copyright &copy; 2020 by the Toymodels GmbH</p>
  </footer>
</body>

</html>