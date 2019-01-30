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
    var url = "/chat/GetFromAjax/" + lengte + "/aa5d39c3-d7bf-41be-a993-08d685f15751";

    $.get(url,
        function (data) {
            console.log(data);
            if (data !== "") $(".refreshWithAjax").append(data);
        });
}