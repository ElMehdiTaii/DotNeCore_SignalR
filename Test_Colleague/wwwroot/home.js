var connection = new signalR.HubConnectionBuilder().withUrl("/messageCenterHub").build();

$(document).ready(function () {
    connection.start();
    loadData();
    loadNotification();
});

connection.on("RefreshMessageCentre", function (match) {
    loadData();
    loadNotification();
});

function addDataTest() {
    var data =
    {
        messageObject: $("#messageObject").val(),
        messageContent: $("#messageContent").val(),
        createdDate: new Date(),
    }

    $.ajax({
        type: 'POST',
        url: '/api/Messages',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done(function () {
        //loadData();
        connection.invoke("SendMessages").catch(function (err) {
            return console.error(err.toString());
        });
    });
}


function loadData() {
    $.get("/api/Messages", null, function (response) {
        BindData(response);
    });
}

function loadNotification() {
    $.get("/api/Notifications", null, function (response) {
        BindNotification(response);
    });
}

function BindNotification(notification) {
    $("div#notification").html(notification);
    console.log(notification);
}

function BindData(messages) {
    var html = "";
    $("#messagesList").html("");
    $.each(messages, function (index, message) {
        html += "<li><b>" + message.messageObject + "</b></br>" + message.messageContent + "</li>";
    });
    $("#messagesList").append(html);
}