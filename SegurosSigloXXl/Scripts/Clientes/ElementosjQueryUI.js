
export var BtnExpandir = $("#BtnExpandir");

export function CrearElementosjQuery() {
    $("#grupoRadioButtonsSexo").buttonset();
    $("#grupoRadioButtonsTipoUsuario").buttonset();
    CreaCalendario();

    CrearDialog();
    CrearDialogEspera();

    AccionBotonesjQuery();

}

function AccionBotonesjQuery() {
    BtnExpandir.click(() => {
        $(window).scrollTop(0);
        $("#Formulario").dialog("open");
    })
}
function CreaCalendario() {
    $("#FechaNacimiento").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-75:c+1",
        dateFormat: "dd/mm/yy"
    })
}

function CrearDialog() {
    $("#Formulario").dialog({
        autoOpen: false,
        height: 700,
        width: 500,
        modal: true,
        title: "Registro de cliente",
        resizable: false,
        close: function () {
            $("form").trigger("reset");
            $("#btnModificar").hide();
            $("#Guardar").show();
            //inputs.removeClass("error");
        }
    });
}

function CrearDialogEspera() {
    $("#divDialog").dialog({
        autoOpen: false,
        height: 200,
        width: 300,
        modal: true,
        title: "Por favor espere...",
        resizable: false,
        open: function () {
            $(this).parent().children().children('.ui-dialog-titlebar-close').hide();
        }
    });
}