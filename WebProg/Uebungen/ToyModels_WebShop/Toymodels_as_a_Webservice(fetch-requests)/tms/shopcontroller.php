<?php

class ShopController {
  private $model = null;

  public function __construct($model) {
    $this->model = $model;
  }

  public function runService($slug, $param) {
    header("Content-type: application/json");
    $content = [];

    if ($slug == null && empty($param)) {
      $content["page"] = "main";
      
      $filter = "";
      if (isset($param["searchbar"]))
        $filter = $param["searchbar"];

      $content["data"] = $this->model->getMainContentData($filter);
      $content["result"] = true;   
    } else if ($slug === "/cart") {
      $content["page"] = "cart";
      $content["data"] = $this->model->getCartContentData();
      $content["result"] = true;
      
    } else if (isset($param["method"]) && $param["method"] === "addToCart" && isset($param["artNo"])) {
      $content["page"] = "addToCart";
      $content["data"]["nCartItems"] = $this->model->addToCart($param["artNo"]);
      $content["result"] = true;
    } else {
      $content["page"] = "none";
      $content["data"] = "Invalid method";
      $content["result"] = false;
    }
    echo json_encode($content);
  }
}