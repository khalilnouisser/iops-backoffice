<?php
if(isset($_GET['countryID'])):
//ws requires 'input' field as GET parameter
$ws_url = 'http://localhost:5000/api/Country/'.$_GET['countryID'];
$curl = curl_init($ws_url);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
$curl_response = curl_exec($curl);
$error = false;
// in case of error while retrieving data
if ($curl_response === false) {
    $info = curl_getinfo($curl);
    curl_close($curl);
    $error = true;
}
if (!$error) {

    curl_close($curl);

    $decoded = json_decode($curl_response);

    if ($decoded->status) {
        $country = $decoded->extra->pays;
    } else {
        $error = true;
    }
}
/*
$country = array(
    "countryID" => $_GET['countryID'],
    "countryFullName" => "Tunisia",
    "website" => "http://www.tops.tn",
    "description" => "lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor
                        lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor",
    "responsableName" => "John Doe"
);*/
if(!$error):
?>
<img class="country-flag" src="images/flag/<?= $country->countryID ?>.png">
<div class="country-name"><?= $country->name ?></div>
<div class="country-description">
    <h6>Description : </h6>
    <?= $country->description ?>
</div>
<div class="country-commitee">
    <h6>Representative : </h6>
    <?= $country->responsableName ?>
</div>
<div class="country-website">

    <h6>Website : </h6>
    <a href="<?= $country->siteURL ?>"><img src="images/internet_colored.png"/><br><?= str_replace('http://','',$country->siteURL) ?></a>
</div>

<?php
else:{echo "error, Couldn't find this country";}
endif;
else:{echo "error, Couldn't find this country";}
endif;
?>