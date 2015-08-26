// Customized scripts
// EDITED BY: ASGERV

$(function() {
    $(".datepick").datetimepicker({
        showWeek: true,
        firstDay: 1,
        monthNames: ["Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December"],
        monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"],
        dateFormat: "dd-mm-yy",
        changeYear: true,
        changeMonth: true
    });
});

$(document).ready(function() {
    var time = $("#timeleft").val();
    $("#counter").countdown({
        startTime: time,
        format: "hh:mm:ss",
        image: "/Content/Images/digits.png"
    });
});

$(document).ready(function() {
    initialize();
});

function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(55.409856, 8.973934),
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"),
        mapOptions);
    // create a marker
    var latlng = new google.maps.LatLng(55.409856, 8.973934);
    var marker = new google.maps.Marker({
        position: latlng,
        map: map,
        title: "JYLAN @@ Lintrup Aktivitetscenter"
    });
}