// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getData() {
    var data = $("#form").serialize();
    $.getJSON("api/prediccion?" + data, function (data) {
        if (data.esMayorA50) {
            alert("Este perfil indica que gana mas de 50K");
        } else {
            alert("Este perfil indica que NO gana mas de 50k");
        }
    });
}
