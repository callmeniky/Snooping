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
                console.log(data.Result);
                return data.Result;
            });
        }
    }

     BuscarCriterio = function (criterio) {

            if (criterio.startsWith('#'))
                BuscarHashtag(criterio);
            else
                BuscarPerfil(criterio);
        }

    BuscarHashtag = function (criterio) {

            $.post('/Hashtag/Buscar', { criterio: criterio }, function (data) {
                $('body').html(data);
            });
        }

    BuscarPerfil = function (criterio) {

            $.post('/Profile/Perfiles', { criterio: criterio }, function (data) {
                $('body').html(data);
            });
        }

});