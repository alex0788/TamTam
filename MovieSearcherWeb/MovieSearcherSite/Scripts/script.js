var offset = 0;
var limit = 0;

$('#searchType').change(function () {
    if ($(this)[0].value == "title") {
        $('#searchByTitle').show();
        $('#searchById').hide();
    }
    if ($(this)[0].value == "id") {
        $('#searchById').show();
        $('#searchByTitle').hide();
    }
});

$('#Search').click(function () {
    MakeSearch();
});

$('#next').click(function () {
    var count = $('.movie').length;
    if (limit == 0) {
        limit = $('.movie').length;
    }
    offset += count;
    MakeSearch();
});

function MakeSearch() {
    if ($("#searchType option:selected").val() === "title") {
        var title = $('#title').val();
        var year = $('#year').val();
        var exact = $('#exact:checked').length;
        LoadTrailersByTitle(title, year, exact, offset);
    }
    if ($("#searchType option:selected").val() === "id") {
        var movieId = $('#movieId').val();
        LoadTrailersById(movieId, offset);
    }
}

function LoadTrailersByTitle(title, year, exact, offset) {
    Loading(true);
    $.get("Imdb/Movie/GetMoviesByTitle", {
        title:title, year:year, exact:exact, offset:offset
    }, function (data) {
        $(".movie-list").html(data);
        Loading(false);
        currentTitle = title;
    });
}

function LoadTrailersById(id,offset) {
    Loading(true);
    $.get("Imdb/Movie/GetMoviesById", {
        movid: id, offset: offset
    }, function (data) {
        $(".movie-list").html(data);
        Loading(false);
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

