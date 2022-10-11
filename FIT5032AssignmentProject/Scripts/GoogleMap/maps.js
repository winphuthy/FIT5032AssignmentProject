let xmlHttp = new XMLHttpRequest();
xmlHttp.open("Get", "GetServices", false);
xmlHttp.send(null);
let services = JSON.parse(xmlHttp.responseText);

console.log(services);

let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -37.823033, lng: 144.968774 },
        zoom: 11.5,
    });

    // get access from brower
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude,
                };
                map.setCenter(pos);
            },
            () => {
                handleLocationError(true, infoWindow, map.getCenter());
            }
        );
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }

    // add mark

    services.forEach(function (current) {
        console.log(current);
        geolocating(map, current);
    })
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
  infoWindow.setPosition(pos);
  infoWindow.setContent(
    browserHasGeolocation
      ? "Error: The Geolocation service failed."
      : "Error: Your browser doesn't support geolocation."
  );
  infoWindow.open(map);
}

function geolocating(map, service) {
    let geocoder = new google.maps.Geocoder();
    let content = "<h4>" + service.Name + "<h4><br/><p>" + service.Description + "</p>"
    const infowindow = new google.maps.InfoWindow({
        content: content,
    });
    geocoder.geocode({ address: service.Address }, function (result, status) {
        if (status === "OK") {
            var marker = new google.maps.Marker({
                map: map,
                position: result[0].geometry.location
            })
        }
        marker.addListener("click", function () {
            infowindow.open(map, marker)
        });
    });
}

window.initMap = initMap;

