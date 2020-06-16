$(document).ready(function () {
    var requestToken = $('input[name="__RequestVerificationToken"]').val();

    //$(document).on('click touchstart', '._add_answer_btn', function () {
    //    $.post('/studentarea/AnswerModal', {
    //        answId: $(this).attr('data-answerId'),
    //        questId: $(this).attr('data-questionId'),
    //        __RequestVerificationToken: requestToken
    //    }, function (res) {
    //        $('#_add_answer_modal').empty();
    //        $('#_add_answer_modal').append(res);
    //    });
    //});
});