<!--

    HIER MÜSSEN SIE CODE ERGÄNZEN!

    Hier sollten Sie eine Instanz der Ihrer ShopEngine implementierung erstellen.
    Speichern Sie die Instanz in der Variablen $shopEngine.

    Weiterhin ist es hier eine gute Möglichkeit, Weiterleitungen durchzuführen, sofern
    das nötig ist.

-->
<?php
error_reporting(E_ALL);

session_start(["cookie_lifetime" => 30]);
include_once("shopengine.php");

$shopEngine = new ShopEngine();

if (isset($_GET["artikelNr"])) {
  $shopEngine->addToCart($_GET["artikelNr"]);
  header("Location: " . $_SERVER['PHP_SELF']);
}
?>
<!doctype html>
<html lang="de">

<head>
  <title>Web-Programmierung Praktikum Aufgabe 4</title>
  <link rel="stylesheet" href="css/all.css">
  <link rel="stylesheet" href="css/toymodels.css">
</head>

<body>
  <header>
    <nav>
      <ul>
        <li><a href="cart.php"><i class="fas fa-shopping-cart"></i>Warenkorb
            <!-- HIER MÜSSEN SIE CODE ERGÄNZEN (Warenkorbzähler)! -->
            <?php echo $shopEngine->numberOfItemsInCart(); ?>
          </a></li>
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
      <h2>Hier finden Sie eine Auswahl unserer Produkte</h2>
      <table>
        <thead>
          <tr>
            <th>Artikelnummer</th>
            <th>Bezeichnung</th>
            <th>Beschreibung</th>
            <th>Warengruppe</th>
            <th>Lieferbar</th>
            <th>Preis</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <!-- Hier wird die Artikeltabelle erzeugt - das sollten Sie so stehen lassen. -->
          <?php echo $shopEngine->generateArticleTable(); ?>
        </tbody>
      </table>
    </section>
  </main>

  <footer>
    <p>This page is copyright &copy; 2020 by the Toymodels GmbH</p>
  </footer>
</body>

</html>