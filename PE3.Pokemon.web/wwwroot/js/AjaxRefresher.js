$(document).ready(function () {
    //var protocol, hostname, port, goToCatchProcesser;
    //protocol = window.location.protocol;
    //hostname = window.location.hostname;
    //port = window.location.port;
    //askMethod = protocol + "//" + hostname + ":" + port + "/Chat/GetFromAjax";
    ////window.location = goToCatchProcesser;
    //setInterval(function () {
    //    $(".row.chat").load(test)
    //}, 1000);
    //alert()
    window.setInterval(test, 1000);
});

function test() {
    var lengte = $('.chat li').length;
    var chatId = $('#chatId').val();
    var url = "/chat/GetFromAjax/" + lengte + "/" + chatId;

    $.get(url,
        function (data) {
            console.log(data);
            if (data !== "") $(".refreshWithAjax").append(data);
        });
}