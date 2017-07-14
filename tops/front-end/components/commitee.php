<?php
//MAX BIUO LENGTH 250
$commitee = array(
    array(
        "name" => "Adel BOUHOULA",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Adel_BOUHOULA.jpg",
        "poste" => "Chair"
    ),
    array(
        "name" => "Taha BEN SALAH",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/taha ben salah.jpg",
        "poste" => "Executive Director (Sousse, Monastir, Kairouan)"
    ),
    array(
        "name" => "Atef MASMOUDI",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/atef_masmoudi.jpg",
        "poste" => "Executive Director (Sfax, Mahdia, Sidi Bouzid, Kasserine)"
    ),
    array(
        "name" => "Mohamed Abid",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/MohamedABID.jpg",
        "poste" => "Executive Director (Gabes, Mednine, Gafsa)"
    ),
    array(
        "name" => "Aymen Sellaouti",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/aymen_sallaouti.jpg",
        "poste" => "Executive Director (Tunis)"
    ),
    array(
        "name" => "Mohamed Hayouni",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Mohamed HAYOUNI.jpg",
        "poste" => "Executive Director (Kef, Jendouba, Beja, Siliana)"
    ),
    array(
        "name" => "Yemna Sayeb",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Executive Director (Mannouba, Bizerte)"
    ),
    array(
        "name" => "Wejdane Saied",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/photo-wejdene.png",
        "poste" => "Executive Director (Nabeul)"
    ),
    array(
        "name" => "Mohamed Becha Kaaniche",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Scientific Committee (Chair)"
    ),
    array(
        "name" => "Ahmed Bouhoula",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Scientific Committee (Deputy Chair)"
    ),
    array(
        "name" => "Oussama Ben Alaya",
        "bio" => "I'm a UX/UI Designer and Front/Back End Developer from Mahdia, Tunisia.
                    I enjoy turning complex problems into simple, beautiful and intuitive interface designs.",
        "imageURL" => "images/commitee/BEN ALAYA Oussama.jpg",
        "poste" => "Media and Communication Chair"
    ),
    array(
        "name" => "Riadh Ksantini",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Logistics Chair"
    ),


)
?>
<div class="section padding-top-bottom back-white" id="commitee">
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
