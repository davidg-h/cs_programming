<?php

function setupDB()
{
  $pdo = new PDO("sqlite:X:\\1.SchuleTHSynchro\\MinSemester4\\WebProg\\Uebungen\\ToyModels_WebShop\\MVC_Modell\\toymodels.db");

  $sql = "CREATE TABLE users (id INTEGER PRIMARY KEY, username VARCHAR(255), password VARCHAR(255), salt VARCHAR(255));";

  $result = $pdo->exec($sql);

  if ($result === false) {
    die("Oops an error occured");
  } else {
    echo "Table created successfully!";
  }
}

setupDB();
