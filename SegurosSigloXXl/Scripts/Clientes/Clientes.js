
// Asignacion de elementos a variables.
var BtnModificar = $("#BtnModificar");
var BtnCancelar = $("#BtnCancelar");
var BtnCancelarFiltro = $("#BtnCancelarFiltro");
var Buscador = $("#Buscador");
var Tabla = $("#Tabla");
var Guardar = $("#Guardar");
var FormPaso4 = $("#Form-Paso4");

/*
    Funciones importadas de los otros archivos .js
    para tener un unico page.ready de jQuery
*/
import { estableceEventosChange } from './Geografia.js';
import { cargaDropdownListProvincias } from './Geografia.js';
import { paquetePasos } from './Pasos.js';

$(function () {

    // Refresca la tabla de clientes, en este caso,
    // por ser la primera vez que se carga la pagina,
    // se cargan todos los existentes.
    CargarListaClientes("");

    // Anima la tabla cuando se esta realizando la busqueda.
    AnimacionTabla();

    // Filtrado de datos
    BucarCliente();

    estableceEventosChange();

    cargaDropdownListProvincias();

    paquetePasos();

    AccionesBotonesCliente();
});

// Funcion que muestra y oculta el formulario.
function AccionesBotonesCliente() {
    // Cancela la busqueda realizada, es decir, carga la lista de 
    // todos los registros de la tabla
    BtnCancelarFiltro.click(function () {
        CancelarBusqueda();
    });

    Guardar.click(function () {
        if (FormPaso4.valid()) {
            InsertarPost();

            AnimacionTabla();
        }


    });
}

// Funcion utilizada para cargar el catalogo de adicciones,
// el cual recibe el nombre de la adiccion para buscar en el catalogo

function CargarListaClientes(Nombre) {

    // Direccion a donde se enviaran los datos
    var url = "/Clientes/ClientesSelect";

    // Parametro que se utiliza para filtrar los datos en la tabla.
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

// Procesa los datos obtenidos de la consulta realizada
function ProcesarDatos(data) {

    var CuerpoTabla = $("#CuerpoTabla");
    CuerpoTabla.empty();

    if (data.length > 0) {
        $(data).each(function () {

            var Cliente = this;
            var anio = new Date().getFullYear(Cliente.FechaNacimiento);
            var mes = new Date().getMonth(Cliente.FechaNacimiento);
            var dia = new Date().getDate(Cliente.FechaNacimiento);
            var Clientes = '<tr>'
            Clientes += '<td>' + Cliente.Cedula + '</td>';
            Clientes += '<td>' + Cliente.Nombre + ' ' + Cliente.PrimerApellido + ' ' + Cliente.SegundoApellido + '</td>'
            Clientes += '<td>' + Cliente.Genero + '</td>'
            Clientes += '<td>' + Cliente.Provincia + ' ' + Cliente.Canton + ' ' + Cliente.Distrito + '</td>'
            Clientes += '<td>' + Cliente.DireccionFisica + '</td>'
            Clientes += '<td>' + dia + '/' + mes + '/' + anio + '</td>'
            Clientes += '<td>' + Cliente.Correo + '</td>'
            Clientes += '<td><a onclick="ModificarCliente(' + Cliente.IdCliente + ');" class="btn btn-warning" title="Modificar"><i class="bi bi-pencil"></i></a></td>'
            Clientes += '<td><a onclick="EliminarCliente(' + Cliente.IdCliente + ');" class="btn btn-danger" title="Eliminar"><i class="bi bi-file-earmark-x"></i></a></td>'
            Clientes += '</tr>';
            CuerpoTabla.append(Clientes);
        });
    } else {
        var Clientes = '<tr>'
        Clientes += '<th colspan="8" class="text-center" >*** NO SE ENCONTRO EL RESULTADO BUSCADO ***</th>'
        Clientes += '</tr>';
        CuerpoTabla.append(Clientes);
    }


}

// Funcion utilizada para buscar en la tabla por nombre de cliente.
function BucarCliente() {

    // Refresca la tabla de clientes
    // en este caso, se hacen peticiones consecutivas a la base de datos,
    // hasta obtener el registro (Cliente) deseado.
    Buscador.keyup(() => {
        let Nombre = Buscador.val();
        CargarListaClientes(Nombre);

        /*         Anima la tabla cuando se esta realizando la busqueda.*/
        AnimacionTabla();
    });

}

// Funcion que cancela la busqueda que se esta realizando (Limpia la caja de texto del buscador)
function CancelarBusqueda() {
    CargarListaClientes("");
    Buscador.val("");
    // Anima la tabla cuando se esta realizando la busqueda.
    AnimacionTabla();
}

// Animacion sencilla de la tabla.
function AnimacionTabla() {
    // Oculta los controles del formulario para generar el efecto de caida.
    Tabla.hide();
    Tabla.slideDown();
}

// Funcion que se encarga de mandar los datos al metodo del controlador
// para insertar los clientes a la base de datos.
function InsertarPost() {
    var url = "/Clientes/InsertaCliente";
    var Datos = {
        Cedula: $("#Cedula").val(),
        Genero: $("#Genero").val(),
        Nombre: $("#Nombre").val(),
        PrimerApellido: $("#PrimerApellido").val(),
        SegundoApellido: $("#SegundoApellido").val(),
        IdProvincia: $("#Provincia").val(),
        IdCanton: $("#Canton").val(),
        IdDistrito: $("#Distrito").val(),
        DireccionFisica: $("#Direccion").val(),
        Telefono: $("#Telefono").val(),
        Correo: $("#Correo").val(),
        FechaNacimiento: $("#FechaNacimiento").val(),
        TipoUsuario: $("#TipoUsuario").val(),
        Contrasenia: ContraseniaRandom()
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

// Genera una contraseña random para el cliente
function ContraseniaRandom() {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 5; i++) {
        result += characters.charAt(Math.floor(Math.random() *
            charactersLength));
    }
    return result;
}

// Funcion que se encargar de mandar el Id del cliente al metodo del controlador
// para que este pueda eliminar el cliente.
function EliminarPost(IdCliente) {
    // Direccion donde se enviaran los datos.
    var url = "/Clientes/EliminarCliente";

    // Captura el Id del cliente que se eliminara.
    var Id = { IdCliente: IdCliente }

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
            CargarListaClientes("");

            //Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

// Funcion que elimina la adiccion de la base de datos.
window.EliminarCliente = function (Id) {
    // Si el panel de formulario esta abierto, lo cierra automaticamente.
    //DivForm.slideUp();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: '¿Eliminar cliente?',
        text: "¡Los datos borrados, ya no se pueden recuperar!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, ¡Borrar!',
        cancelButtonText: 'No, ¡Cancelar!',
        reverseButtons: true
    }).then((result) => {
        // Si el usuario da click en el boton "Si, ¡Borrar!" se eliminara la adiccion
        // de la base de datos
        if (result.isConfirmed) {
            EliminarPost(Id);
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelado',
                '¡Se cancelo la operacion de eliminado!',
                'error'
            )
        }
    });
}

window.ModificarCliente = function(Id) {
    alert("Modificado");
}
// Mensajes que se mostraran al usuario si insertar una nueva adiccion
// a la base de datos o si esta misma produjo un error.
function MensajeInsertar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Cliente registrado',
            text: mensaje
        }).then((result) => {
            // Cuando el usuario de click en "ok" se recargara la pagina
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

// Mensajes que se mostraran al usuario si elimina con exito una adiccion,
// tambien si se genero un error al tratar de eliminar la adiccion.
function MensajeEliminar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Cliente eliminado',
            text: mensaje
        })
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: mensaje
        })
    }
}

// Mensajes que se mostraran al usuario si se modifica una adiccion
// o si esta misma produjo un error.
function MensajeModificar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Adiccion modificada',
            text: mensaje
        }).then((result) => {
            // Cuando el usuario de click en "ok" se recargara la pagina
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
