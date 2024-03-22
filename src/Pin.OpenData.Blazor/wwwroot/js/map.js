let _map;

window.getCurrentLocation = async () => {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            position => {
                resolve({ latitude: position.coords.latitude, longitude: position.coords.longitude });
            },
            error => {
                reject(error.message);
            }
        );
    });
};

window.initializeMap = async (latitude, longitude) => {
    _map = new ol.Map({
        target: 'map',
        layers: [
            new ol.layer.Tile({
                source: new ol.source.OSM()
            })
        ],
        view: new ol.View({
            center: ol.proj.fromLonLat([longitude, latitude]),
            zoom: 13
        })
    });
};

window.addMarker = async (latitude, longitude) => {
    var markerOverlay = new ol.Overlay({
        position: ol.proj.fromLonLat([longitude, latitude]),
        positioning: 'bottom-center',
        element: document.createElement('div'),
        stopEvent: false
    });

    var markerElement = document.createElement('div');
    markerElement.classList.add('material-icons');
    markerElement.innerHTML = 'location_on';
    markerOverlay.getElement().appendChild(markerElement);

    _map.addOverlay(markerOverlay);
};