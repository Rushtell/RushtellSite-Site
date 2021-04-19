function google() {
    window.location = "http://google.com"
}

function nextpage() {
    window.location = "ChangerDB/AddPage"
}

function mainpage() {
    window.location = "../"
}

$(function () {
    $('.cap-active').on('click', function () {
        $('.cap').css('display', 'flex');
        $('.block-for-menu').css('display', 'flex');
    });
});

$(function () {
    $('.cap').on('click', function () {
        $('.cap').css('display', 'none');
        $('.block-for-menu').css('display', 'none');
    });
});
