$(document).ready(function () {
    var requestToken = $('input[name="__RequestVerificationToken"]').val();

    $(document).on('click touchstart', '.c-sidebar-nav-item', function () {
        $.post('/prepodarea/items', {
            item: $(this).attr('data-target'),
            __RequestVerificationToken: requestToken
        }, function (res) {
            $('#_main_area').empty();
            $('#_main_area').append(res);
        });
    });

    $(document).on('click touchstart', '#_add_theme_btn', function () {
        $('#_modal_add_theme_subject').val($(this).attr('data-subject'));
    });
    $(document).on('click touchstart', '#_add_question_btn', function () {
        $('#_modal_add_question_theme').val($(this).attr('data-themeId'));
    });

    $(document).on('change touchstart', '#_subjects_select', function () {
        $.post('/prepodarea/ChangeSubjectSelect', {
            subjId: $(this).val(),
            __RequestVerificationToken: requestToken
        }, function (res) {
                $('#_theme_selected_area').empty();
                $('#_theme_selected_area').append(res);
                $('#_dynamic_questions_area').empty();
        });
    });

    $(document).on('change touchstart', '#_theme_selected_area', function () {
        $.post('/prepodarea/ChangeThemesSelect', {
            themeId: $(this).val(),
            __RequestVerificationToken: requestToken
        }, function (res) {
            $('#_dynamic_questions_area').empty();
            $('#_dynamic_questions_area').append(res);
        });
    });

    $(document).on('click touchstart', '._connect_question_btn', function () {
        $('#_modal_connect_questions').val($(this).attr('data-student'));
    });

    $(document).on('change touchstart', '._select_try', function () {
        $($(this).attr('data-target')).val($(this).attr('data-value'))
    });

    $(document).on('click touchstart', '#_question_add_submit', function () {
        var quests = new Array();

        $.each($('._checked_questions:checkbox:checked'), function (index, value) {
            var answ = new Answer($('#_modal_connect_questions').val(), $(this).val());
            quests.push(answ)
        })

        $.post('/prepodarea/BindQuestions', {
            questions: quests,
            __RequestVerificationToken: requestToken
        }, function (res) {
            $('#_modal_bind_questions').empty();
            $('#_modal_bind_questions').append(res);
        });
    });

    function Answer(studId, questData) {
        this.studentId = studId;
        this.questionData = questData;
        this.state = 'issued';
    }
});