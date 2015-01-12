<?php
//2.5 chasa
$size = $_GET["size"];
$text = $_GET["text"];
$textLength = strlen($text);
$textArr = preg_split("//", $text, -1, PREG_SPLIT_NO_EMPTY);

$dimension = (int) $size; //ceil($textLength/$size);
$spiralArray = array();
$numConcentricSquares = (int) ceil($dimension / 2);
$j;
$sideLen = $dimension;
$currNum = 0;

for ($i = 0; $i < $numConcentricSquares; $i++) {

    for ($j = 0; $j < $sideLen; $j++) {
        $spiralArray[$i][$i + $j] = $textArr[$currNum++];
    }

    for ($j = 1; $j < $sideLen; $j++) {
        $spiralArray[$i + $j][$dimension - 1 - $i] = $textArr[$currNum++];
    }

    for ($j = $sideLen - 2; $j > -1; $j--) {
        $spiralArray[$dimension - 1 - $i][$i + $j] = $textArr[$currNum++];
    }

    for ($j = $sideLen - 2; $j > 0; $j--) {
        $spiralArray[$i + $j][$i] = $textArr[$currNum++];
    }

    $sideLen -= 2;
}

$firstPart = "";
$secondPart = "";
$newTextArr = array();
for ($i = 0; $i < count($spiralArray); $i++) {
    for ($j = 0; $j < count($spiralArray[0]); $j++) {
        if(($i % 2 != 0 && $j %2 == 0) || ($i % 2 == 0 && $j %2 != 0)){
            $secondPart.=$spiralArray[$i][$j];
        }else{
            $firstPart.=$spiralArray[$i][$j];
        }
        array_push($newTextArr, $spiralArray[$i][$j]);
    }
}
$newString = $firstPart.$secondPart;
$strForCheck = preg_replace("/[\,\.\?\!\:\;\"\'\s]/", "", $newString);
$strForCheck = strtolower($strForCheck);

$revString = strrev($strForCheck);
if($strForCheck == $revString){
    echo "<div style='background-color:#4FE000'>".$newString."</div>";
 
}  else {
    echo "<div style='background-color:#E0000F'>".$newString."</div>";
}