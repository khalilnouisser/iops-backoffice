<?php
header('Content-Type: application/json');
// Function to get the client IP address

function get_client_ip()
{
    $ipaddress = '';
    if (isset($_SERVER['HTTP_CLIENT_IP']))
        $ipaddress = $_SERVER['HTTP_CLIENT_IP'];
    else if (isset($_SERVER['HTTP_X_FORWARDED_FOR']))
        $ipaddress = $_SERVER['HTTP_X_FORWARDED_FOR'];
    else if (isset($_SERVER['HTTP_X_FORWARDED']))
        $ipaddress = $_SERVER['HTTP_X_FORWARDED'];
    else if (isset($_SERVER['HTTP_FORWARDED_FOR']))
        $ipaddress = $_SERVER['HTTP_FORWARDED_FOR'];
    else if (isset($_SERVER['HTTP_FORWARDED']))
        $ipaddress = $_SERVER['HTTP_FORWARDED'];
    else if (isset($_SERVER['REMOTE_ADDR']))
        $ipaddress = $_SERVER['REMOTE_ADDR'];
    else
        $ipaddress = 'UNKNOWN';
    return $ipaddress;
}

//var_dump($_POST);
if (!(isset($_POST['name']) && isset($_POST['email']) && isset($_POST['message']))) {
    echo json_encode(array("status" => 0, "error_message" => "missing fields"));
} else {
    $ip = get_client_ip();
    //ws requires 'input' field as POST parameter
    $ws_url = 'http://localhost:5000/api/contactUS/tn';
    $curl = curl_init($ws_url);
    $curl_post_data = json_encode(array(
        "emailAddress" => $_POST['email'],
        "text" => $_POST['message'],
        "name" => $_POST['name'],
        "ipAdress" => get_client_ip()

    ));

    curl_setopt($curl, CURLOPT_HEADER, false);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_HTTPHEADER,
        array("Content-type: application/json"));
    curl_setopt($curl, CURLOPT_POST, true);
    curl_setopt($curl, CURLOPT_POSTFIELDS, $curl_post_data);

    $curl_response = curl_exec($curl);

// in case of error while retrieving data
    if ($curl_response === false) {
        $info = curl_getinfo($curl);
        curl_close($curl);
        echo json_encode(array("status" => 0, "error_message" => "server-error"));
        die();
    }
    curl_close($curl);

    $decoded = json_decode($curl_response);

    if ($decoded->status) {
        echo json_encode(array("status" => 1, "success" => "true"));
    } else {
        echo json_encode(array("status" => 0, "error_message" => $decoded->extra->errorMessage));

    }
}