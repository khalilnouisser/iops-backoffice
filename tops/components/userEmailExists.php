<?php
header('Content-Type: application/json');
// Function to get the client IP address
include 'environment_vars.php';

//var_dump($_POST);
if (!(isset($_POST['CountryID']) && isset($_POST['EmailAdress']) && isset($_POST['Username']) )) {
    echo json_encode(array("status" => 0, "error_message" => "missing fields"));
} else {
$response=true;
//check if user exists
    $sql = "SELECT * FROM Inscriptions WHERE `Username`='" . $_POST['Username'] . "' AND `CountryID`='".$_POST['CountryID']."'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {

        $response = false;


    }
//check if email
    $sql = "SELECT * FROM Inscriptions WHERE `EmailAdress`='" . $_POST['EmailAdress'] . "' AND `CountryID`='".$_POST['CountryID']."'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {
        $response = false;


    }
    echo json_encode(array("status"=>1,"response"=>$response));
}
