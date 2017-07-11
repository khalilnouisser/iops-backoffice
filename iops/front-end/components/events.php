<?php
$events = array(
    array(
        "title" => "Event 1",
        "description" => "description event 1",
        "imageURL" => "images/events/1.jpg",
        "date" => "13.06.18"
    ),
    array(
        "title" => "Event 2",
        "description" => "description event2  ",
        "imageURL" => "images/events/2.jpg",
        "date" => "21.10.18"
    ),
    array(
        "title" => "Event 3",
        "description" => "description event 3",
        "imageURL" => "images/events/3.jpg",
        "date" => "19.05.17"
    ),
    array(
        "title" => "Event 4",
        "description" => "description event 4",
        "imageURL" => "images/events/4.jpg",
        "date" => "13.04.19"
    )
)
?>
<div id="events">
    <div class="section z-big back-black">
        <div class="container">
            <div class="twelve columns remove-bottom">
                <div class="title-text left">
                    <h3>Events</h3>
                </div>
            </div>
        </div>
    </div>


    <div>
        <div class="section padding-top-small padding-bottom-small">
            <div class="container">
                <?php
                foreach ($events as $event => $key):
                ?>
                    <?php
                    if(!$event%2 && $event>0)
                        echo '<div class="clear"></div>';
                    ?>
                <div class="six columns" data-scroll-reveal="enter bottom move 50px over 0.7s after 0.3s">
                    <div class="journal-wrap">
                        <img src="<?= $key['imageURL']?>" alt=""/>
                        <div class="journal-det">
                            <h6><?= $key['description']?> <span><?= $key['date']?></span></h6>
                            <h5><?= $key['title']?></h5>
                            <a href="#">
                                <div class="link">read more</div>
                            </a>
                        </div>
                    </div>
                </div>
                <?php
                endforeach;
                ?>





            </div>
        </div>
        <!-- Pager-->
        <!--
        <div class="section padding-bottom">
            <div class="container">
                <div class="twelve columns" data-scroll-reveal="enter bottom move 50px over 0.7s after 0.3s">
                    <nav role="navigation">
                        <ul class="cd-pagination animated-buttons custom-icons">
                            <li class="button-pag"><a href="#0"><i>prev</i></a></li>
                            <li><a href="#0">1</a></li>
                            <li><a href="#0">2</a></li>
                            <li><a class="current" href="#0">3</a></li>
                            <li><a href="#0">4</a></li>
                            <li><span>...</span></li>
                            <li><a href="#0">20</a></li>
                            <li class="button-pag"><a href="#0"><i>next</i></a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
        -->

    </div>


</div>