var DivForm = $("#Formulario");
var BtnExpandir = $("#BtnExpandir");
var FormPaso1 = $("#Form-Paso1");
var FormPaso2 = $("#Form-Paso2");
var FormPaso3 = $("#Form-Paso3");
var FormPaso4 = $("#Form-Paso4");

var BtnP1 = $("#btn-Paso1");
var BtnP2 = $("#btn-Paso2");
var BtnP3 = $("#btn-Paso3");
var BtnP4 = $("#btn-Paso4");

$(function () {
    //DivForm.hide();
    //ValidacionesForm1();
    //ValidacionesForm2();
    //ValidacionesForm3();
    //ValidacionesForm4();
    //BtnP1.fadeOut();
    //BtnP2.fadeOut();
    //BtnP3.fadeOut();
    //BtnP4.fadeOut();
    //ValidarForm1();
    //ValidarForm2();
    //ValidarForm3();
    //ValidarForm4();
    ValidarForm1();
    ValidacionesForm2();
    AccionesBotonesPasos();
});


function AccionesBotonesPasos() {
    BtnExpandir.click(function () {
        DivForm.toggle('slow');
    });

    BtnP4.click(function () {

    });
}

function ValidarForm1() {
    FormPaso1.validate({
        rules: {
            Cedula: {
                required: true,
                maxlength: 50
            },
            Nombre: {
                required: true,
                maxlength: 50
            },
            PrimerApellido: {
                required: true,
                maxlength: 50
            },
            SegundoApellido: {
                required: true,
                maxlength: 50
            }
        }
    });
}

function ValidacionesForm2() {
    FormPaso2.validate({
        rules: {
            Provincia: {
                required: true,
            },
            Canton: {
                required: true,
            },
            Distrito: {
                required: true,
            },
            Direccion: {
                required: true,
            }
        }
    });
}

// Inicializacion de elementos para los formularios y botones
const prevBtns = document.querySelectorAll(".btn-prev");
const nextBtns = document.querySelectorAll(".btn-next");
const progreso = document.getElementById("progreso");
const formPasos = document.querySelectorAll(".form-paso");
const progresoPasos = document.querySelectorAll(".progreso-paso")

// Variable donde se contabilizara el numero de paso
let formPasosNum = 0;

nextBtns.forEach((btn) => {
    btn.addEventListener("click", () => {
        if (FormPaso1.valid()) {
            formPasosNum++;
            actualizarPasoFomulario();
            ActualizarBarraProgreso();
        } else {
            alert("Form invalido");
        }

        if (FormPaso2.valid()) {
            formPasosNum++;
            actualizarPasoFomulario();
            ActualizarBarraProgreso();
        } else {
            alert("Form invalido");
        }

    });
});

prevBtns.forEach((btn) => {
    btn.addEventListener("click", () => {
        formPasosNum--;
        actualizarPasoFomulario();
        ActualizarBarraProgreso();
    });
});
function actualizarPasoFomulario() {
    formPasos.forEach(formPasos => {
        formPasos.classList.contains("form-paso-activo") &&
            formPasos.classList.remove("form-paso-activo");
    });
    formPasos[formPasosNum].classList.add("form-paso-activo");
}

function ActualizarBarraProgreso() {
    progresoPasos.forEach((progresoPaso, idx) => {
        if (idx < formPasosNum + 1) {
            progresoPaso.classList.add("progreso-paso-activo");
        } else {
            progresoPaso.classList.remove("progreso-paso-activo");
        }
    });
    const progressActivo = document.querySelectorAll(".progreso-paso-activo");
    progreso.style.width = ((progressActivo.length - 1) / (progresoPasos.length - 1) * 100 + "%");
}