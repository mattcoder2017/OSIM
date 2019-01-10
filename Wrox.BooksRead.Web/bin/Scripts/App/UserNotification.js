var UserNotification = function () {
    var _notifications;
    var getNotification = function () {
        $.ajax({
            url: "/api/UserNotification/",
            method: "GET"
        })
           .done(function (notifications) {
               //alert(notifications.length);
               _notifications = notifications;
               $(".userNotification")
                   .text(notifications.length)
                   .removeClass("hide")
                   .addClass("animated swing")
           })
           .fail(function () {
           })
        
    };

    var popoverNotification = function()
    {
        $(".userNotification").popover(
             {
                 html: true,
                 title: "Your Notifications",
                 content: function () {
                     //compose a function all compiled with parameter 'name'
                     var compiled = _.template($("#notification-template").html());
                     return compiled({ notifications: _notifications });
                 },
                 placement : "bottom"
                   }
             )
    }

    return {
        GetNotification: getNotification,
        PopoverNotification : popoverNotification
    }
}();