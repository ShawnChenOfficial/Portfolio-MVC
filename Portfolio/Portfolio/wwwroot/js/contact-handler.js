var submitted = false;

$(window).scroll(function () {
    var current = $(document).scrollTop();
    var firstP = $('#contact-form').offset().top;

    if (!ToDisableNavigationArrows()) {
        if (current <= (firstP + 10)) {
            $('#furtherInfo').css({ display: 'block' });
        }
        else {
            $('#furtherInfo').css({ display: 'none' });
        }
    }
});
$('#furtherInfo').click(function () {
    var current = $(document).scrollTop();
    var firstP = $('#contact-form').offset().top;
    var secondP = $('#second-Page').offset().top;
    if (current <= (firstP + 10)) {
        $("html, body").animate({ scrollTop: secondP + 100 }, 1000);
    }
});
function onSubmit() {
    if (!submitted) {
        submitted = true;

        var form = document.getElementById('form-body');
        var formData = new FormData(form);

        $('#form-body button').html('<img src="/images/loading.gif" style="max-height: 20px;"> Sending...');

        $('#form-body span').html('');

        $.ajax({
            type: 'POST',
            url: '../Home/Contact',
            data: formData,
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'json',
            success: function (data) {

                console.log(data);

                try {
                    $.each(data, function (index, item) {
                        $("#" + item.Key + "").parent().find('span').html(item.ErrorMessage);
                    });

                    console.log(111);
                }
                catch (e) {

                    console.log(e);

                    if (data.toString() == 'true') {
                        $('.toast-notification h6').html('Success!');
                        $('.toast-notification p').html('Thanks for your email.I will get in touch with you as soon as possible.');
                        $('.toast-notification').addClass('toast-notification-show-success');

                        setTimeout(function () {
                            $('.toast-notification').removeClass('toast-notification-show-success').addClass('toast-notification-hide-success');
                        }, 2500);

                        setTimeout(function () {
                            $('.toast-notification').removeClass('toast-notification-hide-success');
                        }, 1200);
                    }
                    else {
                        $('.toast-notification h6').html('Ops!');
                        $('.toast-notification p').html('Email was not successfully sent due to a system error, Please try later or manually send me an email through my email at the bottom of this page.');
                        $('.toast-notification').addClass('toast-notification-show-failed');

                        setTimeout(function () {
                            $('.toast-notification').removeClass('toast-notification-show-failed').addClass('toast-notification-hide-failed');
                        }, 2500);

                        setTimeout(function () {
                            $('.toast-notification').removeClass('toast-notification-hide-failed');
                        }, 1200);
                    }
                }

                $('#form-body button').html('Submit');
                submitted = false;
            },
            error: function (xhr) {
                $('.toast-notification h6').html('Ops!');
                $('.toast-notification p').html('Email was not successfully sent due to a system error, Please try later or manually send me an email through my email at the bottom of this page.');
                $('.toast-notification').addClass('toast-notification-show-failed');

                setTimeout(function () {
                    $('.toast-notification').removeClass('toast-notification-show-failed').addClass('toast-notification-hide-failed');
                }, 2500);

                setTimeout(function () {
                    $('.toast-notification').removeClass('toast-notification-hide-failed');
                }, 1200);

                $('#form-body button').html('Submit');
                submitted = false;
            }
        });
    }
}