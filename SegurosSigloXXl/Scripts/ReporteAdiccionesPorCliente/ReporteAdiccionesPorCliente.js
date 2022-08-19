$(function () {
    obtenerRegistroAdiccionesPorClientes();
});

function obtenerRegistroAdiccionesPorClientes() {
    var urlMetodo = "";
    var parametros = {};
    var funcion = "";
    var TipoUsuario = $("#TipoUsuario").val();
    if (TipoUsuario == "Colaborador") {
        urlMetodo = "/ReporteAdiccionesPorCliente/RetornaAdiccionesLista";
        funcion = crearKendoGridColaborador;
    } else {
        urlMetodo = "/ReporteAdiccionesPorCliente/RetornaAdiccionesListaPorCliente";
        parametros = { IdCliente: $("#IdCliente").val() };
        funcion = crearKendoGridCliente;
    }
    ejecutarAjax(urlMetodo, parametros, funcion);
}

function crearKendoGridCliente(data) {
    var Cliente = $("#NombreCliente").val();
    $("#divKendoGrid").kendoGrid({
        // Asignar la fuente de datos al objeto kendo grid
        dataSource: {
            data: data.resultado,
            pageSize: 10
        },
        pageable: true,
        filterable: true,
        //toolbar: ['pdf'],
        //pdf: {
        //    fileName: Cliente + "-Reporte-Adicciones.pdf",
        //    author: "CLIENTE",
        //    creator: Cliente,
        //    date: new Date()
        //},
        columns: [
            {
                field: "IdAdiccionDetalle",
                title: "Identificador de adicción"
            },
            {
                field: "Adiccion",
                title: "Nombre de adicción"
            }
        ]
    })
}

$(".export-pdf").click(function () {
    var nombre = $("#NombreCliente").val();
    // Convert the DOM element to a drawing using kendo.drawing.drawDOM
    kendo.drawing.drawDOM($(".content-wrapper"))
        .then(function (group) {
            // Render the result as a PDF file
            return kendo.drawing.exportPDF(group, {
                paperSize: "auto",
                margin: { left: "2.54cm", top: "2.54cm", right: "2.54cm", bottom: "2.54cm" }
            });
        })
        .done(function (data) {
            // Save the PDF file
            kendo.saveAs({
                dataURI: data,
                fileName: nombre + ".pdf",
                proxyURL: "https://demos.telerik.com/kendo-ui/service/export"
            });
        });
});
function crearKendoGridColaborador(data) {
    var Cliente = $("#NombreCliente").val();
    $("#divKendoGrid").kendoGrid({
        // Asignar la fuente de datos al objeto kendo grid
        dataSource: {
            data: data.resultado,
            pageSize: 10
        },
        pageable: true,
        filterable: true,
        toolbar: ['pdf'],
        pdf: {
            fileName: Cliente + "-Reporte-Adicciones.pdf",
            author: "COLABORADOR",
            creator: Cliente,
            date: new Date()
        },
        columns: [
            {
                field: "Nombre",
                title: "Nombre del cliente"
            },
            {
                field: "TotalAdicciones",
                title: "Total adicciones"
            },
            {
                title: "Acción",
                template: function (dataItem) {
                    return "<a href='/AdiccionesPorClientes/ClienteHistorial?IdCliente=" + dataItem.IdCliente + "'>Ver adicciones</a>"
                }
            }

        ]
    })
}