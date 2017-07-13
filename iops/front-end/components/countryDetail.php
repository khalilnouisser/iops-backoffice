<?php
$country = array(
    "countryID" => $_GET['countryID'],
    "countryFullName" => "Tunisia",
    "website" => "http://www.tops.tn",
    "description" => "lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor
                        lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor lorem ipsum dolor",
    "responsableName" => "John Doe"
);

?>
<img class="country-flag" src="images/flag/<?= $country['countryID'] ?>.png">
<div class="country-name"><?= $country['countryFullName'] ?></div>
<div class="country-description">
    <h6>Description : </h6>
    <?= $country['description'] ?>
</div>
<div class="country-commitee">
    <h6>Representative : </h6>
    <?= $country['responsableName'] ?>
</div>
<div class="country-website">

    <h6>Website : </h6>
    <a href="<?= $country['website'] ?>"><img src="images/internet_colored.png"/><br><?= str_replace('http://','',$country['website']) ?></a>
</div>

