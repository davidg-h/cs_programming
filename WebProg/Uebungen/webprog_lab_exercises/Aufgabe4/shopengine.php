<?php
error_reporting(E_ALL);
/* Fehlt hier vielleicht auch etwas? */

class ShopEngine
{

  /* Überlegen Sie sich, welche privaten oder öffentlichen Membervariablen Ihre Klasse braucht. */
  private $db;
  private $cart = [];

  public function __construct()
  {
    /* Initialisieren Sie hier die Datenbankverbindung und ggf. das Session-Management */
    /* Achten Sie dabei auf korrekte Fehlerbehandlung! */
    /* HINWEISE:

       - Verwenden Sie ausschliesslich PHP Data Objects (PDO) für den Datenbankzugriff.
       - Verwenden Sie ausschliesslich die globalen Konstanten DB_DSN, DB_USER und DB_PASS aus
         der config.php, um die Verbindung zur Datenbank herzustellen!

    */

    $this->db = new PDO("sqlite:X:\\1.SchuleTHSynchro\\MinSemester4\\WebProg\\Uebungen\\webprog_lab_projects\\Aufgabe4\\toymodels.db");

    if (isset($_SESSION["cart"])) {
      $this->cart =  &$_SESSION["cart"];
    } else {
      $_SESSION["cart"] = &$this->cart;
    }
  }

  public function generateArticleTable()
  {

    /*
      Hier erzeugen Sie die Artikelübersicht. Der Rückgabewert der Funktion ist eine Zeichenkette,
      die die einzelnen Tabellenzeilen enthält. Vergleichen Sie Ihr Ergebnis mit der Beispielimplementierung.
    */
    $query = "Select ArtikelNr, ArtikelName, Beschreibung, GruppenNr, case when Bestandsmenge > 0 then 'ja' else 'nein' end as Lieferbar, Listenpreis from Artikel;";
    $preparedStmt = $this->db->prepare($query);
    $preparedStmt->execute();
    $result = $preparedStmt->fetchAll();

    $html = "";
    foreach ($result as $row) {
      $html .= "<tr>";
      $html .= "<td>" . $row['ArtikelNr'] . "</td>";
      $html .= "<td>" . $row['ArtikelName'] . "</td>";
      $html .= "<td>" . $row['Beschreibung'] . "</td>";
      $html .= "<td>" . $row['GruppenNr'] . "</td>";
      $html .= "<td>" . $row['Lieferbar'] . "</td>";
      $html .= "<td>" . $row['Listenpreis'] . "</td>";
      $html .= "<td>" . "<form action='toymodels.php' method='GET'><button name='artikelNr' value='{$row["ArtikelNr"]}' type='submit'>In den Warenkorb</button></form>" . "</td>";
      //$html .= "<td>" . '<form action="toymodels.php" method="Post"><button type="submit">' . $phpString . 'In den Warenkorb</button></form>' . "</td>";
      $html .= "</tr>";
    }
    return $html;
  }

  public function numberOfItemsInCart()
  {
    /* Diese Funkion gibt die Anzahl der Elemente im Warenkorb zurück. */
    $count = 0;
    foreach ($this->cart as $key => $value) {
      $count++;
    }
    return $count;
  }

  public function addToCart($itemId)
  {
    if (isset($this->cart[$itemId])) {
      $this->cart[$itemId]++;
    } else {
      $this->cart[$itemId] = 1;
    }
  }

  public function generateCartTable()
  {
    /*
      Hier erzeugen Sie die Warenkorbübersicht, sofern Artikel im Warenkorb sind.
       Der Rückgabewert der Funktion ist eine Zeichenkette, die die einzelnen Tabellenzeilen enthält.
       Vergleichen Sie Ihr Ergebnis mit der Beispielimplementierung!
    */
    $cartItemsNumber = $this->numberOfItemsInCart();
    $query = "Select ArtikelNr, ArtikelName, GruppenNr, Listenpreis from Artikel where ArtikelNr in (";
    for ($i = 0; $i < $cartItemsNumber; $i++) {
      if ($i === $cartItemsNumber - 1) $query .= "?);";
      else $query .= "?,";
    }

    $preparedStmt = $this->db->prepare($query);
    $preparedStmt->execute(array_keys($this->cart));
    $result = $preparedStmt->fetchAll();

    $tableHead = <<<tHead
    <table>
      <thead>
        <tr>
          <th>Artikelnummer</th>
          <th>Bezeichnung</th>
          <th>Warengruppe</th>
          <th>Preis</th>
          <th>Menge</th>
          <th>Gesamtsumme</th>
        </tr>
      </thead>
    tHead;

    $cartTable = "";
    $grandTotal = 0;
    foreach ($result as $row) {
      $cartTable .= "<tr>";
      $cartTable .= "<td>" . $row['ArtikelNr'] . "</td>";
      $cartTable .= "<td>" . $row['ArtikelName'] . "</td>";
      $cartTable .= "<td>" . $row['GruppenNr'] . "</td>";
      $cartTable .= "<td>" . $row['Listenpreis'] . " &euro;</td>";
      $cartTable .= "<td>" . $this->cart[$row['ArtikelNr']] . "</td>";
      $cartTable .= "<td>" . $this->cart[$row['ArtikelNr']] * $row['Listenpreis'] . " &euro;</td>";
      $cartTable .= "</tr>";
      $grandTotal += $this->cart[$row['ArtikelNr']] * $row['Listenpreis'];
    }
    $cartTable .= "<tr><td></td><td></td><td></td><td></td><td></td><td>" . $grandTotal . " &euro;</td></tr>";

    $tableBody = <<<tbody
      <tbody>
        $cartTable
      </tbody>
    </table>
    tbody;

    return $tableHead . $tableBody;
  }
}
