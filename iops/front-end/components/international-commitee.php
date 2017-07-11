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
        "name" => "Ahmed BOUHOULA",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Commitee member"
    )

)
?>
<div class="section padding-top-bottom back-white" id="international-commitee">
    <div class="container">
        <div class="twelve columns">
            <div class="title-text left">
                <h3>International Commitee</h3>
            </div>
        </div>
        <?php
        foreach ($commitee as $person) :
        ?>
        <div class="three columns"  data-scroll-reveal="enter bottom move 100px over 1s after 0.3s">
            <div class="team-wrap fst">
                <h6><?=$person['name'] ?></h6>
                <p><?=$person['bio'] ?></p>
                <div class="social-team">
                    <ul class="list-social-team">
                        <li class="icon-team tipped" data-title="twitter"  data-tipper-options='{"direction":"top","follow":"true"}'>
                            <a href="#">&#xf099;</a>
                        </li>
                        <li class="icon-team tipped" data-title="github"  data-tipper-options='{"direction":"top","follow":"true"}'>
                            <a href="#">&#xf09b;</a>
                        </li>
                        <li class="icon-team tipped" data-title="pinterest"  data-tipper-options='{"direction":"top","follow":"true"}'>
                            <a href="#">&#xf231;</a>
                        </li>
                        <li class="icon-team tipped" data-title="facebook"  data-tipper-options='{"direction":"top","follow":"true"}'>
                            <a href="#">&#xf09a;</a>
                        </li>
                    </ul>
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
