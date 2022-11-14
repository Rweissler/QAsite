$(() => {

    setInterval(updateLikes, 1000);

    $('#like-question').on('click', function () {
        likeQuestion();
    })

    function updateLikes() {
        const id = $('#question-id').val();
        $.get('/questions/getquestionlikes', { id }, function (result) {
            $('#likes-count').html(result.likes);
        })
    }

    function likeQuestion() {
        const questionID = $('#question-id').val();
        $.post('/questions/LikeQuestion', { questionID }, function () {
            $('#like-question').addClass('text-danger');
            $('#like-question').prop('disabled', true);
            updateLikes();
        })
    }

})