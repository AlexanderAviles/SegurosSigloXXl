var BtnExpandir = $("#BtnExpandir");
var FormPaso1 = $("#Form-Paso1");
var FormPaso2 = $("#Form-Paso2");
var BtnModificar = $("#BtnModificar");
var BtnCancelar = $("#BtnCancelar");
var Guardar = $("#Guardar");
var BtnP1 = $("#btn-Paso1");
var BtnP2 = $("#btn-Paso2");
var DivForm = $("#Formulario");

var Cobertura = $("#Cobertura");
var Cliente = $("#Cliente");
var MontoAsegurado = $("#MontoAsegurado");


export function paquetePasos() {
    DivForm.hide();

    AccionesBotonesPasos();
    validacionesForm1();
    validacionesForm2();
}
function AccionesBotonesPasos() {
    BtnExpandir.click(function () {
        DivForm.toggle('slow');
        BtnCancelar.hide();
        BtnModificar.hide();
        Guardar.show();
    });
}
function validacionesForm1() {
    FormPaso1.validate({
        rules: {
            Cobertura: {
                required: true
            },
            Cliente: {
                required: true
            },
            MontoAsegurado: {
                required: true
            }
        }
    });
}

function validacionesForm2() {
    FormPaso2.validate({
        rules: {
            MontoAsegurado: {
                required: true
            },
            NumeroAdicciones: {
                required: true
            }
        }
    });
}

const prevBtns = document.querySelectorAll(".btn-prev");
const nextBtns = document.querySelectorAll(".btn-next");

const progreso = document.getElementById("progreso");
const formPasos = document.querySelectorAll(".form-paso");
const ProgresoPasos = document.querySelectorAll(".progreso-paso");

let formPasosNum = 0;

BtnP1.click(function () {
    if (FormPaso1.valid()) {
        formPasosNum++;
        ActualizarPasosFormulario();
        ActualizarBarraProgreso();
    }
});
BtnP2.click(function () {
    if (FormPaso2.valid()) {
        formPasosNum++;
        ActualizarPasosFormulario();
        ActualizarBarraProgreso();
    }
});

prevBtns.forEach((btn) => {
    btn.addEventListener("click", () => {
        formPasosNum--;
        ActualizarPasosFormulario();
        ActualizarBarraProgreso();
    });
});

function ActualizarPasosFormulario() {
    formPasos.forEach(formPasos => {
        formPasos.classList.contains("form-paso-activo") &&
            formPasos.classList.remove("fomr-paso-activo");
    });
    formPasos[formPasosNum].classList.add("form-paso-activo");
}
function ActualizarBarraProgreso() {
    ProgresoPasos.forEach((progresoPaso, idx) => {
        if (idx < formPasosNum + 1) {
            progresoPaso.classList.add("progreso-paso-activo");
        } else {
            progresoPaso.classList.remove("progreso-paso-activo");
        }
    });
    const progressActivo = document.querySelectorAll(".progreso-paso-activo");
    progreso.style.width = ((progressActivo.length - 1) / (ProgresoPasos.length - 1) * 100 + "%");
}