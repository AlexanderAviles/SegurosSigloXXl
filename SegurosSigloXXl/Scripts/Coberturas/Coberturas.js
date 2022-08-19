var FormCoberturas = $("#FrmCoberturas");
var DivForm = $("#Formulario");
var Buscador = $("#Buscador");
var Tabla = $("#Tabla");
var BtnCancelarFiltro = $("#BtnCancelarFiltro");
var BtnExpandir = $("#BtnExpandir");
var BtnModificar = $("#BtnModificar");
var BtnInsertar = $("#BtnInsertar");
var BtnCancelar = $("#BtnCancelar");
var Inputs = $("#input");
var TextArea = $("#textarea");

$(function () {
    DivForm.hide();
    BtnModificar.hide();

    ValidarFormulario();

    CargarCoberturas("");
    AnimacionTabla();
    AccionesBotones();
    BuscarCoberturas();
});

function AccionesBotones() {

    BtnExpandir.click(function () {
        DivForm.toggle('slow');

        BtnInsertar.show();
        BtnModificar.hide();
    });

    BtnInsertar.click(function () {

        if (FormCoberturas.valid()) {
            InsertarPost();

            //BtnCancelar.trigger('click');

            ElementosDefault();
        }
    });

    BtnCancelarFiltro.click(() => {
        CancelarBusqueda();
    });

    BtnCancelar.click(function () {
        location.reload();
    });
}

function ElementosDefault() {
    DivForm.css("display", "none");
    Inputs.removeClass("valid");
    TextArea.removeClass("valid");

    Inputs.removeClass("error");
    TextArea.removeClass("error");
}

function ValidarFormulario() {
    FormCoberturas.validate({
        rules: {
            nombre: {
                required: true,
                maxlength: 50
            },
            Descripcion: {
                required: true,
                maxlength: 150
            },
            porcentaje: {
                required: true,
                maxlength: 10
            },
            submitHandler: function (form) {
                alert("Datos validos");
            }
        }
    });
}

function CargarCoberturas(Nombre) {
    var url = "/Coberturas/CoberturasSelect";

    var parametro = { Nombre: Nombre };

    $.ajax({
        url: url, // Direccion del metodo
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametro), // Parametros convertidos en formato JSON
        // Funcion que se ejecuta cuando la respuesta fue satisfactoria
        // data: contiene el valor retornado por el metodo del servidor
        success: function (data, textStatus, jQxhr) {
            ProcesarDatos(data);
        },
        // Funcion que se ejecuta cuando la respuesta tuvo errores
        error: function () {
            alert(errorThrown);
        }
    });
}

function ProcesarDatos(data) {
    var CuerpoTabla = $("#CuerpoTabla");
    CuerpoTabla.empty();

    if (data.length > 0) {
        $(data).each(function () {
            var Cobertura = this;
            var CoberturasTB = '<tr>'
            CoberturasTB += '<td>' + Cobertura.Nombre + '</td>'
            CoberturasTB += '<td>' + Cobertura.Descripcion + '</td>'
            CoberturasTB += '<td>' + Cobertura.Porcentaje + '%' + '</td>'
            /*             Faltan los eventos Onclick para los botones*/
            CoberturasTB += '<td><a class="btn btn-warning" onclick="ModificarCoberturas(' + Cobertura.IdCoberturaPoliza + ')" title="Modificar"><i class="bi bi-pencil"></i></a></td>'
            CoberturasTB += '<td><a class="btn btn-danger" onclick="EliminarCobertura(' + Cobertura.IdCoberturaPoliza + ')" title="Eliminar"><i class="bi bi-file-earmark-x"></i></a></td>'
            CoberturasTB += '</tr>'
            CuerpoTabla.append(CoberturasTB);
        });
    } else {
        var CoberturasTB = '<tr>'
        CoberturasTB += '<th colspan="4" >*** NO SE ENCONTRO EL RESULTADO BUSCADO ***</th>'
        CoberturasTB += '</tr>';
        CuerpoTabla.append(CoberturasTB);
    }
}

function BuscarCoberturas() {
    Buscador.keyup(() => {
        let Coberturas = Buscador.val();
        CargarCoberturas(Coberturas);
        AnimacionTabla();
    });
}

function AnimacionTabla() {
    Tabla.hide();
    Tabla.slideDown();
}

function CancelarBusqueda() {
    CargarCoberturas("");
    Buscador.val("");
    AnimacionTabla();
}

function InsertarPost() {

    var url = "/Coberturas/CoberturasInsert";

    var Datos = {
        nombre: $("#nombre").val(),
        Descripcion: $("#Descripcion").val(),
        Porcentaje: $("#porcentaje").val()
    };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Datos), // Parametros convertidos en formato JSON.
        // Funcion que se ejecuta cuando la respuesta fue satisfactoria
        // data: contiene el valor retornado por el metodo del servidor
        success: function (data, textStatus, jQxhr) {

            // Mensaje el cual muestra si se realizo con exito la insercion de datos
            // a la base de datos.
            MensajeInsertar(data);

            // Refresca la tabla de adicciones
            CargarCoberturas("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function EliminarPost(IdCobertura) {

    var url = "/Coberturas/CoberturasDelete";
    var Id = { IdCoberturaPoliza: IdCobertura }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Id),
        success: function (data, textStatus, jQxhr) {

            // Mensaje el cual muestra si se realizo con exito la eliminacion de datos.
            MensajeEliminar(data, IdCobertura);

            // Refresca la tabla de Coberturas
            CargarCoberturas("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function EliminarCobertura(Id) {
    DivForm.slideUp();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: '¿Eliminar Cobertura?',
        text: '¡Los archivos borrados, ya no se pueden recuperar!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'si, ¡Borrar!',
        cancelButtonText: 'No, ¡Cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            EliminarPost(Id);
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire('Cancelado', '¡Se cancelo la operacion de eliminado!', 'error')
        }
    });
}

function CargaDatosModificar(IdCoberturaPoliza) {

    var url = "/Coberturas/CargarDatosCoberturas";

    var Id = { IdCoberturaPoliza: IdCoberturaPoliza }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Id),
        success: function (data, textStatus, jQxhr) {

            // Carga los datos obtenidos de la adiccion al formulario
            ProcesarDatosModificables(data);

            //// Refresca la tabla de adicciones
            //CargarCatalogoAdicciones("");

            //// Anima la tabla cuando se esta realizando la busqueda.
            //AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function ProcesarDatosModificables(data) {
    $("#nombre").val(data.Nombre);
    $("#Descripcion").val(data.Descripcion);
    $("#porcentaje").val(data.Porcentaje);
}

function ModificarPost(IdCoberturaPoliza) {

    var url = "/Coberturas/CoberturasUpdate";

    var Datos = {
        IdCoberturaPoliza: IdCoberturaPoliza,
        Nombre: $("#nombre").val(),
        Descripcion: $("#Descripcion").val(),
        Porcentaje: $("#porcentaje").val()
    };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Datos),
        success: function (data, textStatus, jQxhr) {
            // Mensaje el cual muestra si se realizo con exito la insercion de datos
            // a la base de datos.
            MensajeModificar(data);

            // Refresca la tabla de adicciones
            CargarCoberturas("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}
function ModificarCoberturas(Id) {
    $(window).scrollTop(0);

    DivForm.slideDown();

    BtnInsertar.hide();
    BtnModificar.show();
    CargaDatosModificar(Id);


    BtnModificar.click(function () {
        if (FormCoberturas.valid()) {
            ModificarPost(Id);
        }       
    });
}
function MensajeModificar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Cobertura modificada.',
            text: mensaje
        }).then((result) => {
            if (result.isConfirmed) {
                location.reload();
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: mensaje
        })
    }
}
function MensajeEliminar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;

    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Cobertura eliminada',
            Text: mensaje
            
        })
        
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            Text: mensaje
        })
    }
}

function MensajeInsertar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Cobertura guardada',
            text: mensaje
        }).then((result) => {
            if (result.isConfirmed) {
                location.reload();
            }
        });
      
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: mensaje
        })
    }
}
