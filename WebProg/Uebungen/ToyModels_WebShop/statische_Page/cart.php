<?php
error_reporting(E_ALL);
session_start(["cookie_lifetime" => 30]);

include_once('shopengine.php');

$se = new ShopEngine();
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="stylesheet" href="css/toymodels.css" type="text/css">

    <title>Warenkorb</title>
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
            <a href="index.php"><button class="cartbutton"><img src="img/gift.png">
                    Zur&uuml;ck</button></a>
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
            <h4>
                <?php echo "Individuelle Artikel: " . ($se->noOfIndividualItemsInCart() > 0 ? $se->noOfIndividualItemsInCart() : '') . "<br/>";
                echo "Gesamtanzahl Artikel: " . ($se->noOfItemsInCart() > 0 ? $se->noOfItemsInCart() : '');
                ?>
            </h4>
        </section>
        <section id="productsection">
            <?php $se->generateCart(); ?>
        </section>
    </main>

    <footer>
        <p>Copyright &copy; Toy-Models GmbH</p>
    </footer>
</body>

</html>