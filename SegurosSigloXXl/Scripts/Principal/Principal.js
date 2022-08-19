var vec = 0;
$(function () {
    
    if ($("#PrimeraVez").val() == "true") {
        Bienvenida();
    }
    vec = + 1;
});
function Bienvenida() {
    var url = "/Login/Bienvenida";

    var parametro = {

    };
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
       /* data: JSON.stringify(parametro),*/// Parametros convertidos en formato JSON
        // Funcion que se ejecuta cuando la respuesta fue satisfactoria
        // data: contiene el valor retornado por el metodo del servidor
        success: function (data, textStatus, jQxhr) {
            ProcesarDatosPoliza(data);
        },
        error: function () {
            alert(errorThrown);
        }
    });
}
function ProcesarDatosPoliza(data) {
    if (data.nombre != "") {
        window.onload = Swal.fire({
            position: 'top-end',
            icon: 'info',
            title: "Bienvenido",
            text: data.nombre,
            showConfirmButton: false,
            timer: 2500
        });
    } 
    sessionStorage.setItem("Iniciado", true);

}
function quitarSesion() {
    sessionStorage.clear();
}

