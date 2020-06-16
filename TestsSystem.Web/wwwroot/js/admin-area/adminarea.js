$(document).ready(function () {
    var requestToken = $('input[name="__RequestVerificationToken"]').val();

    $(document).on('click touchstart', '.c-sidebar-nav-item', function () {
        $.post('/adminarea/appusers', {
            role: $(this).attr('data-target'),
            __RequestVerificationToken: requestToken
        }, function (res) {
            $('#_main_area').empty();
            $('#_main_area').append(res);
        });
    });
});