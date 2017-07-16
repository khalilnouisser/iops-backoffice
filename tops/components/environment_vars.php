<?php


$connection = mysqli_connect("localhost","root","","IOPS") or die("Error " . mysqli_error($connection));
$serverURL="http://localhost/infoca/";
$serverURLFinal='http://iops.online/';
mysqli_query ($connection,"set character_set_results='utf8_general_ci'");
?>