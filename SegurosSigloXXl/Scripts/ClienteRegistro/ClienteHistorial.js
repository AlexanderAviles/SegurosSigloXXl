var CuerpoTabla = $("#CuerpoTabla");
var Cedula = $("#Cedula");
var NombreCompleto = $("#NombreCompleto");
var FechaNacimiento = $("#FechaNacimiento");
var Genero = $("#Genero");
var IdCliente = $("#IdCliente");
var Adicciones = $("#Adicciones");
var DivForm = $("#Formulario");
var Inputs = $("#input");
var BtnExpandir = $("#BtnExpandir");
var BtnInsertar = $("#BtnInsertar");
var BtnModificar = $("#BtnModificar");
var BtnCancelar = $("#BtnCancelar");
var Tabla = $("#Tabla");

$(function () {
    let IdValue = document.getElementById("IdCliente").value;
    DivForm.hide();
    CargaDatos();
    Validaciones();
    AccionesBotones();
    CargarDatosCliente(IdValue);
});

function Validaciones() {

    $("#FrmCoberturas").validate({
        rules: {
            Adicciones: {
                required: true
            },

        }
    });
}
function CargaDatos() {
    let IdValue = document.getElementById("IdCliente").value;
    DireccionCarga(IdValue);
    
    CargarListaAdicciones(IdValue);
    CargarEncabezado(IdValue);
    
}

function CargarEncabezado(IdCliente) {
    var url = "/AdiccionesPorClientes/AdiccionEncabezadoSelectId";

    var parametro = { IdCliente: IdCliente };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametro),
        success: function (data, textStatus, jQxhr) {
            MostrarDatosEncabezado(data);
        },
        error: function () {
        }
    });
}

function MostrarDatosEncabezado(data) {
    $("#IdAdiccionCliente").val(data.IdAdiccionCliente);
    /*$("#IdAdiccionDetalle").val(data.IdAdiccionDetalle);*/
}

function DireccionCarga(IdCliente) {
    var url = "/AdiccionesPorClientes/DireccionesId";

    var parametro = { IdCliente: IdCliente };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametro),
        success: function (data, textStatus, jQxhr) {
            MostrarDireccion(data);
        },
        error: function () {
        }
    });
}

function MostrarDireccion(data) {
    $("#DireccionC").val(data.Provincia);
    var Provincia = data.Provincia.toLowerCase();
    var Canton = data.Canton.toLowerCase();
    var Distrito = data.Distrito.toLowerCase();
    $("#Direccion").html(
        'Dirección: ' + data.Provincia.charAt(0) + Provincia.slice(1) + ', '
        + data.Canton.charAt(0) + Canton.slice(1) + ', '
        + data.Distrito.charAt(0) + Distrito.slice(1) + ', ' + data.DireccionFisica);
}

function AccionesBotones() {
    BtnExpandir.click(function () {
        DivForm.toggle('slow');
        BtnInsertar.show();
        BtnModificar.hide();
        BtnCancelar.hide();
    });
    BtnInsertar.click(function () {

        if ($("#FrmCoberturas").valid()) {
            InsertarPost();
            ElementosDefault();
        }
   
    });
}

function ElementosDefault() {
    DivForm.css("display", "none");
    Inputs.removeClass("valid");
    Inputs.removeClass("error");
}

function AnimacionTabla() {
    Tabla.hide();
    Tabla.slideDown();
}

function CargarDatosCliente(IdCliente) {
    var url = "/AdiccionesPorClientes/CLienteHistorialSelect";

    var parametro = { IdCliente: IdCliente };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametro),
        success: function (data, textStatus, jQxhr) {
            ProcesarDatos(data);
        },
        error: function () {
        }
    });

}

function ProcesarDatos(data) {

    var CuerpoTabla = $("#CuerpoTabla");
    var TipoUsuario = $("#TipoUsuario").val();
    CuerpoTabla.empty();
    if (data.length > 0) {

        $("#Cedula").val(data.Cedula);
        $("#NombreCompleto").val(NombreCompleto);
        $(data).each(function () {
            var AdiccionesCliente = this;
            var AdiccionesTB = '<tr>';
            AdiccionesTB += '<td>' + AdiccionesCliente.NombreAdiccion + '</td>';
            if (TipoUsuario == "Colaborador") {
                //AdiccionesTB += '<td><a class="btn btn-warning" onclick="ModificarAdiccionesCliente(' + AdiccionesCliente.IdAdiccionDetalle + ')" title="Modificar"><i class="bi bi-cloud-upload"></a></td>'
                AdiccionesTB += '<td><a class="btn btn-danger" onclick="EliminarAdiccionCLiente(' + AdiccionesCliente.IdAdiccionDetalle + ')" title="Eliminar"><i class="bi bi-file-earmark-x"></i></a></td>'
            }
            AdiccionesTB += '</tr>';
            CuerpoTabla.append(AdiccionesTB);

        });
    } else {
        var AdiccionesTB = '<tr>';
        AdiccionesTB += '<th colspan="3" >*** NO SE ENCONTRARON RESULTADO***</th>';
        AdiccionesTB += '</tr>';
        CuerpoTabla.append(AdiccionesTB);
    }
}

function CargarListaAdicciones(IdCliente) {
    var url = "/AdiccionesPorClientes/ListadoAdicciones";

    var parametros = { IdCliente: IdCliente };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            DdlLIstaAdicciones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function DdlLIstaAdicciones(data) {
    var DdlAdicciones = $("#Adicciones");

    var nuevaOpcion;
    //var nuevaOpcion = "<option value=''>Seleccione una adiccion </option>";
    //DdlAdicciones.append(nuevaOpcion);
    $(data).each(function () {
        var AdiccionActual = this;
        nuevaOpcion = "<option value='" + AdiccionActual.IdAdiccion + "'>" + AdiccionActual.Nombre + "</option>";
        DdlAdicciones.append(nuevaOpcion);
    });
}

function InsertarPost() {
    var url = "/AdiccionesPorClientes/ClienteHistorialInsert";

    var Datos = {
        IdAdiccionCliente: $("#IdAdiccionCliente").val(),
        IdAdiccion: $("#Adicciones").val(),
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
            CargaDatos();

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function ModificarPost() {
    var url = "/AdiccionesPorClientes/ClienteHistorialUpdate";

    var Datos = {
        IdAdiccionDetalle: $("#IdAdiccionDetalle").val(),
        IdAdiccionCliente: $("#IdAdiccionCliente").val(),
        IdAdiccion: $("#Adicciones").val(),
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
            CargaDatos();

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function EliminarPost(IdAdiccionDetalle) {
    var url = "/AdiccionesPorClientes/ClienteHistorialDelete";

    var Id = { IdAdiccionDetalle: IdAdiccionDetalle }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Id),
        success: function (data, textStatus, jQxhr) {

            // Mensaje el cual muestra si se realizo con exito la eliminacion de datos.
            MensajeEliminar(data);

            // Refresca la tabla de Coberturas
            CargaDatos();

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function EliminarAdiccionCLiente(IdDetalle) {
    DivForm.slideUp();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: '¿Eliminar AdiccionCliente?',
        text: '¡Los archivos borrados, ya no se pueden recuperar!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'si, ¡Borrar!',
        cancelButtonText: 'No, ¡Cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            EliminarPost(IdDetalle);
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire('Cancelado', '¡Se cancelo la operacion de eliminado!', 'error')
        }
    });

}

function CargaDatosModificar(IdAdiccionDetalle) {

    var url = "/AdiccionesPorClientes/CargarHistorialCliente";
    let IdValue = document.getElementById("IdCliente").value;
    var Id = {
        IdCliente: IdValue,
        IdAdiccionDetalle: IdAdiccionDetalle
    }

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
    var DdlAdicciones = $("#Adicciones");
    DdlAdicciones.empty();
    var nuevaOpcion = "<option value='" + data.IdAdiccion + "'>" + data.NombreAdiccion + " </option>";
    DdlAdicciones.append(nuevaOpcion);
    let IdValue = document.getElementById("IdCliente").value;
    CargarListaAdicciones(IdValue);

    $("#IdAdiccionCliente").val(data.IdAdiccionCliente);
    $("#IdAdiccionDetalle").val(data.IdAdiccionDetalle);
}

function ModificarAdiccionesCliente(IdAdiccionesDetalle) {
    $(window).scrollTop(0);

    DivForm.slideDown();

    BtnInsertar.hide();
    BtnModificar.show();
    BtnCancelar.show();
    CargaDatosModificar(IdAdiccionesDetalle);

    BtnCancelar.click(function () {
        location.reload();
    });
    BtnModificar.click(function () {
        ModificarPost();
    });
}

function MensajeInsertar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Adiccion guardada',
            text: mensaje
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: mensaje
        })
    }
    var DdlAdicciones = $("#Adicciones");
    DdlAdicciones.empty();
    var nuevaOpcion = "<option value=''>Seleccione una adiccion </option>";
    DdlAdicciones.append(nuevaOpcion);
    let IdValue = document.getElementById("IdCliente").value;
    CargarDatosCliente(IdValue);
}

function MensajeModificar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Adiccion del cliente modificada.',
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
    var DdlAdicciones = $("#Adicciones");
    DdlAdicciones.empty();
    var nuevaOpcion = "<option value=''>Seleccione una adiccion </option>";
    DdlAdicciones.append(nuevaOpcion);
}

function MensajeEliminar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;

    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Adiccion del cliente eliminada',
            text: mensaje
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: mensaje
        })
    }
    let IdValue = document.getElementById("IdCliente").value;
    CargarDatosCliente(IdValue);
    var DdlAdicciones = $("#Adicciones");
    DdlAdicciones.empty();
    var nuevaOpcion = "<option value=''>Seleccione una adiccion </option>";
    DdlAdicciones.append(nuevaOpcion);
}