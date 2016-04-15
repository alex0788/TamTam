var offset = 0;
var limit = 3;

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
    offset = 0;
    $('#Back').hide();
    $('#Next').hide();
    MakeSearch();
});
$('#Next').click(function () {
    offset += limit;
    MakeSearch();
});
$('#Back').click(function () {
    if (offset >= limit) {
        offset -= limit;
    }
    MakeSearch();
});

$('#exact').change(function () {
    if ($("#year").prop("disabled") === true) {
        $("#year").prop("disabled", false);
    } else {
        $("#year").prop("disabled", true);
        $('#year').val('');
    }
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
        ShowPagging();
    });
}

function LoadTrailersById(id,offset) {
    Loading(true);
    $.get("Imdb/Movie/GetMoviesById", {
        movid: id, offset: offset
    }, function (data) {
        $(".movie-list").html(data);
        Loading(false);
        ShowPagging();
    });
}

function Loading(show) {
    if (show == true) {
        $('#load').show();
        $('.movie-list').hide();
    } else {
        $('#load').hide();
        $('.movie-list').show();
    }
}

function ShowPagging() {
    var items = $('.movie').length;
    if (items ==limit) {
        $('#Next').show();
    }
    if (offset >= limit) {
        $('#Back').show();
    } else {
        $('#Back').hide();

    }
    if (items<limit && offset>limit) {
        $('#Next').hide();
    }
}

