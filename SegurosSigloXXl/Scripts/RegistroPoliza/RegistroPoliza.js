var BtnModificar = $("#BtnModificar");
var BtnGuardar = $("#Guardar");
var BtnCancelar = $("#BtnCancelar");
var BtnCancelarFiltro = $("#BtnCancelarFiltro");
var Buscador = $("#Buscador");
var Tabla = $("#Tabla");
var Guardar = $("#Guardar");
var FormPaso1 = $("#Form-Paso1");
var DivForm = $("#Formulario");

import { paquetePasos } from './Pasos.js';

$(function () {
    CargaListaRegistroPoliza("");

    BtnModificar.hide();

    BtnCancelar.hide();

    AnimacionTabla();

    BuscarRegistroPoliza();

    CargarDDLCoberturaPoliza();

    CargarDDLClientes();

    paquetePasos();

    AccionesBotones();
});

function AccionesBotones() {
    BtnCancelarFiltro.click(function () {
        CancelarBusqueda();
    });
    Guardar.click(function () {
        if (FormPaso1.valid()) {
            InsertarPost();
            AnimacionTabla();
        }
    });

}

function CargaListaRegistroPoliza(NombrePoliza) {
    var url = "/RegistroPoliza/RegistroPolizaSelect";

    var parametro = { NombrePoliza: NombrePoliza };
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametro),// Parametros convertidos en formato JSON
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
    var cuerpoTabla = $("#CuerpoTabla");
    cuerpoTabla.empty();

    if (data.length > 0) {
        $(data).each(function () {
            var PolizaRegistro = this;
            var tPoliza = '<tr>';

            tPoliza += '<td>' + PolizaRegistro.IdRegistroPoliza + '</td>';
            tPoliza += '<td>' + PolizaRegistro.NombreCobertura + '</td>';
            tPoliza += '<td>' + PolizaRegistro.NombreCliente + '</td>';
            tPoliza += '<td>' + '₡' + PolizaRegistro.MontoAsegurado + '</td>';
            tPoliza += '<td>' + PolizaRegistro.PorcentajeCobertura + '%' + '</td>';
            tPoliza += '<td>' + '₡' + PolizaRegistro.MontoAdicciones + '</td>';
            tPoliza += '<td>' + '₡' + PolizaRegistro.PrimaAntesImpuesto + '</td>';
            tPoliza += '<td>' + '₡' + PolizaRegistro.Impuesto + '</td>';
            tPoliza += '<td>' + '₡' + PolizaRegistro.PrimaFinal + '</td>';
            tPoliza += '<td><a onclick="ModificarRegistroPoliza(' + PolizaRegistro.IdRegistroPoliza + ');" class="btn btn-warning" title="Modificar"><i class="bi bi-pencil"></i></a></td>'
            tPoliza += '<td><a onclick="EliminarRegistroPoliza(' + PolizaRegistro.IdRegistroPoliza + ');" class="btn btn-danger" title="Eliminar"><i class="bi bi-file-earmark-x"></i></a></td>'
            tPoliza += '</tr>';
            cuerpoTabla.append(tPoliza);
        });
    } else {
        var tPoliza = '<tr>';
        tPoliza += '<th colspan="8" class="text-center" >*** NO SE ENCONTRO EL RESULTADO BUSCADO ***</th>';
        tPoliza += '</tr>';
        cuerpoTabla.append(tPoliza);
    }
}

function BuscarRegistroPoliza() {
    Buscador.keyup(() => {
        let Nombre = Buscador.val();
        CargaListaRegistroPoliza(Nombre);

        AnimacionTabla();
    });
}

function CancelarBusqueda() {
    CargaListaRegistroPoliza("");
    Buscador.val("");
    AnimacionTabla();
}

function AnimacionTabla() {
    Tabla.hide();
    Tabla.slideDown();
}

function CargarDDLCoberturaPoliza() {
    var url = "/RegistroPoliza/CoberturaPolizaSelect";

    var parametros = {

    };
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        success: function (data, textStatus, jQxhr) {
            ddlCoberturas(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function ddlCoberturas(data) {
    var ddlPolizas = $("#Cobertura");
    ddlPolizas.empty();
    var nuevaOpcion = "<option value=''>Seleccione una poliza</option>";
    ddlPolizas.append(nuevaOpcion);
    $(data).each(function () {
        var PolizaActual = this;
        nuevaOpcion = "<option value='" + PolizaActual.IdCoberturaPoliza + "'>" + PolizaActual.Nombre + "</option>";
        ddlPolizas.append(nuevaOpcion);
    });
}

function CargarDDLClientes() {
    var url = "/RegistroPoliza/ClientesSelect";

    var parametros = {};
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        success: function (data, textStatus, jQxhr) {
            ddlClientes(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function ddlClientes(data) {
    var ddlClientes = $("#Cliente");
    ddlClientes.empty();
    var nuevaOpcion = "<option value=''>Seleccione un cliente </option>";
    ddlClientes.append(nuevaOpcion);
    $(data).each(function () {
        var clienteActual = this;
        nuevaOpcion = "<option value='" + clienteActual.IdCliente + "'>" + clienteActual.Nombre + " " + clienteActual.PrimerApellido + " " + clienteActual.SegundoApellido + "</option>";
        ddlClientes.append(nuevaOpcion);
    });
}

function InsertarPost() {

    var url = "/RegistroPoliza/RegistroPolizaInsert";

    var Datos = {
        IdCoberturaPoliza: $("#Cobertura").val(),
        IdCliente: $("#Cliente").val(),
        MontoAsegurado: $("#MontoAsegurado").val(),
    }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Datos),
        success: function (data, textStatus, jQxhr) {
            MensajeInsertar(data);
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

function EliminarPost(IdRegistroPoliza) {
    var url = "/RegistroPoliza/RegistroPolizaDelete";

    var Id = { IdRegistroPoliza: IdRegistroPoliza };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Id),
        success: function (data, textStatus, jQxhre) {

            //Mensaje el cual muestra si se realizo con exito la operacion.
            MensajeEliminar(data);

            // refresca la tabla de adicciones.
            CargaListaRegistroPoliza("");

            //Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

window.EliminarRegistroPoliza = function (IdRegistroPoliza) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: '¿Eliminar registro de poliza?',
        text: "¡Los datos borrados, ya no se pueden recuperar!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, ¡Borrar!',
        cancelButtonText: 'No, ¡Cancelar!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            EliminarPost(IdRegistroPoliza);
        } else if (result.dismiss == Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire('Cancelado', '¡Se cancelo la operacion de eliminado!', 'Error');
        }
    });
}

function CargarRegistroPolizaModificar(IdRegistroPoliza) {
    var url = "/RegistroPoliza/CargarDatosRegistroPoliza";

    var IdRegistro = { IdRegistroPoliza: IdRegistroPoliza }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(IdRegistro),
        success: function (data, textStatus, jQxhr) {

            // Carga los datos obtenidos de la adiccion al formulario
            ProcesarDatosRegistroModificables(data);

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

function ProcesarDatosRegistroModificables(data) {
    $("#Cobertura").val(data.IdCoberturaPoliza);
    $("#Cliente").val(data.IdCliente);
    $("#MontoAsegurado").val(data.MontoAsegurado);
}

function ModificarPost(IdRegistroPoliza) {
    var url = "/RegistroPoliza/RegistroPolizaUpdate";

    var Datos = {
        IdRegistroPoliza: IdRegistroPoliza,
        IdCoberturaPoliza: $("#Cobertura").val(),
        IdCliente: $("#Cliente").val(),
        MontoAsegurado: $("#MontoAsegurado").val(),
    }

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
            CargaListaRegistroPoliza("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

window.ModificarRegistroPoliza = function (Id) {
    $(window).scrollTop(0);
    BtnModificar.show();
    BtnCancelar.show();
    DivForm.slideDown();
    BtnGuardar.hide();
    CargarRegistroPolizaModificar(Id);
    BtnModificar.click(function () {
        if (FormPaso1.valid()) {
            ModificarPost(Id);
            AnimacionTabla();
        }
    });
    BtnCancelar.click(function () {
        location.reload();
    });

}

function MensajeInsertar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;

    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Registro de poliza agregado',
            text: mensaje
        }).then((resul) => {
            if (resul.isConfirmed) {
                location.reload();
            }
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error al insertar registro de poliza',
            text: mensaje
        });
    }
}

function MensajeEliminar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;

    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Registro de poliza eliminada',
            text: mensaje
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error al eliminar el registro de poliza',
            text: mensaje
        });
    }
}

function MensajeModificar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;

    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Registro de poliza Modificado',
            text: mensaje
        }).then((result) => {
            location.reload();
        });
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error al modificar el registro de poliza',
            text: mensaje
        }).then((result) => {
            location.reload();
        });
    }
}