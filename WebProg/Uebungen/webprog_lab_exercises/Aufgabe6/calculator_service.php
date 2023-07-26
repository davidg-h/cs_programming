<?php
/* Hier kommt die Implementierung Ihres Webdienstes hinein. */
header("Content-type: application/json");
$jsonReturn = [];
if (isset($_GET["va"]) && $_GET["va"] != "" && isset($_GET["vb"]) && $_GET["vb"] != "" && isset($_GET["op"])) {
  $op = $_GET["op"];

  if (is_numeric($_GET["va"]) && is_numeric($_GET["vb"])) {
    $a = $_GET["va"];
    $b = $_GET["vb"];
    $result;
    switch ($op) {
      case '+':
        $result = $a + $b;
        break;

      case '-':
        $result = $a - $b;
        break;

      case '*':
        $result = $a * $b;
        break;

      case '/':
        $result = $a / $b;
        break;
    }
    $jsonReturn["error"] = FALSE;
    $jsonReturn["result"] = $result;
    $jsonReturn["message"] = "ok";
  } else {
    $jsonReturn["error"] = TRUE;
    $jsonReturn["result"] = 0;
    $jsonReturn["message"] = "a oder b keine Zahlen!";
  }
} else {
  $jsonReturn["error"] = TRUE;
  $jsonReturn["result"] = 0;
  $jsonReturn["message"] = "Keine Variablen gesetzt!";
}

echo json_encode($jsonReturn);
