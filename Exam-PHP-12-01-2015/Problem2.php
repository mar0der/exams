<?php
//1 chas i 5 min
$string = $_GET["numbersString"];
preg_match_all("/([A-Z][A-Za-z]*)(?:[^+]*?)([+]?\s*(?=\d)[\d()\/\.\-\s]{2,}).*?/", $string, $pairs, PREG_SET_ORDER);

$output = array();
foreach ($pairs as $pair) {

    $name = trim($pair[1]);
    if(strlen($name) == 0){
        continue;
    }
    $number = trim($pair[2]);
    if (preg_match("/\d{2,}/", $number, $outputNumber) == 0) {
        continue;
    }else{
        $number = preg_replace("/[()\/\.\-\s]/", "", $number);
    }
    $newPair = array("name" => $name, "number" => $number);
    array_push($output, $newPair);
}
//output
if (count($output) == 0) {
    echo "<p>No matches!</p>";
    die;
}
echo "<ol>";
foreach ($output as $pair) {
    echo "<li><b>"
    . htmlentities($pair["name"])
    . ":</b> "
    . htmlentities($pair["number"])
    . "</li>";
}
echo "</ol>";
?>

