<?php
header('Access-Control-Allow-Origin: *');

if(!isset($_GET['secret']))
{
    echo json_encode(array('status'=>0,'error'=>'no hash was provided'));
    die();
}

//ws requires 'input' field as POST parameter
$ws_url = 'https://www.google.com/recaptcha/api/siteverify';

$curl = curl_init($ws_url);
$curl_post_data = array(
    'secret' => '6LdK3ygUAAAAAA2Hhe5MN4lo8rW1rfxesVhH8Nyp',
    'response' => $_GET['secret']
);

curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
curl_setopt($curl, CURLOPT_POST, true);
curl_setopt($curl, CURLOPT_POSTFIELDS, $curl_post_data);
curl_setopt($curl,CURLOPT_SSL_VERIFYPEER, false);
$curl_response = curl_exec($curl);

// in case of error while retrieving data
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    die('error occured during curl exec. Additioanl info: ' . var_export($info));
}
curl_close($curl);

$decoded = json_decode($curl_response);

if($decoded->success=='true')
{
    echo json_encode(array('status'=>1, 'message'=>'success'));
}
else
{
    echo json_encode(array('status'=>0, 'errors'=>$decoded->{'error-codes'}));
}
?>