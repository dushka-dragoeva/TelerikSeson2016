/*global $*/
$(document).ready(function () {

    var popup = $('#popup');
    var time = 10000;

    var promise = new Promise((resolve)=> {
        setTimeout(()=>{
            resolve(showPopup())
        }, 1000);
    });

    function showPopup() {

        var popup = $('#popup');
        popup.addClass('show');
        popup.text('Do you want more?');
        return popup;
    }

    function fadeOutPopup(time) {
        return new Promise((resolve) => {
            // var popup = $('#popup');
            popup.fadeOut(time, null, function () {
                resolve(popup);
                window.location.replace('http://stackoverflow.com/questions/234075/what-is-your-best-programmer-joke');
            });
        })
    }

    function errorMessage(err) {
        popup.text(err.message);
    }

    promise
        .then(fadeOutPopup(time))
        .catch(errorMessage);
}());
