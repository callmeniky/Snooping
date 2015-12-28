///<reference path="https://code.angularjs.org/1.2.25/angular.js">
///<reference path="~/Scripts/toastr.js">

$(function () {

    Agregar = function (newSnoop, modal) {
        {
            $.ajax({
                data: JSON.stringify(newSnoop),
                url: "/Snoop/AgregarSnoop",
                method: "POST",
                contentType: "application/json"
            }).done(function (data) {
                if (data.Result) {
                    toastr.success('Se ha insertado su Snoop.');
                    $(modal).modal('hide');
                    location.reload();
                }
                else {
                    toastr.error('Lo sentimos, no hemos podido insertar su Snoop.');
                }

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

    OrdenarLista = function()
    {      
            $(
               $("div.item")
                  .slice(1)
                  .get()
                  .reverse()
             ).insertBefore("div.item:first");
    }


});