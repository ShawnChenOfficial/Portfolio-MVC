$(window).scroll(function () {
    var current = $(document).scrollTop();
    var firstP = $('#first-Page-20vh').offset().top;
    var secondP = $('#second-Page').offset().top;

    if (!ToDisableNavigationArrows()) {
        if (current <= (firstP + 10)) {
            $('#furtherInfo').css({ display: 'block' });
        }
        else if (current > (secondP - 40) && current <= secondP + 100) {
            $('#furtherInfo').css({ display: 'block' });
        }
        else {
            $('#furtherInfo').css({ display: 'none' });
        }
    }
});

$('#furtherInfo').on('click', function () {
    var current = $(document).scrollTop();
    var firstP = $('#first-Page-20vh').offset().top;
    var secondP = $('#second-Page').offset().top;

    if (current <= (firstP + 10)) {
        $("html, body").animate({ scrollTop: secondP + 100 }, 1000);
        $("html, body").animate({ scrollTop: secondP - 60 }, 500);
        $("html, body").animate({ scrollTop: secondP + 20 }, 400);
        $("html, body").animate({ scrollTop: secondP }, 300);
    }
    else if (current > (secondP - 40) && current <= secondP + 100) {
        $("html, body").animate({ scrollTop: $('#third-Page').offset().top + 100 }, 500);
    }
});

