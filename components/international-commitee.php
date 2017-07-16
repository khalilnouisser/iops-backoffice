<?php
$commitee = array(
    array(
        "name" => "Ahmed BOUHOULA",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Commitee member"
    ),
    array(
        "name" => "Adel BOUHOULA",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Adel_BOUHOULA.jpg",
        "poste" => "Commitee member"
    ),
    array(
        "name" => "Atef MASMOUDI",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/masmoudi_atef.jpg",
        "poste" => "Commitee member"
    ),
    array(
        "name" => "Oussama BEN ALAYA",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/masmoudi_atef.jpg",
        "poste" => "Commitee member"
    )

)
?>
<div class="section padding-top-bottom back-white" id="international-commitee">
    <div class="container">
        <div class="twelve columns">
            <div class="title-text left">
                <h3>Commitee</h3>
            </div>
        </div>
        <?php
        foreach ($commitee as $person) :
            ?>
            <div class="three columns commitee-box"  data-scroll-reveal="enter bottom move 100px over 1s after 0.3s">
                <div class="team-wrap fst">
                    <h6><?=$person['name'] ?></h6>
                    <p><?=$person['bio'] ?></p>
                    <div class="poste">
                        <?=$person['poste'] ?>
                    </div>
                    <!-- <img src="<?=$person['imageURL'] ?>" alt="Some image" /> -->
                    <div class="img" style="background-image: url('<?=$person['imageURL'] ?>')" alt="Some image" >
                    </div>
                </div>
            </div>
            <?php
        endforeach;        ?>
    </div>
</div>
