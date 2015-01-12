<?php
$list = $_GET["list"];
$curDate = trim($_GET["currDate"]);
$curDate = date_create($curDate, timezone_open("Europe/Sofia"));
$list = preg_split("/\r?\n/", $list, -1, PREG_SPLIT_NO_EMPTY);
$list = array_map("trim", $list);
$validDates = array();
foreach ($list as $date) {

    $tempDate = date_create($date, timezone_open("Europe/Sofia"));
    if ($tempDate == false) {
        continue;
    }
    if (isset($validDates[date_format($tempDate, "Y-m-d")])) {
        $validDates[date_format($tempDate, "Y-m-d")]["count"] = (int) $validDates[date_format($tempDate, "Y-m-d")]["count"] + 1;
    }else{
    $validDates[date_format($tempDate, "Y-m-d")] = array("obj" => $tempDate, "count" => 0);
    }
}
ksort($validDates);
//output
echo "<ul>";
foreach ($validDates as $k => $date) {
    //v((int) $date["count"]);
    if ($date["obj"] < $curDate) {
        
        if ((int) $date["count"] > 0) {
            for ($i = 0; $i <= $date["count"]; $i++) {
                echo "<li><em>" . date_format($date["obj"], "d/m/Y") . "</em></li>";
            }
        } else {
            echo "<li><em>" . date_format($date["obj"], "d/m/Y") . "</em></li>";
        }
    } else {
        if ((int) $date["count"] > 0) {
            for ($i = 0; $i <= $date["count"]; $i++) {
                echo "<li>" . date_format($date["obj"], "d/m/Y") . "</li>";
            }
        } else {
            echo "<li>" . date_format($date["obj"], "d/m/Y") . "</li>";
        }
    }
}
echo "</ul>";
?>
