$(document).ready(function () {
    var requestToken = $('input[name="__RequestVerificationToken"]').val();

    $(document).on('click touchstart', '#_logout_btn', function () {
        $('#_logout_form').submit();
    });
});