<!doctype html>
<html>

<head>
  <meta charset='utf-8'>
  <title>Toymodels Online-Shop</title>
  <link rel='stylesheet' href='http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/css/toymodels.css' type='text/css'>
  <script>
    function navigateToCart(toCart) {
      // window.open("http://localhost/toymodels/cart.php", "_self");
      if (toCart)
        document.location.assign("http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/index.php/cart");
      else
        document.location.assign("http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/");
    }

    function createRegistrationForm() {
      let main = document.getElementsByTagName("main")[0];

      let f = document.createElement("FORM");
      let label = document.createElement("LABEL");
      let input = document.createElement("input");
      label.textContent = "Benutzername";
      input.setAttribute("name", "benutzername");
      input.setAttribute("placeholder", "Benutzername");
      f.appendChild(label);
      f.appendChild(input);

      label = document.createElement("LABEL");
      input = document.createElement("input");
      label.textContent = "eMail Adresse";
      input.setAttribute("name", "mail");
      input.setAttribute("placeholder", "eMail-Adresse");
      input.setAttribute("type", "email");
      f.appendChild(label);
      f.appendChild(input);

      label = document.createElement("LABEL");
      input = document.createElement("input");
      label.textContent = "Passwort";
      input.setAttribute("name", "password");
      input.setAttribute("placeholder", "Passwort");
      input.setAttribute("type", "password");
      f.appendChild(label);
      f.appendChild(input);

      input = document.createElement("button");
      input.setAttribute("type", "submit");
      input.textContent = "Jetzt registrieren!";
      f.appendChild(input);

      f.id = "toymodels-form";
      f.setAttribute("action", "http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/index.php/register");
      main.replaceChildren(f);
    }
  </script>
</head>

<body>
  <header>
    <!-- Header mit Logo, Titel, Searchbar & Login  -->
    <section id="logosection">
      <img src="http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/img/toymodels.png">
      <h1>Toy-Models<br>Online-Shop</h1>
    </section>
    <section id="searchbarsection">
      <form action="http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/index.php">
        <input id="searchbar" name="searchbar">
        <button type="submit" id="searchbutton"><img src="http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/img/search.png"></button>
      </form>
    </section>
    <section id="usersection">
      <?php echo $this->cartButton(); ?>
      <div id="userlogin">
        <button class="cartbutton"><img src="http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/img/ghost.png">Login</button>
        <div class="loginbox">
          <form action="login.php" method="POST">
            <label for="username">Benutzername</label>
            <input id="username" name="username">
            <label for="password">Password</label>
            <input id="password" name="password" type="password">
            <button type="submit">Einloggen</button>
          </form>
          <p id="register"><span style="color:blue; text-decoration: underline;cursor: pointer;" onclick="createRegistrationForm();">Keine Zugangsdaten? Hier registrieren!</span></p>
        </div>
      </div>
    </section>
  </header>

  <main>
    <?php
    echo $this->mainViewHeader();
    echo $this->mainViewContent();
    ?>
  </main>
  <footer>
    <p>Copyright &copy; Toy-Models GmbH</p>
  </footer>
</body>

</html>