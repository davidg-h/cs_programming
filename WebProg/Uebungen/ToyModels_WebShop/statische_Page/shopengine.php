<?php
error_reporting(E_ALL);

require_once('shopengine_htmlcontent.php');

class ShopEngine
{
  private $db;
  // für warenkorb
  private $cart = [];

  public function __construct()
  {
    try {
      // PDO with sqlite manages database connection & access
      $this->db = new PDO("sqlite:X:\\1.SchuleTHSynchro\\MinSemester4\\WebProg\\Uebungen\\ToyModels_WebShop\\statische_Page\\toymodels.db");

      // PDO with mySQL
      // $this->db = new PDO("mysql:localhost;port=8080", "username", "password");
      // $this->db->exec("USE (databaseName)");
      /*
            $this->db = new PDO("mysql:localhost", "webaw", "webaw");
            $this->db->exec("USE webaw;");
            */

      if (isset($_SESSION["cart"])) {
        // verknüpfung warenkorb mit session
        $this->cart = &$_SESSION["cart"];
      } else {
        $_SESSION["cart"] = &$this->cart;
      }
    } catch (PDOException $e) {
      die("PDO Exception: " . $e->getMessage());
    }
  }

  public function genArticleTable($search = "")
  {
    // holt den user search von der session in eine variable
    if ($search === "") {
      if (isset($_SESSION["currentsearch"]) && $_SESSION["currentsearch"] !== "") {
        $search = $_SESSION["currentsearch"];
      }
    }

    if ($search === "") {
      // wenn suche leer dann tabelle normal anzeigen
      $sql = "SELECT ArtikelNr, ArtikelName, Beschreibung, Listenpreis FROM Artikel;";
    } else {
      // ansonsten den sql preparen
      $sql = "SELECT ArtikelNr, ArtikelName, Beschreibung, Listenpreis FROM Artikel WHERE Beschreibung LIKE '%'|| ? ||'%';";
      // damit der search beim neuen laden der seite nicht verloren geht
      $_SESSION["currentsearch"] = $search;
    }

    $stmt = $this->db->prepare($sql);

    if ($search === "") {
      $stmt->execute();
    } else {
      // ersetz ? mit dem search vom user
      $stmt->execute([$search]);
    }
    // query statement
    // $stmt = $this->db->query($sql);

    $result = $stmt->fetchAll();

    $html = "<tbody>" . PHP_EOL;

    foreach ($result as $row) {
      $html .= "<tr>";
      $html .= "<td>" . $row["ArtikelNr"] . "</td>" . PHP_EOL;
      $html .= "<td>" . $row["ArtikelName"] . "</td>" . PHP_EOL;
      $html .= "<td>" . $row["Beschreibung"] . "</td>" . PHP_EOL;
      $html .= "<td>" . $row["Listenpreis"] . " &euro;</td>" . PHP_EOL;
      $html .= "<td><form action='index.php' method='get'><button type='submit' name='artikelNummer' value='{$row["ArtikelNr"]}'>In den Warenkorb</button></form></td>" . PHP_EOL;
      $html .= "</tr>" . PHP_EOL;
    }

    $html .= "</tbody>" . PHP_EOL;

    return $html;
  }

  function addToCart($article)
  {
    if (isset($this->cart[$article])) {
      $this->cart[$article]++;
    } else {
      $this->cart[$article] = 1;
    }
  }

  function noOfItemsInCart()
  {
    $total = 0;
    foreach ($this->cart as $item => $count) {
      $total += $count;
    }
    return $total;
  }

  // only counts individual article numbers
  function noOfIndividualItemsInCart()
  {
    return count($this->cart);
  }

  function dumpCart()
  {
    var_dump($this->cart);
  }

  function generateCart()
  {
    // php herdocs for multiline string (attention: format stays exactly like its written)
    $tableHeader = <<<TBLHDR
<table>
<thead>
    <tr>
    <th>Art. Nr.</th>
    <th>Bezeichnung</th>
    <th>Anzahl</th>
    <th>Einzelpreis</th>
    <th>Gesamtpreis</th>
    </tr>
</thead>
<tbody>
TBLHDR;
    $tableFoot = <<<TBLFOOT
</tbody>
</table>
TBLFOOT;

    if ($this->noOfItemsInCart() === 0) {
      echo "<h1>Keine Artikel im Warenkorb!</h1>";
      return;
    }

    $sql = "SELECT ArtikelNr, ArtikelName, Listenpreis FROM Artikel WHERE ArtikelNr in (";

    // prepare statement in db->execute all "?" will be replaced with parameters in execute
    $nItems = $this->noOfIndividualItemsInCart();
    for ($i = 0; $i < $nItems; $i++) {
      if ($i == $nItems - 1) $sql .= "?)";
      else $sql .= "?,";
    }

    // prepare bevor execute
    $stmt = $this->db->prepare($sql);
    if ($stmt === false) {
      echo "Fehler bei der Erstellung des prepared Statements!";
      return;
    }

    // "?" getting replaced and query executed
    $result = $stmt->execute(array_keys($this->cart));
    if ($result === false) {
      die("Fehler bei Ausfuehrung des prepared Statements!");
    }
    $rows = $stmt->fetchAll();

    if (count($rows) === 0) {
      echo "<h1>Keine Artikel im Warenkorb! (Datenbank hat nichts gefunden)</h1>";
      return;
    }

    $table = "";
    $grandTotal = 0;
    foreach ($rows as $row) {
      $table .= "<tr>";
      $table .= "<td>" . $row["ArtikelNr"] . "</td>";
      $table .= "<td>" . $row["ArtikelName"] . "</td>" . PHP_EOL;
      $table .= "<td>" . $this->cart[$row["ArtikelNr"]] . "</td>" . PHP_EOL;
      $table .= "<td>" . $row["Listenpreis"] . " &euro;</td>" . PHP_EOL;
      $table .= "<td>" . $this->cart[$row["ArtikelNr"]] * $row["Listenpreis"] . " &euro;</td>" . PHP_EOL;
      $table .= "</tr>";
      $grandTotal += $this->cart[$row["ArtikelNr"]] * $row["Listenpreis"];
    }
    $table .= "<tr><td colspan='4'></td><td>" . $grandTotal . " &euro;</td></tr>";

    echo $tableHeader . $table . $tableFoot;
    echo "<button>Jetzt kaufen!</button>";
  }

  function createArticlePage()
  {
    // scope muss in die funktion reingezogen werden von shopengine_htmlcontent.php
    global $basePageStart;
    // auslagern wegen string ausgabe als php herdoc
    $cartCnt = $this->noOfItemsInCart() > 0 ? "(" . $this->noOfItemsInCart() . "," . "Indiv: " . $this->noOfIndividualItemsInCart() . ")" : "";

    $basePageHdr = <<<PAGEHDR
  <header> <!-- Header mit Logo, Titel, Searchbar & Login  -->
    <section id="logosection">
      <img src="img/toymodels.png">
      <h1>Toy-Models<br>Online-Shop</h1>
    </section>  
    <section id="searchbarsection">
      <form>
        <input id="searchbar" name="searchbar">
        <button id="searchbutton"><img src="img/search.png"></button>
      </form>
    </section>
    <section id="usersection">
      <button onclick="navigateToCart()" class="cartbutton"><img src="img/gift.png">
         Warenkorb $cartCnt
      </button>
      <div id="userlogin">
        <button class="cartbutton"><img src="img/ghost.png">Login</button>
        <div class="loginbox">
          <form action="login.php" method="POST">
            <label for="username">Benutzername</label>
            <input id="username" name="username">
            <label for="password">Password</label>
            <input id="password" name="password" type="password">
            <button type="submit">Einloggen</button>
          </form>
          <p id="register"><span style="text-decoration: underline; color: blue; cursor: pointer;" onclick="setupRegistrationForm()">Keine Zugangsdaten? Hier registrieren!</a></p>
        </div>
      </div>
    </section>
  </header>
PAGEHDR;

    $articleTable = "";
    if (isset($_GET["searchbar"]))
      $articleTable = $this->genArticleTable($_GET["searchbar"]);
    else
      $articleTable = $this->genArticleTable();

    $pageRest = <<<PAGEREST
  <!-- Postponed for later 
  <nav>
    <ul>
      <li><a href="about.html">&Uuml;ber</a></li>
      <li><a href="contact.html">Kontakt</a></li>
    </ul>
  </nav>
  -->

  <main>
    <section>
      <h1>Willkommen im Toy-Models Online-Shop</h1>
      <h4>Viel Spass bei Ihrem Einkauf!</h4>
    </section>
    <section id="productsection">
      <table>
        <thead>
          <tr>
            <th>Art. Nr.</th>
            <th>Bezeichnung</th>
            <th>Beschreibung</th>
            <th>Preis</th>
          </tr>
        </thead>
         $articleTable
      </table>
    </section>
  </main>

  <footer>
    <p>Copyright &copy; Toy-Models GmbH</p>
  </footer>
</body>
</html>
PAGEREST;

    // ausgabe der tabelle
    echo $basePageStart . $basePageHdr . $pageRest;
  }
}
