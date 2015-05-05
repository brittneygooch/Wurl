var loaded = false;
var time = 8000;
$(function () {
    $(window).load(function () {
        loaded = true;
    });
    setTimeout(function () {
        if (!loaded) {
            window.location.reload();
        }
    }, time)
});