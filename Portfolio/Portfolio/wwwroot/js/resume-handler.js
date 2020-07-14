$(window).scroll(function () {
    var current = $(document).scrollTop();
    var firstP = $('#first-Page-15vh').offset().top;
    var secondP = $('#second-Page').offset().top;
    var thirdP = $('#third-Page').offset().top;

    if (!ToDisableNavigationArrows()) {
        if (current <= (firstP + 10)) {
            $('#furtherInfo').css({ display: 'block' });
        }
        else if (current > (secondP - 40) && current <= secondP + 100) {
            $('#furtherInfo').css({ display: 'block' });

        }
        else if (current > (thirdP - 40) && current <= thirdP + 100) {
            $('#furtherInfo').css({ display: 'block' });

        }
        else {
            $('#furtherInfo').css({ display: 'none' });
        }
    }
});

$('#furtherInfo').click(function () {
    var current = $(document).scrollTop();
    var firstP = $('#first-Page-15vh').offset().top;
    var secondP = $('#second-Page').offset().top;
    var thirdP = $('#third-Page').offset().top;

    if (current <= (firstP + 10)) {
        $("html, body").animate({ scrollTop: secondP + 100 }, 1000);
        $("html, body").animate({ scrollTop: secondP - 60 }, 500);
        $("html, body").animate({ scrollTop: secondP + 20 }, 400);
        $("html, body").animate({ scrollTop: secondP }, 300);
    }
    else if (current > (secondP - 40) && current <= secondP + 100) {
        $("html, body").animate({ scrollTop: thirdP + 100 }, 1000);
        $("html, body").animate({ scrollTop: thirdP - 60 }, 500);
        $("html, body").animate({ scrollTop: thirdP + 20 }, 400);
        $("html, body").animate({ scrollTop: thirdP }, 300);
    }
    else if (current > (thirdP - 40) && current <= thirdP + 100) {
        $("html, body").animate({ scrollTop: $('#forth-Page').offset().top + 100 }, 500);
    }
});