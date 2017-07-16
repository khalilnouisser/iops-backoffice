(function ($) {
    "use strict";


    //Navigation

    $('ul.slimmenu').on('click', function () {
        var width = $(window).width();
        if ((width <= 1200)) {
            $(this).slideToggle();
        }
    });
    $('ul.slimmenu').slimmenu(
        {
            resizeWidth: '1200',
            collapserTitle: '',
            easingEffect: 'easeInOutQuint',
            animSpeed: 'medium',
            indentChildren: true,
            childrenIndenter: '&raquo;'
        });


    //Home text fade on scroll

    $(window).scroll(function () {
        var $Fade = $('.fade-elements');
        //Get scroll position of window 
        var windowScroll = $(this).scrollTop();
        //Slow scroll and fade it out 
        $Fade.css({
            'margin-top': -(windowScroll / 0) + "px",
            'opacity': 1 - (windowScroll / 400)
        });
    });

    /* Scroll Too */

    $(window).load(function () {
        "use strict";

        /* Page Scroll to id fn call */
        $("ul.slimmenu li a,a[href='#top'],a[data-gal='m_PageScroll2id']").mPageScroll2id({
            highlightSelector: "ul.slimmenu li a",
            offset: 78,
            scrollSpeed: 800,
            scrollEasing: "easeInOutCubic"
        });

        /* demo functions */
        $("a[rel='next']").click(function (e) {
            e.preventDefault();
            var to = $(this).parent().parent("section").next().attr("id");
            $.mPageScroll2id("scrollTo", to);
        });

    });


    $(document).ready(function () {

        //Tooltip

        $(".tipped").tipper();

        /* Portfolio Sorting */

        //Full Accordion

        $(".accordion").smk_Accordion({
            closeAble: true
        });

        //country

        $('a[data-modal]').click(function (event) {
            $(this).attr('href', 'components/countryDetail.php?countryID=' + $(this).attr('data-country'));
            $(this).modal();
            $(this).attr('href', '');
            return false;
        });

        /********** CONTACTING VALIDATION ****************/
        $('#send').click(function (event) {
            var name = $('#name-contact').val();
            var email = $('#email-contact').val();
            var message = $('#message-contact').val();
            var error_code = verifyContact(name,email,message);
            var ajaxError = false;
            $.ajaxSetup({
                error: function (xhr, status, error) {
                    //alert("An AJAX error occured: " + status + "\nError: " + error);
                    ajaxError = true;
                }
            });
            if(!error_code){
                $('.form-blocker').fadeIn(500);
                $.post('components/sendContact.php' ,{'email':email,'name':name,'message':message}, function (data, status) {
                    if (!ajaxError) {
                        if (data.status) {
                            $('.form-blocker').fadeOut(500);
                            swal({
                                title: 'Success',
                                text: 'Thank you for your message !',
                                type: 'success',
                                confirmButtonText: 'Cool'
                            })
                            $('#name-contact').val("");
                            $('#email-contact').val("");
                            $('#message-contact').val("");
                        }
                        else {
                            $('.form-blocker').fadeOut(500);
                            swal({
                                title: 'Error!',
                                text: data.error_message,
                                type: 'error',
                                confirmButtonText: 'Cool'
                            })
                        }
                    }
                    else
                    {
                        $('.form-blocker').fadeOut(500);
                        swal({
                            title: 'Error!',
                            text: 'Sorry we couldn\'t send your message <br>Server error',
                            type: 'error',
                            confirmButtonText: 'Cool'
                        })
                    }

                });
            }

            event.preventDefault();
        });
        function verifyContact(name,email,message)
        {

            var err_name = $('#err-name-contact');
            var err_email = $('#err-email-contact');
            var err_message = $('#err-message-contact');
            var error_code=0;
            if (!name) {
                error_code++;
                err_name.show();
            }else {
                err_name.hide();
            }
            if (!email||!isValidEmailAddress(email)) {
                error_code++;
                err_email.show();
            }else {
                err_email.hide();
            }
            if (!message || message.length<10) {
                error_code++;
                err_message.show();
            }else {
                err_message.hide();
            }

            return error_code;
        }
        function isValidEmailAddress(emailAddress) {
            var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
            return pattern.test(emailAddress);
        };
        (function ($) {


            var container = $('#projects-grid');


            function getNumbColumns() {
                var winWidth = $(window).width(),
                    columnNumb = 1;


                if (winWidth > 1500) {
                    columnNumb = 4;
                } else if (winWidth > 1200) {
                    columnNumb = 3;
                } else if (winWidth > 900) {
                    columnNumb = 2;
                } else if (winWidth > 600) {
                    columnNumb = 2;
                } else if (winWidth > 300) {
                    columnNumb = 1;
                }

                return columnNumb;
            }


            function setColumnWidth() {
                var winWidth = $(window).width(),
                    columnNumb = getNumbColumns(),
                    postWidth = Math.floor(winWidth / columnNumb);

            }

            $('#portfolio-filter #filter a').click(function () {
                var selector = $(this).attr('data-filter');

                $(this).parent().parent().find('a').removeClass('current');
                $(this).addClass('current');

                container.isotope({
                    filter: selector
                });

                setTimeout(function () {
                    reArrangeProjects();
                }, 300);


                return false;
            });

            function reArrangeProjects() {
                setColumnWidth();
                try {
                    container.isotope('reLayout');
                }
                catch (err) {

                }

            }


            container.imagesLoaded(function () {
                setColumnWidth();


                container.isotope({
                    itemSelector: '.portfolio-box-1',
                    layoutMode: 'masonry',
                    resizable: false
                });
            });


            $(window).on('resize', function () {
                reArrangeProjects();

            });
            /*
             $(window).on('scroll', function () {
             reArrangeProjects();

             } );*/


        })(jQuery);

        //Parallax

        $('.parallax-1').parallax("50%", 0.4);
        $('.parallax-mask').parallax("50%", 0.2);
        $('.parallax-2').parallax("50%", 0.4);


    });


    //Home Carousel

    var sync1 = $("#sync1");
    var sync2 = $("#sync2");

    sync1.owlCarousel({
        singleItem: true,
        autoPlay: 5000,
        transitionStyle: "fade",
        autoHeight: false,
        slideSpeed: 200,
        navigation: false,
        pagination: false,
        afterAction: syncPosition,
        responsiveRefreshRate: 200
    });


    sync2.owlCarousel({
        items: 3,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3],
        itemsTablet: [768, 3],
        itemsMobile: [479, 3],
        pagination: false,
        responsiveRefreshRate: 100,
        afterInit: function (el) {
            el.find(".owl-item").eq(0).addClass("synced");
        }
    });

    function syncPosition(el) {
        var current = this.currentItem;
        $("#sync2")
            .find(".owl-item")
            .removeClass("synced")
            .eq(current)
            .addClass("synced")
        if ($("#sync2").data("owlCarousel") !== undefined) {
            center(current)
        }
    }

    $("#sync2").on("click", ".owl-item", function (e) {
        e.preventDefault();
        var number = $(this).data("owlItem");
        sync1.trigger("owl.goTo", number);
    });

    function center(number) {
        var sync2visible = sync2.data("owlCarousel").owl.visibleItems;
        var num = number;
        var found = false;
        for (var i in sync2visible) {
            if (num === sync2visible[i]) {
                var found = true;
            }
        }

        if (found === false) {
            if (num > sync2visible[sync2visible.length - 1]) {
                sync2.trigger("owl.goTo", num - sync2visible.length + 2)
            } else {
                if (num - 1 === -1) {
                    num = 0;
                }
                sync2.trigger("owl.goTo", num);
            }
        } else if (num === sync2visible[sync2visible.length - 1]) {
            sync2.trigger("owl.goTo", sync2visible[1])
        } else if (num === sync2visible[0]) {
            sync2.trigger("owl.goTo", num - 1)
        }

    }

})(jQuery);




















 
 
 
 
 
 
 
 
 





	