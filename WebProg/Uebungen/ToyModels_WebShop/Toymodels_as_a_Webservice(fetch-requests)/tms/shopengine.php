<?php
error_reporting(E_ALL);

class ShopEngine {

  private $pdo;
  private $cart = [];
  private $sqlite = true;
 
  public function __construct() {

    try {
      $this->pdo = new PDO("sqlite:C:\\Users\\mtessmann\\data\\develop\\lehre\\webprog\\webaw_exercises\\toymodels\\toymodels.db");
      /* For MySQL uncomment this */
      /*
      $this->pdo = new PDO("mysql:host=localhost;port=3306;", DB_USER, DB_PASS);
      $this->pdo->exec("USE webaw;");
      $this->sqlite = false;
      */
      if (isset($_SESSION["cart"])) {
        $this->cart = &$_SESSION["cart"];
      } else {
        $_SESSION["cart"] = &$this->cart;
      }
    } catch (PDOException $e) {
      die("PDO Exception: " . $e->getMessage());  
    }

  }

  public function getMainContentData($filter = "") {
    
    if ($filter !== "") {
      if ($this->sqlite)
        $sql = "SELECT ArtikelNr, ArtikelName, Beschreibung, Listenpreis FROM Artikel WHERE Beschreibung LIKE '%' || ? || '%';";
      else
        $sql = "SELECT ArtikelNr, ArtikelName, Beschreibung, Listenpreis FROM Artikel WHERE Beschreibung LIKE concat('%',?,'%');";
    } else {
      $sql = "SELECT ArtikelNr, ArtikelName, Beschreibung, Listenpreis from Artikel;";
    }

    $stmt = $this->pdo->prepare($sql);
    
    $stmt->execute($filter !== "" ? [$filter]:null);
    $resultData = $stmt->fetchAll(PDO::FETCH_ASSOC);

    $result["head"] = ["Artikelnummer", "Name", "Beschreibung", "Preis"];
    $result["content"] = [];

    foreach ($resultData as $row) {
      $item = [ $row["ArtikelNr"], $row["ArtikelName"], $row["Beschreibung"], $row["Listenpreis"] ];
      $result["content"][] = $item;
    }

    $result["nCartItems"] = $this->numberOfItemsInCart();

    return $result;
  }

  public function numberOfItemsInCart() {
    /* -> Functional version of the loop below
    $result = array_reduce($this->cart, (fn($curr, $next) => $curr + $next), 0);
    var_dump($result);
    */
    $numItems = 0;
    foreach ($this->cart as $key => $value) {
      $numItems += $value;
    }
    return $numItems;
  }

  public function addToCart($artNo) {
    if (isset($this->cart[$artNo])) {
      $this->cart[$artNo]++;
    } else {
      $this->cart[$artNo] = 1;
    }
    return $this->numberOfItemsInCart();
  }

  public function cart() {
    return $this->cart;
  }

  public function getCartContentData() {
    $numItems = count($this->cart);
    $result = [];
  	$result["nCartItems"] = $numItems;

    if ($numItems === 0) {
      $result["head"] = null;
      $result["content"] = null;
      return $result;
    }

    $sql = "SELECT ArtikelNr, ArtikelName, Listenpreis FROM Artikel WHERE ArtikelNr in (";
    for ($i = 0; $i < $numItems; $i++) {
      if ($i === $numItems - 1) $sql .= "?);";
      else $sql .= "?,";
    }
   
    $stmt = $this->pdo->prepare($sql);
    $stmt->execute(array_keys($this->cart));

    $rows = $stmt->fetchAll();

    $result["head"] = ["Artikelnummer", "Bezeichnung", "Anzahl", "Einzelpreis", "Gesamtpreis"];
    $result["content"] = [];

    $grandTotal = 0;
    foreach ($rows as $row) {
      $item = [ $row["ArtikelNr"], $row["ArtikelName"], $this->cart[$row["ArtikelNr"]],$row["Listenpreis"], $row["Listenpreis"] * $this->cart[$row["ArtikelNr"]] ];
      $result["content"][] = $item; 
      $grandTotal += $row["Listenpreis"] * $this->cart[$row["ArtikelNr"]];
    }
    $result["content"]["GrandTotal"] = [ $grandTotal ];
  
    return $result;
  }
}
