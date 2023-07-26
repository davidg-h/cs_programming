<?php

class ShopView
{

  private $content = null;
  private $nItems = 0;

  public function cartButton()
  {
    if ($this->content["page"] === "main") {
      $addText = $this->content["data"]["nCartItems"] > 0 ? "(" . $this->content["data"]["nCartItems"] . ")" : "";
      $result = "<button class='cartbutton' onclick='navigateToCart(true);'>
        <img src='http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/img/gift.png'>
        Warenkorb 
        $addText
      </button>";
    } else {
      $result = "<button class='cartbutton' onclick='navigateToCart(false);'>
        <img src='http://localhost:8080/Uebungen/ToyModels_WebShop/MVC_Modell/img/gift.png'>
        Zur&uuml;ck
      </button>";
    }
    echo $result;
  }

  public function createTableView($head, $content)
  {
    if ($head === null || $content === null) {
      return "<h4 style='color:red;>An unknown error ocurred!</h4>";
    }
    $result = "";
    // Table head
    $result .= "<table><thead><tr>";
    foreach ($head as $item) {
      $result .= "<th>" . $item . "</th>";
    }
    $result .= "</tr></thead>";

    // Contents
    foreach ($content as $item) {
      $result .= "<tr>";
      foreach ($item as $elem) {
        $result .= "<td>" . $elem . "</td>";
      }
      $result .= "</tr>";
    }

    $result .= "</table>";

    return $result;
  }

  public function mainViewHeader()
  {
    if ($this->content["page"] === "cart") {
      $result = "<section>
        <h1>Warenkorb</h1>
      </section>";
    } else {
      $result = "<section>
        <h1>Willkommen im Toy-Models Online-Shop</h1>
        <h4>Viel Spass bei Ihrem Einkauf!</h4>
      </section>";
    }
    return $result;
  }

  public function mainViewContent()
  {
    $result = "<section id='productsection'>";
    $result .= $this->createTableView($this->content["data"]["head"], $this->content["data"]["content"]);
    $result .= "</section>";
    return $result;
  }

  public function display($content)
  {
    //if ($content["page"] === "main") {
    $this->content = $content;
    include("views/shop_main.view.php");
    //}
  }
}
