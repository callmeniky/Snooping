///<reference path="~/Scripts/toastr.js">

//$.getScript("~/Scripts/toastr.js", function () {

//    alert("Script loaded but not necessarily executed.");

//});

$(function () {

    CambiarFoto = function (imagen) {
        {
            $.ajax({
                data: JSON.stringify(imagen),
                url: "/Profile/CambiarFoto",
                method: "POST",
                contentType: "application/json",
                dataType: "json"
            }).done(function (data) {
                if (data.Result)
                    toastr.success("Se ha actualizado su foto de perfil.")
                else
                    toastr.error("Lo sentimos, no hemos podido actualizar su foto de perfil.");
                
            });
        }
    }

});