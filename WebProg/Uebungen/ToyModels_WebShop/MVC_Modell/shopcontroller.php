<?php

class ShopController
{
  private $view = null;
  private $model = null;

  public function __construct($view, $model)
  {
    $this->view = $view;
    $this->model = $model;
  }

  public function displayPage($slug, $param)
  {
    $content = [];

    if ($slug == null && !isset($param["artNo"])) {
      $content["page"] = "main";

      $filter = "";
      if (isset($param["searchbar"]))
        $filter = $param["searchbar"];

      $content["data"] = $this->model->getMainContentData($filter);
      $this->view->display($content);
    } else if ($slug === "/cart") {
      $content["page"] = "cart";
      $content["data"] = $this->model->getCartContentData();
      $this->view->display($content);
    } else if (isset($param["artNo"])) {
      $this->model->addToCart($param["artNo"]);
      header("Location: http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/");
    }
  }
}
