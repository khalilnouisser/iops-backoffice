<?php
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

?>
<div class="section" id="countries">
    <div id="portfolio-filter">
        <ul id="filter">
            <li><a href="#" class="current" data-filter="*" title="">all</a></li>
            <?php foreach ($flags as $continent => $flag): ?>

                <li><a href="#" data-filter=".<?= $continent ?>" title=""><?= $continent ?></a></li>

            <?php endforeach; ?>
        </ul>
    </div>

    <div id="projects-grid">
        <?php foreach ($flags as $continent => $flag)
            foreach ($flag as $countries => $country):?>

                <a href="" data-country="<?= $countries ?>" data-modal>
                    <div class="portfolio-box-1 <?= $continent ?>">
                        <div class="mask"></div>
                        <h3><span><?= $continent ?></span><br><?= $country ?></h3>
                        <img src="images/flag/<?= $countries ?>.png" alt="">
                    </div>
                </a>

            <?php endforeach; ?>


    </div>
</div>

<script>


</script>