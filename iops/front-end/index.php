<!DOCTYPE html>
<!--[if IE 8]>
<html class="no-js lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]>
<!-->
<html class="no-js" lang="en"><!--<![endif]-->

<head>

    <!-- Basic Page Needs
  ================================================== -->
    <meta charset="utf-8">
    <title>IOPS</title>
    <meta name="description" content="International Olympiad in Problem Solving">
    <meta name="author" content="">

    <!-- Mobile Specific Metas
  ================================================== -->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">


    <!-- CSS
  ================================================== -->
    <link rel="stylesheet" href="css/base.css"/>
    <link rel="stylesheet" href="css/skeleton.css"/>
    <link rel="stylesheet" href="css/layout.css"/>
    <link rel="stylesheet" href="css/color.css"/>
    <link rel="stylesheet" href="css/font-awesome.css"/>
    <link rel="stylesheet" href="css/et-line.css"/>
    <link rel="stylesheet" href="css/owl.carousel.css"/>
    <link rel="stylesheet" href="css/owl.transitions.css"/>
    <link rel="stylesheet" href="css/retina.css"/>
    <link rel="stylesheet" href="css/ionicons.min.css"/>
    <link rel="stylesheet" href="css/settings.css"/>
    <link rel="stylesheet" href="css/layers.css"/>
    <link rel="stylesheet" href="css/navigation.css"/>

    <link rel="stylesheet" href="css/vex.css" />
    <link rel="stylesheet" href="css/vex-theme-flat-attack.css" />


    <!-- Favicons
    ================================================== -->
    <link rel="shortcut icon" href="images/favicon/favicon.png">
    <link rel="apple-touch-icon" href="images/favicon/apple-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="images/favicon/apple-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="images/favicon/apple-icon-114x114.png">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="images/favicon/ms-icon-144x144.png">


    <script type="text/javascript" src="js/modernizr.custom.js"></script>


</head>
<body class="royal_preloader">

<div id="royal_preloader"></div>

<!-- MENU
================================================== -->

<nav id="menu-wrap" class="menu-back cbp-af-header">
    <div class="container">
        <div class="twelve columns">
            <div class="logo"></div>
            <ul class="slimmenu">
                <li>
                    <a href="#about">About</a>
                </li>
                <li>
                    <a href="#countries">Countries</a>
                </li>
                <li>
                    <a href="#concepts">News</a>
                </li>
                <li>
                    <a href="#concepts">Rules</a>
                </li>
                <li>
                    <a href="#concepts">Events</a>
                </li>
                <li>
                    <a href="#features">International Committee</a>
                </li>
                <li>
                    <a href="#contact-us">Contact Us</a>
                </li>
            </ul>
        </div>
    </div>
</nav>

<!-- Primary Page Layout
================================================== -->

<div class="section full-height over-hidden" id="top">
    <div class="parallax-1"></div>
    <div class="parallax-mask"></div>
    <div class="home-text">
        <div class="container fade-elements">
            <div class="twelve columns">
                <h1>International Olympiad in Problem Solving Community</h1>
                <a href="#demos" data-gal="m_PageScroll2id" data-ps2id-offset="78" class="button-effect button--moema button--text-thick button--text-upper button--size-s">Upcoming Events</a>
                <a href="#concepts" data-gal="m_PageScroll2id" data-ps2id-offset="78" class="button-effect button--moema button--text-thick button--text-upper button--size-s">Contact Us</a>
            </div>
        </div>
    </div>
    <a href="#demos" data-gal="m_PageScroll2id" data-ps2id-offset="78"><div class="link-down fade-elements"></div></a>
</div>

<div class="section back-white padding-top-bottom-small">
    <!--ABOUT SECTION-->
    <?php
    include("components/about.php");
    ?>
    <!-- END ABOUT SECTION-->

    <!--Countries SECTION-->
    <?php
    include("components/countries.php");
    ?>
    <!-- END Countries SECTION-->


    <!--Countries SECTION-->
    <?php
    include("components/news.php");
    ?>
    <!-- END Countries SECTION-->

    <!-- JAVASCRIPT
    ================================================== -->
    <script type="text/javascript" src="js/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="js/royal_preloader.min.js"></script>
    <script type="text/javascript">
        (function ($) {
            "use strict";
            //Preloader

            Royal_Preloader.config({
                mode: 'scale_text',
                text: 'IOPS',
                text_colour: '#FFFFFF',
                background: '#000000'
            });
        })(jQuery);
    </script>
    <script type="text/javascript" src="js/plugins.js"></script>
    <script type="text/javascript">
        (function ($) {
            "use strict";
            window.scrollReveal = new scrollReveal();
        })(jQuery);
    </script>

    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/masonry.js"></script>
    <script type="text/javascript" src="js/isotope.js"></script>
    <script src="js/vex.combined.min.js"></script>
    <script>vex.defaultOptions.className = 'vex-theme-flat-attack'</script>
    <!-- REVOLUTION JS FILES -->
    <script type="text/javascript" src="js/jquery.themepunch.tools.min.js"></script>
    <script type="text/javascript" src="js/jquery.themepunch.revolution.min.js"></script>
    <!-- SLIDER REVOLUTION 5.0 EXTENSIONS -->
    <script type="text/javascript" src="js/extensions/revolution.extension.actions.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.carousel.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.kenburn.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.layeranimation.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.migration.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.navigation.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.parallax.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.slideanims.min.js"></script>
    <script type="text/javascript" src="js/extensions/revolution.extension.video.min.js"></script>
    <!--script type="text/javascript" src="js/custom-home.js"></--script-->
    <!-- End Document
    ================================================== -->
</body>

<!-- Mirrored from ivang-design.com/talos/ by HTTrack Website Copier/3.x [XR&CO'2014], Sat, 08 Jul 2017 10:45:59 GMT -->
</html>