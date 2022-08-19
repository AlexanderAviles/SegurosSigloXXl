"use strict";

// Asignacion de elementos a variables.
var FormAdiccion = $("#FrmAdicciones");
var DivForm = $("#Formulario");
var BtnExpandir = $("#BtnExpandir");
var BtnInsertar = $("#BtnInsertar");
var BtnModificar = $("#BtnModificar");
var BtnCancelar = $("#BtnCancelar");
var BtnCancelarFiltro = $("#BtnCancelarFiltro");
var Template = $("#Plantilla");
var Buscador = $("#Buscador");
var Tabla = $("#Tabla");
var Inputs = $("input");
var TextArea = $("textarea");
var CuerpoTabla = $("#CuerpoTabla");

// Pagina cargada para utilizarse.
$(function () {

    // Ocultamos div donde se encuentra formulario de Insertar y el boton de modificar.
    DivForm.hide();
    BtnModificar.hide();
    // Validacion de formulario, el cual evita
    // que se manden datos no deseados a la base de datos.
    ValidarFormulario();

    // Refresca la tabla de adicciones, en este caso,
    // por ser la primera vez que se carga la pagina,
    // se cargan todos los existentes.
    CargarCatalogoAdicciones("");

    // Anima la tabla cuando se esta realizando la busqueda.
    AnimacionTabla();

    // Funcionalidad de los botones de la pagina.
    AccionesBotones();

    // Filtrado de datos
    BuscarAdiccion();
});

// Funcion que muestra y oculta el formulario.
function AccionesBotones() {
    
    // Si se preciona el boton, se muestra el div con el formulario.
    BtnExpandir.click(function () {
        DivForm.toggle('slow');

        // Si el boton de "Guardar" esta oculto, lo vuelve a mostrar y oculta el boton de modificar
        BtnInsertar.show();
        BtnModificar.hide();
    });

    // Validacion del formulario antes de enviar los datos.
    BtnInsertar.click(function () {

        if (FormAdiccion.valid()) {
            // Se insertan los datos mediante ajax
            InsertarPost();

            // Click automatico para limpiar el formulario
            //BtnCancelar.trigger('click');

            // Todos los elementos del formulario regresan a su estado por default.
            ElementosDefault();
        }
        
    });

    // Cancela la busqueda realizada, es decir, carga la lista de 
    // todos los registros de la tabla
    BtnCancelarFiltro.click(function () {
        CancelarBusqueda();
    });

    // Recarga la pagina cuando el usuario ya no quiera registrar una nueva adiccion.
    BtnCancelar.click(function () {
        location.reload();
    });
}

// Todos los elementos del formulario, los devuelve a su estado default.
function ElementosDefault() {
    DivForm.css("display", "none");
    Inputs.removeClass("valid");
    TextArea.removeClass("valid");

    Inputs.removeClass("error");
    TextArea.removeClass("error");
    
}

// Validacion de formulario
function ValidarFormulario() {
    FormAdiccion.validate({
        rules: {
            Nombre: {
                required: true,
                maxlength: 50
            },
            Descripcion: {
                required: true,
                maxlength: 150
            },
            Codigo: {
                required: true,
                maxlength: 10
            },
            submitHandler: function (form) {
                alert("Datos validos");
            }
        }
    });
}

// Funcion utilizada para cargar el catalogo de adicciones,
// el cual recibe el nombre de la adiccion para buscar en el catalogo
function CargarCatalogoAdicciones(Nombre) {

    // Direccion a donde se enviaran los datos
    var url = "/Adicciones/AdiccionesSelect";

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

            var adiccion = this;

            var adicciones = '<tr>'
            adicciones += '<td>' + adiccion.Nombre + '</td>'
            adicciones += '<td>' + adiccion.Descripcion + '</td>'
            adicciones += '<td>' + adiccion.Codigo + '</td>'
            adicciones += '<td><a onclick="ModificarAdiccion(' + adiccion.IdAdiccion + ')" class="btn btn-warning" title="Modificar"><i class="bi bi-pencil"></i></a></td>'
            adicciones += '<td><a onclick="EliminarAdiccion(' + adiccion.IdAdiccion + ')" class="btn btn-danger" title="Eliminar"><i class="bi bi-file-earmark-x"></i></a></td>'
            adicciones += '</tr>';
            CuerpoTabla.append(adicciones);
        });
    } else {
        var adicciones = '<tr>'
        adicciones += '<th colspan="7" >*** NO SE ENCONTRO EL RESULTADO BUSCADO ***</th>'
        adicciones += '</tr>';
        CuerpoTabla.append(adicciones);
    }
}

// Funcion utilizada para buscar en la tabla por nombre de adiccion.
function BuscarAdiccion() {

    // Refresca la tabla de adicciones
    // en este caso, se hacen peticiones consecutivas a la base de datos,
    // hasta obtener el registro (Adiccion) deseado.
    Buscador.keyup(() => {
        let Adiccion = Buscador.val();
        CargarCatalogoAdicciones(Adiccion);

        // Anima la tabla cuando se esta realizando la busqueda.
        AnimacionTabla();
    });
    
}

// Funcion que cancela la busqueda que se esta realizando (Limpia la caja de texto del buscador)
function CancelarBusqueda() {
    CargarCatalogoAdicciones("");
    Buscador.val("");
    AnimacionTabla();
}

// Animacion sencilla de la tabla.
function AnimacionTabla() {
    // Oculta los controles del formulario para generar el efecto de caida.
    Tabla.hide();
    Tabla.slideDown();
}

// Funcion que se encarga de mandar los datos al metodo del controlador
// para insertar las adicciones a la base de datos.
function InsertarPost() {
    // Direccion donde se enviaran los datos.
    var url = "/Adicciones/InsertarAdiccion";

    // Captura de datos que se enviaran.
    var Datos = {
        Nombre: $("#Adiccion").val(),
        Descripcion: $("#Descripcion").val(),
        Codigo: $("#Codigo").val().toUpperCase()
    };

    // Invocar metodo Ajax.
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
            CargarCatalogoAdicciones("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

// Funcion que se encargar de mandar el Id de la adiccion al metodo del controlador
// para que este pueda eliminar la adiccion.
function EliminarPost(IdAdiccion) {
    // Direccion donde se enviaran los datos.
    var url = "/Adicciones/EliminarAdiccion";

    // Capatura el Id de la adiccion que se eliminara.
    var Id = { IdAdiccion: IdAdiccion}
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Id),
        success: function (data, textStatus, jQxhr) {

            // Mensaje el cual muestra si se realizo con exito la eliminacion de datos.
            MensajeEliminar(data);

            // Refresca la tabla de adicciones
            CargarCatalogoAdicciones("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

// Funcion que elimina la adiccion de la base de datos.
function EliminarAdiccion(Id) {
    // Si el panel de formulario esta abierto, lo cierra automaticamente.
    DivForm.slideUp();
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: '¿Eliminar adiccion?',
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

// Funcion que se encarga de consultar la adiccion que se quiere modificar a la base de datos
// para poder cargar los datos actuales en el formulario.
function CargarDatos(IdAdiccion) {
    // Direccion donde se enviaran los datos.
    var url = "/Adicciones/CargarDatos";

    // Capatura el Id de la adiccion que se eliminara.
    var Id = { IdAdiccion: IdAdiccion }

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

// Funcion que se encargar de mandar el Id de la adiccion al metodo del controlador
// para que este pueda  editar la adiccion.
function ModificarPost(IdAdiccion) {

    // Direccion donde se enviaran los datos.
    var url = "/Adicciones/ModificarAdiccion";

    // Captura de datos que se modificaran.
    var Datos = {
        IdAdiccion: IdAdiccion,
        Nombre: $("#Adiccion").val(),
        Descripcion: $("#Descripcion").val(),
        Codigo: $("#Codigo").val().toUpperCase()
    };

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(Datos),
        success: function (data, textStatus, jQxhr) {
            // Mensaje el cual muestra si se realizo con exito la modificacion de datos
            // a la base de datos.
            MensajeModificar(data);

            // Refresca la tabla de adicciones
            CargarCatalogoAdicciones("");

            // Anima la tabla cuando se esta realizando la busqueda.
            AnimacionTabla();
        },
        error: function () {
            alert(errorThrown);
        }
    });
}

// Carga los datos actuales en el formulario para poder ser modificados.
function ProcesarDatosModificables(data) {
    $("#Adiccion").val(data.Nombre);
    $("#Descripcion").val(data.Descripcion);
    $("#Codigo").val(data.Codigo);
}

// Funcion que modifica los datos de la adiccion seleccionada.
function ModificarAdiccion(Id) {
    // No importa la localizacion de la pagina, siempre que se quiera modificar una adiccion
    // se llevara al usuario a la parte superior de la pagina (top)
    $(window).scrollTop(0);
    // Muestra el formulario.
    DivForm.slideDown();
    // Oculta el boton de insertar.
    BtnInsertar.hide();
    // muestra el boton de modificar.
    BtnModificar.show();
    // Carga los datos de la adiccion seleccionada.
    CargarDatos(Id);

    // Cuando se le de click al boton modificar, modificara los datos de la adiccion.
    BtnModificar.click(function () {
        if (FormAdiccion.valid()) {
            ModificarPost(Id);
        } 
    });
}

// Mensajes que se mostraran al usuario si insertar una nueva adiccion
// a la base de datos o si esta misma produjo un error.
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
}

// Mensajes que se mostraran al usuario si elimina con exito una adiccion,
// tambien si se genero un error al tratar de eliminar la adiccion.
function MensajeEliminar(data) {
    var error = data.resultError;
    var mensaje = data.resultMensaje;
    if (error == false) {
        Swal.fire({
            icon: 'success',
            title: 'Adiccion eliminada',
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
