<?php
error_reporting(E_ALL);
include_once("shopengine.php");
session_start(["cookie_lifetime" => 60]);

$se = new ShopEngine();
?>
<!doctype html>
<html>

<head>
  <meta charset="utf-8">
  <title>Toymodels Online-Shop</title>

  <link rel="stylesheet" href="css/toymodels.css" type="text/css">
  <script>
    function navigateBack() {
      document.location.assign("http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/");
    }
  </script>
</head>

<body>
  <header>
    <!-- Header mit Logo, Titel, Searchbar & Login  -->
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
      <button class="cartbutton" onclick="navigateBack();">
        <img src="img/gift.png">
        Zur&uuml;ck
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
          <p id="register"><a href="register.php">Keine Zugangsdaten? Hier registrieren!</a></p>
        </div>
      </div>
    </section>
  </header>

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
      <h1>Warenkorb</h1>
    </section>
    <section id="productsection">
      <?php $se->getCartContentData(); ?>
    </section>

  </main>

  <footer>
    <p>Copyright &copy; Toy-Models GmbH</p>
  </footer>
</body>

</html>