$( window ).ready(function() {
    var distancia = $('#ultraSonico').val();
    $('#distanciaDisplay').text(distancia);
});
$("#ultraSonico").change(function() {
    var lightValue = $('#light').val();
    var distancia = $('#ultraSonico').val();

    $('#distanciaDisplay').text(distancia);
    $('.espaco').css('width', distancia + 'px');
    $('.status-espaco').css('width', distancia + 'px');

    if (distancia <= 30 && lightValue == 0) {
        $('.garage').css('background-image', 'url("img/fundo-on.png")');
        lightValue = 1;
    } else if (distancia > 30 && lightValue == 1) {
        $('.garage').css('background-image', 'url("img/fundo-off.png")');
        lightValue = 0;
    }
    $('#light').val(lightValue);
});
