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

window.setInterval(refreshViewers, 5000);

function refreshViewers() {
    var current = $('#views .views-num-extender').html();
    $.ajax({
        type: 'GET',
        url: '../api/GetViewers',
        dataType: 'text',
        async: true,
        success: function (data) {
            if (parseInt(data) != parseInt(current)) {
                if ($('#views div').hasClass('views-bottom-to-top')) {
                    $('#views div').find('.views-num-extender').html(data);
                    $('#views div').find('.views-num-bottom').html(data).parent().removeClass('views-bottom-to-top').addClass('views-top-to-bottom');
                }
                else if ($('#views div').hasClass('views-top-to-bottom')) {
                    $('#views div').find('.views-num-extender').html(data);
                    $('#views div').find('.views-num-top').html(data).parent().removeClass('views-top-to-bottom').addClass('views-bottom-to-top');
                }
            }
        }, error(xhr) {
            if ($('#views div').hasClass('views-bottom-to-top')) {
                $('#views div').find('.views-num-extender').html('0');
                $('#views div').find('.views-num-bottom').html('0').parent().removeClass('views-bottom-to-top').addClass('views-top-to-bottom');
            }
            else if ($('#views div').hasClass('views-top-to-bottom')) {
                $('#views div').find('.views-num-extender').html('0');
                $('#views div').find('.views-num-top').html('0').parent().removeClass('views-top-to-bottom').addClass('views-bottom-to-top');
            }
        }
    });
}


//google analytics plugin

window.dataLayer = window.dataLayer || [];
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'UA-171792787-1');