$("#Top").click(function () {
    $("html, body").animate({ scrollTop: 0 }, 1000);
});

$(window).on('load', UpDownArrowsSwitcher());
$(window).resize(function () {
    UpDownArrowsSwitcher();
});

function UpDownArrowsSwitcher() {
    if (ToDisableNavigationArrows()) {
        $('#Top').css({ display: 'none' });
        $('#furtherInfo').css({ display: 'none' });
    }
    else {
        $('#Top').css({ display: 'block' });
        $('#furtherInfo').css({ display: 'block' });
        window.scroll(0, $(document).scrollTop() + 1);
        window.scroll(0, $(document).scrollTop() - 1);
    }
}

function ToDisableNavigationArrows() {
    return $(window).height() < 768 || $(window).width() < 768 || ($(window).width() < 768 && $('#Contact').parent().find('div').hasClass('border-div-active'));
}


//google analytics plugin

window.dataLayer = window.dataLayer || [];
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'UA-171792787-1');