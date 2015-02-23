angular.module("jogApp.Filters", [])
.filter("secToTime", function() {

    return function(seconds) {
        var m = parseInt(seconds / 60);
        var s = seconds - (m * 60);
        var str = m === 0 ? s + " s" : m + " m " + s + " s";
        return str;
    }
})
    .filter("metersToKm", function () {

    return function(meters) {
        var km = parseInt(meters / 1000);
        var m = meters - (km * 1000);
        var str = km === 0 ? meters + " m" : km + " km " + m + " m";
        return str;
    }
})