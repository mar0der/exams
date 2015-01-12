<?php
//50 min
//input
$list = $_GET["list"];
$minSeats = (int) $_GET["minSeats"];
$maxSeats = (int) $_GET["maxSeats"];
$filter = $_GET["filter"];
$order = $_GET["order"];
$genres = array("commedy", "drama", "thriller", "horror", "fantasy", "adventure", "action");
preg_match_all("/([^(]+)\(([^)]+)\)\s*-([^\/]+)\/\s*(\d+)/", $list, $movies, PREG_SET_ORDER);
$list = preg_split('/[\r\n]+/', $list, -1, PREG_SPLIT_NO_EMPTY);
$output = array();

foreach($movies as $movie){
    $name = trim($movie[1]);
    $genre = trim($movie[2]);
    $stars = trim($movie[3]);
    $stars = preg_split("/, /", $stars, -1, PREG_SPLIT_NO_EMPTY);
    $stars = array_map("htmlentities", $stars);
    $seats = (int) trim($movie[4]);                     
    if(($seats >= $minSeats && $seats <= $maxSeats) && ($genre == $filter || $filter == 'all')){
        $movieArray = array(
            "name" => htmlentities($name),
            "stars" => $stars,
            "seats" => $seats
        );
        array_push($output, $movieArray);
    }
}
// sorting and output
if ($order == "ascending") {
    $order = SORT_ASC;
} else {
    $order = SORT_DESC;
}
$output = array_msort($output, array('name' => $order, 'seats' => SORT_ASC));

foreach($output as $movie){
    echo "<div class=\"screening\"><h2>"
    .$movie["name"]
    ."</h2><ul>";
    foreach($movie["stars"] as $star){
        echo "<li class=\"star\">".$star."</li>";
    }
    echo "</ul><span class=\"seatsFilled\">".$movie["seats"]." seats filled</span></div>";
}

function array_msort($array, $cols) {
    $colarr = array();
    foreach ($cols as $col => $order) {
        $colarr[$col] = array();
        foreach ($array as $k => $row) {
            $colarr[$col]['_' . $k] = strtolower($row[$col]);
        }
    }
    $eval = 'array_multisort(';
    foreach ($cols as $col => $order) {
        $eval .= '$colarr[\'' . $col . '\'],' . $order . ',';
    }
    $eval = substr($eval, 0, -1) . ');';
    eval($eval);
    $ret = array();
    foreach ($colarr as $col => $arr) {
        foreach ($arr as $k => $v) {
            $k = substr($k, 1);
            if (!isset($ret[$k]))
                $ret[$k] = $array[$k];
            $ret[$k][$col] = $array[$k][$col];
        }
    }
    return $ret;
}
?>
