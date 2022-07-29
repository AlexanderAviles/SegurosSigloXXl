
//export function estableceeventosChange();
//export function cargaDropdownListProvincias();

//$(function () {
//    ///llamamos a la función que se encargará de crear los eventos
//    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
//    estableceEventosChange();
//    ///Carga inicialmente la lista der provincias, ya que es 
//    //la lista con la que iniciaremos.
//    cargaDropdownListProvincias();
//});


//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
export function estableceEventosChange() {
    $("#Provincia").change(function () {
        var Provincia = $("#Provincia").val();
        cargaDropdownListCantones(Provincia);
    });

    $("#Canton").change(function () {
        var Canton = $("#Canton").val();
        cargaDropdownListDistrito(Canton);
    });
}


///carga los registros de las provincias
export function cargaDropdownListProvincias() {
    ///dirección a donde se enviarán los datos
    var url = '/Clientes/ProvinciasSelect';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
/*        data: JSON.stringify(parametros),*/
        success: function (data, textStatus, jQxhr) {
            procesarResultadoProvincias(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

/*
 * toma el resultado del método RetornaProvincias
 * y lo procesa, recorriendo cada posición
 */
export function procesarResultadoProvincias(data) {
    var ddlProvincias = $("#Provincia");
    ddlProvincias.empty();
    var NuevaOpcion = "<option value=''>Seleccione una provincia</option>"
    ddlProvincias.append(NuevaOpcion);
    $(data).each(function () {
        var ProvinciaActual = this;
        NuevaOpcion = "<option value='" + ProvinciaActual.id_Provincia + "'>" + FormatoCadena(ProvinciaActual.nombre) + "</option>"
        ddlProvincias.append(NuevaOpcion);
    });
}

///carga los registros de los cantones
export function cargaDropdownListCantones(pIdProvincia) {

    ///dirección a donde se enviarán los datos
    var url = '/Clientes/CantonSelect';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Provincia : pIdProvincia
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


export function procesarResultadoCantones(data) {
    var ddlCantones = $("#Canton");
    ddlCantones.empty();
    var nuevaOpcion = "<option value=''>Seleccione uin cantón</option>";
    $(data).each(function () {
        var cantonActual = this;
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + FormatoCadena(cantonActual.nombre) + "</option>";
        ddlCantones.append(nuevaOpcion);
    });
}

///carga los registros de los cantones
export function cargaDropdownListDistrito(pIdCanton) {

    ///dirección a donde se enviarán los datos
    var url = '/Clientes/DistritoSelect';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Canton: pIdCanton
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

export function procesarResultadoDistritos(data) {

    var ddlDistritos = $("#Distrito");

    ddlDistritos.empty();

    var nuevaOpcion = "<option value=''>Seleccione un distrito</option>";

    $(data).each(function () {
        var distritoActual = this;
        nuevaOpcion = "<option value='" + distritoActual.id_Canton + "'>" + FormatoCadena(distritoActual.nombre) + "</option>";
        ddlDistritos.append(nuevaOpcion);
    });
}

// Convierte las cadenas en mayusculas y minusculas
// Primer mayuscula y resto minusculas
export function FormatoCadena(Cadena) {
    return Cadena.charAt(0).toUpperCase() + Cadena.slice(1).toLowerCase();
}