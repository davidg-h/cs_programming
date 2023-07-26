<?php
error_reporting(E_ALL);

// php with javascript code
$basePageStart = <<<PAGESTART
<!doctype html>
<html>
<head>
  <meta charset="utf-8">
  <title>Toymodels Online-Shop</title>

  <link rel="stylesheet" href="css/toymodels.css" type="text/css">
  <script>
    function navigateToCart() {
      document.location.assign("cart.php");
    }

    function setupRegistrationForm() {
      let main = document.getElementsByTagName("main")[0];

      let f  = document.createElement("FORM");
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

      input = document.createElement("input");
      input.setAttribute("type", "submit");
      f.appendChild(input);

      f.id = "toymodels-form";
      f.setAttribute("action", "index.php/register");
      main.replaceChildren(f);
    }
  </script>
</head>

<body>
PAGESTART;
