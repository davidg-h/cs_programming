<?php
  error_reporting(E_ALL);
  include_once("shopengine.php");
  include_once("shopcontroller.php");
  include_once("shopview.php");
  
  session_start( ["cookie_lifetime" => 60 ]);

  $model = new ShopEngine();
  $view = new ShopView();

  $controller = new ShopController($view, $model);

  $slug = isset($_SERVER['PATH_INFO']) ? $_SERVER['PATH_INFO']:null;
  $controller->displayPage($slug, $_GET); 

