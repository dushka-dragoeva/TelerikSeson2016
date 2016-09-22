/*global google, $*/

window.onload = (function () {
    var mapDiv = document.getElementById('map');
    var myPromise = new Promise((resolve, reject)=> {
        navigator.geolocation.getCurrentPosition(
            (pos)=> {
                resolve(pos)
            },
            (error)=> {
                reject(error)
            });
    });

    function parsePosition(pos) {
        //  pos=null;
        if (pos) {
            return {
                lat: pos.coords.latitude,
                long: pos.coords.longitude
            }
        } else {
            throw new Error('No coordinates found');
        }
    }

    function initMap(pos) {
        var mapDiv = document.getElementById('map');
        mapDiv.style.width = "600px";
        mapDiv.style.height = "500px";

        var map = new google.maps.Map(mapDiv, {
            center: {lat: pos.lat, lng: pos.long},
            zoom: 15
        });

        var marker = new google.maps.Marker({
            position: {lat: pos.lat, lng: pos.long},
            map: map,
            title: 'Hello World!',
            icon: 'images/map-marker-hi.png',
        });
    }

    function fadeOutMap(selector, time) {
        return new Promise((resolve, reject) => {
            var target = $(selector);
            target.fadeOut(time, null, function () {
                resolve(target);
            });
        });

    }

    function fadeInMap(selector, time) {
        return new Promise((resolve, reject) => {
            var target = $(selector);
            target.fadeIn(time, null, function () {
                resolve(target);
            });
        });
    }

    function displayMessage(error) {
        var errorMessage = document.createElement('strong');
        errorMessage.innerHTML = error.message;
        mapDiv.appendChild(errorMessage);
    }

    myPromise
        .then(parsePosition)
        .then(initMap)
        .catch(displayMessage)
        .then(fadeOutMap('#map', 5000))
        .then(fadeInMap('#map',3000));
}());