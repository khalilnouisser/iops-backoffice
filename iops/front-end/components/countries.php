<?php

//ws requires 'input' field as GET parameter
$ws_url = 'http://localhost:5000/api/Continent';
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
        $flags = $decoded->extra->continents;
    } else {
        $error = true;
    }
}
/*
$flags = array(
    "africa" => array(
        "ci" => "Côte d'Ivoire",
        "eg" => "Egypt",
        "tn" => "Tunisia"
    ),
    "America" => array(
        "ar" => "Argentina",
        "ca" => "Canada",
        "us" => "United States of America"
    ),
    "asia" => array(
        "ae" => "United Arab Emirates",
        "cn" => "China",
        "jp" => "Japan",
        "kr" => "South Korea",
        "qa" => "Qatar"
    ),
    "europe" => array(
        "de" => "Germany",
        "fr" => "France",
        "it" => "Italy",
        "gb" => "Great Britain"
    )
);
*/
?>
<div class="section" id="countries">
    <?php if (!$error) : ?>
    <div id="portfolio-filter">
        <ul id="filter">
            <li><a href="#" class="current" data-filter="*" title="">all</a></li>
            <?php
            foreach ($flags as $continent => $flag): ?>

                <li><a href="#" data-filter=".<?= $flag->continentID ?>" title=""><?= $flag->continentID ?></a></li>

            <?php endforeach;


            ?>
        </ul>
    </div>

    <div id="projects-grid">
        <?php

        foreach ($flags as $continent => $flag)
            foreach ($flag->pays as $country):?>

                <a href="" data-country="<?= $country->countryID ?>" data-modal>
                    <div class="portfolio-box-1 <?= $flag->continentID ?>">
                        <div class="mask"></div>
                        <h3><span><?= $flag->continentID ?></span><br><?= $country->name ?></h3>
                        <img src="images/flag/<?= $country->countryID ?>.png" alt="">
                    </div>
                </a>
 e


            <?php endforeach;
        else : {
            echo "Error while retrieving continents <br>Please report this error by <a href='#contact'>contacting us.</a><br>Thank you !";
        }

        endif; ?>


    </div>
</div>

<script>


</script>