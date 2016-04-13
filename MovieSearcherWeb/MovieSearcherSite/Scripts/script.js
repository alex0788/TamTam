var currentTitle = '';

$('#inSearch').click(function () {
    var title = $('#inTitle').val();
    LoadData(0);
});

function LoadData(offset) {
    var title = $('#inTitle').val();
    Loading(true);
    $.get("Imdb/Movie/GetMovies", {
        title: title, offset:offset }, function (data) {
        if (currentTitle != title) {
            $(".movie-list").empty();
        }
        $(".movie-list").append(data);
        Loading(false);
        jumpToPageBottom();
        currentTitle = title;
    });
}

$('.add-more').click(function () {
    var offset = $('.movie').length;
    LoadData(offset);
});

function Loading(show) {
    if (show == true) {
        $('#load').show();
        $('.movie-list').hide();
    } else {
        $('#load').hide();
        $('.movie-list').show();
    }
}


function jumpToPageBottom() {
    $('html, body').scrollTop($(document).height() - $(window).height());
}
