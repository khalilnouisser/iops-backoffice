<?php
//ws requires 'input' field as GET parameter
$ws_url = 'http://localhost:5000/api/Continent/';
$curl = curl_init($ws_url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
$curl_response = curl_exec($curl);

// in case of error while retrieving data
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    die('error occured during curl exec. Additioanl info: ' . var_export($info));
}
curl_close($curl);

$decoded = json_decode($curl_response);
var_dump($decoded);
?>