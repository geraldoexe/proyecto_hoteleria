
//CONSUMO DE LA API 
$('.consumir').click(function () {
    $.ajax({
        type: "GET",
        url: "https://www.feriadosapp.com/api/laws.json",
        success: function (data) {
            data.data.forEach(e => {
                $(document.createElement('li'))
                .html(e.id + " - " + e.title + " - " + e.content)
                .appendTo('.informacion');
            });
        },
        dataType: 'json'
    })
});

$('.consumir1').on('change',function () {
    let idopcion = $('#txtsearch').val();
    console.log("OPC");
    console.log(idopcion);
    $.ajax({
        type: "GET",
        url: "https://apis.digital.gob.cl/dpa/regiones",
        success: function(data){
            data.forEach(e => {
                if(idopcion == e.codigo){
                    $(document.createElement('li'))
                    .html("Nombre Region: "+e.nombre + " || Latitud: "+e.lat + " || Longitud: " + e.lng)
                    .appendTo('.informacion1');
                }
             })
        },
        dataType: 'json'
    })
});