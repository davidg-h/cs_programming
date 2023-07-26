<?php
  error_reporting(E_ALL);
  include_once("shopengine.php");
  include_once("shopcontroller.php");
  
  session_start( ["cookie_lifetime" => 60 ]);

  $model = new ShopEngine();
  
  $controller = new ShopController($model);

  $slug = isset($_SERVER['PATH_INFO']) ? $_SERVER['PATH_INFO']:null;
  $controller->runService($slug, $_GET); 

