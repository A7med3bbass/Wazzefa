
$(function () {

    'use strict';

    $('.customer-logos').slick({
        slidesToShow: 6,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1500,
        arrows: false,
        dots: false,
        pauseOnHover: false,
        responsive: [{
            breakpoint: 768,
            settings: {
                slidesToShow: 4
            }
        }, {
            breakpoint: 520,
            settings: {
                slidesToShow: 3
            }
        }]
    });

    $('.SearchByCat .Box img').addClass('.thumbnail');
    $('time.timeago').timeago();
    $('.Header-Container,.OverLay').height($(window).height());
    $('.Header .arrow i').click(function () {
        $('html,body').animate({
            scrollTop: $('.feat').offset().top
        }, 1000);
    });
});