var data = [];
var source = $("#some-template").html();
var template = Handlebars.compile(source);
$(function () {




    Handlebars.registerHelper('fullName', function (person) {
        return person.firstName + " " + person.lastName;
    });
    Handlebars.registerHelper('get_length', function (obj) {
        return obj.length;
    });   

    //Set the hubs URL for the connection
    $.connection.hub.url = "http://localhost:1454/signalr";

    // Declare a proxy to reference the hub.
    var chat = $.connection.rssHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.addMessage = function (rss) {
        $('#root').empty();
        data = {
            rss
        };
    
        $('#root').append(template(data));
        console.log(data);
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
       chat.server.fetch();
    });
});


