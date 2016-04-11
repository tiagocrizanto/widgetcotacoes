/// <reference path="../../jquery-1.10.0.js" />
/// <reference path="../intranet.mobile.footer.js" />

$(function() {
    $.ajax({
        type: 'GET',
        cache: false,
        url: '/Home/GetCotacoes/',
        dataType: 'json',
        contentType: "application/json; charset=utf-8"
    })
    .then(function (data) {

        var json = $.parseJSON(data);

        $.each(json, function (i, item) {
            var tr = $("<tr>");
            var display = $("<td>");
            $(display).html(item.display);

            var valor = $("<td>");
            $(valor).html(item.valor);
            
            var img = createImage(parseFloat(item.variacao_percentual).toFixed(2));
            var variacao = $("<td>").append(img);

            $(tr).append(display);
            $(tr).append(valor);
            $(tr).append(variacao);

            $("#cotacoes").append(tr);
            
        });
    })
    .fail(function (e) {
        //Em caso de erro
    });
});

function createImage(stats) {
    var img;
    if (stats > 0)
        img = $("<img>").attr("src", "/Content/Images/setinha_up.gif");
    else if (stats < 0)
        img = $("<img>").attr("src", "/Content/Images/setinha_down.gif");

    return img;
}