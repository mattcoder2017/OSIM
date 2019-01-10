var DummyPage = function () {
    var BindDeleteToJs = function () {

        $(".asyncClass").click(
              function (e) {
                  var link = $(e.target);
                  var id = link.attr("data-value");
                  bootbox.dialog(
                      {
                          message: "Do you really want to remove this product??",
                          title: "Confirmation",
                          buttons:
                              {
                                  no: {
                                      label: "No",
                                      className: "btn-default",
                                      callback: function () { bootbox.hideAll(); }
                                  },
                                  yes: {
                                      label: "Yes",
                                      className: "btn-danger",
                                      callback: function () {
                                          $.ajax(
                                         {
                                             url: "/api/product/" + id,
                                             data:id,
                                             method: "DELETE"
                                         })
                                              .done(function (data) {
                                                  alert(data);
                                                  link.parents("ul").fadeOut(function ()
                                                  { $(this).remove(); })
                                              })
                                              .fail(function (a) {
                                                  alert(a);
                                              })
                                      }
                                  }
                              }
                      }
               )
              })
    };
    var BindSubscribeToJs = function () {

        $(".asyncSubsribe").click(
              function (e) {
                  var link = $(e.target);
                  var id = link.attr("data-value");
                  bootbox.dialog(
                      {
                          message: "Do you really want to get notified when this product has zero inventory??",
                          title: "Confirmation",
                          buttons:
                              {
                                  no: {
                                      label: "No",
                                      className: "btn-default",
                                      callback: function () { bootbox.hideAll(); }
                                  },
                                  yes: {
                                      label: "Yes",
                                      className: "btn-danger",
                                      callback: function () {
                                          $.ajax(
                                         {
                                             url: "/api/ProductSubscription/"+id ,
                                             data: id,
                                             method: "POST"
                                         })
                                              .done(function () {
                                                  alert("Subscribe succesful!");
                                              })
                                              .fail(function (a) {
                                                  alert(a.toString());
                                              })
                                      }
                                  }
                              }
                      }
               )
              })
    };
    return {
        BindDeleteToJs: BindDeleteToJs,
        BindSubscribeToJs: BindSubscribeToJs
    }
}();