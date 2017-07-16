<?php
//MAX BIUO LENGTH 250
$commitee = array(
    array(
        "name" => "Adel BOUHOULA",
        "bio" => "Adel Bouhoula received in 1990 a Computer Engineering degree with Distinction from the University of
                Tunis (Tunisia). He received a Master’s degree, PhD degree with Distinction and Habilitation degree....",
        "imageURL" => "images/commitee/Adel_BOUHOULA.jpg",
        "poste" => "Chair",
        "url" => "components/bios/adel_bouhoula.html"
    ),
    array(
        "name" => "Taha BEN SALAH",
        "bio" => "Taha BEN SALAH has an engineering degree in Computer Science from ENSI (National School of Computer
                Science, Tunisia) in 2000 and a PhD degree in Telecommunications from ENIT",
        "imageURL" => "images/commitee/taha ben salah.jpg",
        "poste" => "Executive Director (Sousse, Monastir, Kairouan)",
        "url" => "components/bios/taha_ben_salah.html"
    ),
    array(
        "name" => "Atef MASMOUDI",
        "bio" => "Atef MASMOUDI was born in Sfax, Tunisia, in 1979.He received an engineering degree
                in computer science from the National School of Computer Science (ENSI), University of Mannouba, Tunisia, in July 2003, and a MSc degree in automatic",
        "imageURL" => "images/commitee/atef_masmoudi.jpg",
        "poste" => "Executive Director (Sfax, Mahdia, Sidi Bouzid, Kasserine)",
        "url" => "components/bios/atef_masmoudi.html"
    ),
    array(
        "name" => "Mohamed Abid",
        "bio" => "Mohamed ABID received his diploma of engineer in computers sciences with distinction from ENSI: National School of Computer Sciences (University of Manouba, Tunisia) in year
                2004. He then received Master Degree in Computer Science from ENSI.",
        "imageURL" => "images/commitee/MohamedABID.jpg",
        "poste" => "Executive Director (Gabes, Mednine, Gafsa)",
        "url" => "components/bios/mohamed_abid.html"
    ),
    array(
        "name" => "Aymen Sellaouti",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/aymen_sallaouti.jpg",
        "poste" => "Executive Director (Tunis)",
        "url" => null
    ),
    array(
        "name" => "Mohamed Hayouni",
        "bio" => "Received the Engineering degree in electrical engineering, option industrial computer sciences from the Higher National School of Engineers (ENSIT) of Tunis, Tunisia in 2002 and the M.S.  degree in Information Technology",
        "imageURL" => "images/commitee/Mohamed HAYOUNI.jpg",
        "poste" => "Executive Director (Kef, Jendouba, Beja, Siliana)",
        "url" => "components/bios/mohamed_hayouni.html"
    ),
    array(
        "name" => "Yemna Sayeb",
        "bio" => "Received her Master and PhD degree in Computer Science from The National School of
Computer Sciences (ENSI) in the University of Manouba.
She is currently Assistant professor at (ISAMM) and
active member in the research group at RIADI ",
        "imageURL" => "images/commitee/yemna_sayeb.jpg",
        "poste" => "Executive Director (Mannouba, Bizerte)",
        "url" => "components/bios/yemna_sayeb.html"
    ),
    array(
        "name" => "Wejdane Saied",
        "bio" => "Wejdene SAIED received in 2004 a Computer Engineering degree with distinction from (E.N.S.I – Tunisia). She received in 2007 a Master’s degree in computer science from
                (E.N.I.T – Tunisia).",
        "imageURL" => "images/commitee/photo-wejdene.png",
        "poste" => "Executive Director (Nabeul)",
        "url" => "components/bios/wejdane_said.html"
    ),
    array(
        "name" => "Mohamed Becha Kaaniche",
        "bio" => "BSc in Computer Engineering and MSc in Automatics and Signal Processing from ENIT at UTM in 2005 and 2006, respectively. 
        <br>PhD in Automatics, Signal and Image Processing from ED STIC at UNSA in 2009. ",
        "imageURL" => "images/commitee/mohamed_bacha.jpg",
        "poste" => "Scientific Committee (Chair)",
        "url" => null
    ),
    array(
        "name" => "Ahmed Bouhoula",
        "bio" => "honoré par Son Excellence Monsieur Béji Caïd ESSEBSI, Président de la République
                Tunisienne après avoir remporté sept médailles nationales et arabes en programmation informatique.",
        "imageURL" => "images/commitee/Ahmed_BOUHOULA.jpg",
        "poste" => "Scientific Committee (Deputy Chair)",
        "url" => "components/bios/ahmed_bouhoula.html"
    ),
    array(
        "name" => "Oussama Ben Alaya",
        "bio" => "I'm a UX/UI Designer and Front/Back End Developer from Mahdia, Tunisia.
                    I enjoy turning complex problems into simple, beautiful and intuitive interface designs.",
        "imageURL" => "images/commitee/BEN ALAYA Oussama.jpg",
        "poste" => "Media and Communication Chair",
        "url" => null
    ),
    array(
        "name" => "Riadh Ksantini",
        "bio" => "Lorem ipsum dolor sit amet, usu diam patrioque ea. Eu sed graece officiis definitionem, 
                    id eam atqui debitis molestie, inani semper pericula at pri. 
                    An mel minimum indoctum, persius corpora usu ad, usu tritani consulatu instructior ei.",
        "imageURL" => "images/commitee/none.jpg",
        "poste" => "Logistics Chair",
        "url" => null
    ),


)
?>
<div class="section padding-top-bottom back-white" id="commitee" xmlns:>
    <div class="container">
        <div class="twelve columns">
            <div class="title-text left">
                <h3>Commitee</h3>
            </div>
        </div>
        <?php
        foreach ($commitee as $person) :
            ?>
            <div class="three columns commitee-box" data-scroll-reveal="enter bottom move 100px over 1s after 0.3s">
                <div class="team-wrap fst">
                    <h6><?= $person['name'] ?></h6>
                    <p><?= $person['bio'] ?>
                        <?php
                        if ($person["url"]) {
                            echo '<a href="' . $person["url"] . '" target="_blank">Read More</a>';
                        }
                        ?></p>
                    <div class="poste">
                        <?= $person['poste'] ?>
                    </div>
                    <!-- <img src="<?= $person['imageURL'] ?>" alt="Some image" /> -->
                    <div class="img" style="background-image: url('<?= $person['imageURL'] ?>')" alt="Some image" ;>
                    </div>
                </div>
            </div>
            <?php
        endforeach; ?>
    </div>
</div>
