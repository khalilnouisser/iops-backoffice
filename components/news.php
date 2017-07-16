<?php

//ws requires 'input' field as GET parameter
$ws_url = 'http://localhost:5000/api/News';
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
        $news = $decoded->extra->news;
    } else {
        $error = true;

    }
}
/*
$news = array(
    array(
        "title" => "11 Robots That Are Going to Steal Your Jobs",
        "imgURL" => "https://www.geek.com/wp-content/uploads/2017/07/lego-628572_1920-e1499623196508-625x352.jpg",
        "text" => "Thing is, whatever your job is, sooner or later, you’re gonna lose it. <br>
                And the No. 1 reason? Probably Linda narcing you out to the boss, honestly. But a close No.<br>
                2? That’d be the fact that some stupid, clanking robo-jerk is inevitably going to come in and snag your job from me."
    ),
    array(
        "title" => "These Elf Earphones Can Be Totally Convincing",
        "imgURL" => "https://www.geek.com/wp-content/uploads/2017/07/elphones1-625x352.png",
        "text" => "hanko’s Elf Earphones feature in-ear earbuds with flesh-colored elf ears that look just 
        like the elfin ears you see in movies, TV, anime, and manga. You need to attach the plastic ear piece to your ear, 
        and it curves around the tip of your own. Then you can push the earbud pieces into your ear and start listening to your tunes.<br>
        If you’ve got long hair, just pull over the longer pieces to hide the earbud and wire part. It’s pretty much guaranteed someone willdo a 
        double take when they walk by and see those adorable pointed ear sticking out the side of your head."
    ),
    array(
        "title" => "Elon Musk Says Model 3s Will Start Arriving Today",
        "imgURL" => "https://www.geek.com/wp-content/uploads/2017/07/tesla-625x352.png",
        "text" => "Elon Musk is a weird guy. He spends lavishly on weird things, and he’s known for his starry-eyed, 
        pie-in-the-sky start-ups. He also bucks standard CEO operating procedure and just announces random (and major) things right on his twitter.<br> 
        Though, fair warning, you may also see some weirdly obsessive tweets about flooring. 
        In any case, Musk said that the Model had passed “all regulatory requirements for production two weeks ahead of schedule,” 
        adding that the very batch of cars would be delivered Friday.
        <br>
        That’s pretty huge for a few reasons, too. For one, Tesla’s got a lot riding on the car. 
        Up until now, all of Tesla’s cars have targeted the upper classes.
        Whether it’s the Tesla Roadster — a modified Lotus Elise reborn with an electric heart — or the exceptionally well-received Model S, 
        Teslas are definitely forward-thinking status symbols.
        The Model 3 is hoping to change that. At $35,000, the car is still expensive, 
        but it’s also within reach for many middle-class American families. 
        If Tesla can maintain its same exception safety and quality standards, 
        and deliver cars that are a bit more in line with the needs of the mass market, 
        Tesla could be the US’ biggest automotive success story in decades. But again, there’s a lot of ifs there."
    ),
    array(
        "title" => "SpaceX Completes Another Successful Launch",
        "imgURL" => "https://www.geek.com/wp-content/uploads/2017/07/spacex-625x352.png",
        "text" => "On July 5, SpaceX completed the launch of its latest Falcon 9 rocket. 
        It was carrying a communications satellite — the Intelsat 35e — to a geostationary orbit. 
        As always, SpaceX live-tweeted and streamed the launch, and it was textbook."
    ),
    array(
        "title" => "The Future of VR Might Have More in Common with Immersive Theatre than Video Games",
        "imgURL" => "https://www.geek.com/wp-content/uploads/2017/06/699987452-625x352.png",
        "text" => "Gaming seems like the most natural fit for virtual reality. 
        After all, it was probably most people’s first experience with the technology, 
        especially if their local mall in the early ’90s had a Dactyl Nightmare machine. 
        And since modern VR systems are so expensive, (and require a decently powerful gaming PC to work), 
        it makes sense to market them to gamers. 
        After all, they’ll most likely already own hardware that can run VR, and they’re used to spending entire paychecks on cool electronics."
    )
);*/
?>
<div class="section back-white" id="news">

    <div class="section z-big">
        <div class="container">
            <div class="twelve columns remove-bottom">
                <div class="title-text left">
                    <h3>Latest News</h3>
                </div>
            </div>
        </div>
    </div>

    <?php
    if(!$error):
        ?>
    <div class="news-carousel-wrap">

        <div id="sync1" class="owl-carousel">


            <?php

            foreach ($news as $new):
                ?>

                <div class="item" style="background-image:url('images/news/<?= $new->photoURL ?>');">
                    <div class="news-mask"></div>
                    <div class="news-text">
                        <div class="container ">
                            <div class="twelve columns">
                                <h1><?= $new->title ?></h1>
                                <p>
                                    <?= $new->text ?>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <?php
            endforeach;

            ?>

        </div>

        <div id="sync2" class="owl-carousel ">
            <?php

            foreach ($news as $new):
                ?>
                <div class="item">
                </div>
                <?php
            endforeach;

            ?>

        </div>
    </div>
        <?php
    else:
    {
        echo "Error while retrieving News <br>Please report this error by <a href='#contact'>contacting us.</a><br>Thank you !";
    }
    endif;
    ?>
</div>