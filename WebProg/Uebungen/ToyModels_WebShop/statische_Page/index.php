<?php
error_reporting(E_ALL);

// session damit die daten im warenkorb gespeichert werden und benutzer unterschieden werden können -> session immer am anfang starten
session_start(["cookie_lifetime" => 30]);

include_once('shopengine.php');
$se = new ShopEngine();

// prüft ob gesetzt ist
if (isset($_GET["artikelNummer"])) {
  $se->addToCart($_GET["artikelNummer"]);
  // redirect damit die get attribute nicht mehr in der Url stehen; vor header darf keine ausgabe stehen
  // $_SERVER["PHP_SELF"] zeig auf die datei die den Befehl aufruft, also index.php
  header("Location: " . $_SERVER["PHP_SELF"]);
}
// $se->dumpCart();

// $_SERVER["PATH_INFO"] the part after the .php
if (isset($_SERVER["PATH_INFO"])) {
  switch ($_SERVER["PATH_INFO"]) {
    case "/register":
      echo "Muss Registrierung verarbeiten...";
      break;
    default:
      header("Location: http://localhost/Uebungen/ToyModels_WebShop/");
      break;
  }
} else {
  $se->createArticlePage();
}
