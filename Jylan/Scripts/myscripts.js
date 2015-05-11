// Customized scripts
// EDITED BY: ASGERV

$(function () {
    $(".datepick").datetimepicker({
        showWeek: true,
        firstDay: 1,
        monthNames: ["Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December"],
        dateFormat: "dd-mm-yy",
        changeYear: true
    });
});

$(document).ready(function () {
    var time = $("#timeleft").val();
    $("#counter").countdown({
        startTime: time,
        format: 'hh:mm:ss',
        image: '/Content/Images/digits.png'
    });
});