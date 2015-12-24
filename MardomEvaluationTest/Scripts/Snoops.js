///<reference path="https://code.angularjs.org/1.2.25/angular.js">
///<reference path="~/Scripts/toastr.js">

$(function () {

    Agregar = function (newSnoop) {
        {
            $.ajax({
                data: JSON.stringify(newSnoop),
                url: "/Snoop/AgregarSnoop",
                method: "POST",
                contentType: "application/json"
            }).done(function (data) {
                if (data.Result)
                    toastr.success(data.Mensaje)
                else
                    toastr.error(data.Mensaje);
            });
        }
    }
});