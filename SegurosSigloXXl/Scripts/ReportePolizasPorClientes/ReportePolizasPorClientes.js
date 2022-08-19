$(function () {
    obtenerRegistroPolizasPorClientes();
});

function obtenerRegistroPolizasPorClientes() {
    var urlMetodo = "";
    var parametros = {};
    var TipoUsuario = $("#TipoUsuario").val();
    var funcion = "";
    if (TipoUsuario == "Colaborador") {
        urlMetodo = "/ReportePolizasPorClientes/RetornaPolizasLista";
        funcion = crearKendoGridColaborador;
    } else {
        urlMetodo = "/ReportePolizasPorClientes/RetornaPolizasListaPorCliente"
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
        toolbar: ['pdf'],
        pdf: {
            fileName: Cliente + "-Reporte-Coberturas.pdf",
            author: "CLIENTE",
            creator: Cliente,
            date: new Date()

        },
        columns: [
            {
                field: "NombreCoberturaPoliza",
                title: "Cobertura"
            },
            {
                field: "MontoAsegurado",
                title: "Seguro"
            },
            {
                field: "PorcentajeCobertura",
                title: "Porcentaje"
            },
            {
                field: "MontoAdicciones",
                title: "Monto de adicciones"
            },
            {
                field: "PrimaAntesImpuesto",
                title: "Prima antes del impuesto"
            },
            {
                field: "Impuesto",
                title: "Impuesto"
            },
            {
                field: "PrimaFinal",
                title: "Prima final"
            },
            {
                field: "FechaVencimiento",
                title: "Fecha vencimiento",
                template: "#= kendo.toString(kendo.parseDate(FechaVencimiento, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
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
                field: "NombreCliente",
                title: "Cliente"
            },
            {
                field: "NombreCoberturaPoliza",
                title: "Cobertura"
            },
            {
                field: "MontoAsegurado",
                title: "Seguro"
            },
            {
                field: "PorcentajeCobertura",
                title: "Porcentaje"
            },
            {
                field: "MontoAdicciones",
                title: "Monto de adicciones"
            },
            {
                field: "PrimaAntesImpuesto",
                title: "Prima antes del impuesto"
            },
            {
                field: "Impuesto",
                title: "Impuesto"
            },
            {
                field: "PrimaFinal",
                title: "Prima final"
            },
            {
                field: "FechaVencimiento",
                title: "Fecha vencimiento",
                template: "#= kendo.toString(kendo.parseDate(FechaVencimiento, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
            }
        ]
    })

}