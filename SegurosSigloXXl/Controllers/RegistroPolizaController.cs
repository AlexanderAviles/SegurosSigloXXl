using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
using SegurosSigloXXl.BLSeguroSigloXXl;
using SegurosSigloXXl.Filtros;
namespace SegurosSigloXXl.Controllers
{
    [Authorize]
    public class RegistroPolizaController : Controller
    {
        #region INSTANCIAS DE DATOS
        SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        BLRegistroPoliza RegistroPolizaBL = new BLRegistroPoliza();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA REGISTRO POLIZA
        // GET: RegistroPoliza
        [VerificaSession("Colaborador")]
        public ActionResult RegistroPoliza()
        {
            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                Session["PrimeraVez"] = "false";
                return View();
            }
            return View();
        }
        #endregion FIN VISTA REGISTRO POLIZA

        #region JSON REGISTRO POLIZA SELECT
        public ActionResult RegistroPolizaSelect(string NombrePoliza)
        {
            List<pa_RegistroPoliza_Select_Result> modeloVista = new List<pa_RegistroPoliza_Select_Result>();

            modeloVista = this.BDSeguros.pa_RegistroPoliza_Select(NombrePoliza).ToList();

            return Json(modeloVista);
        }
        #endregion FIN JSON REGISTRO POLIZA SELECT

        #region JSON COBERTURAS DE POLIZAS SELECT
        public ActionResult CoberturaPolizaSelect()
        {
            List<pa_CoberturaPoliza_Select_Result> CoberturaPoliza = new List<pa_CoberturaPoliza_Select_Result>();
            CoberturaPoliza = this.BDSeguros.pa_CoberturaPoliza_Select(null).ToList();
            return Json(CoberturaPoliza);
        }
        #endregion FIN JSON COBERTURAS DE POLIZAS SELECT

        #region JSON CLIENTES SELECT
        public ActionResult ClientesSelect()
        {
            List<pa_Clientes_Select_Result> Clientes = new List<pa_Clientes_Select_Result>();
            Clientes = this.BDSeguros.pa_Clientes_Select(null, null).ToList();
            return Json(Clientes);
        }
        #endregion FIN JSON CLIENTES SELECT

        #region JSON REGISTRO POLIZA INSERT
        public ActionResult RegistroPolizaInsert(pa_RegistroPoliza_Select_Result Poliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.InsertarRegistroPoliza(Poliza.IdCoberturaPoliza, Poliza.IdCliente, Poliza.MontoAsegurado, Poliza.FechaVencimiento);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON REGISTRO POLIZA INSERT

        #region JSON REGISTRO POLIZA DELETE
        public ActionResult RegistroPolizaDelete(pa_RegistroPoliza_Select_Result Poliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.EliminarRegistroPoliza(Poliza.IdRegistroPoliza);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON REGISTRO POLIZA DELETE

        #region JSON CARGAR DATOS DE REGISTRO DE POLIZA
        public ActionResult CargarDatosRegistroPoliza(int IdRegistroPoliza)
        {
            pa_RegistroPoliza_Select_Id_Result DatosRegistroPoliza = this.BDSeguros.pa_RegistroPoliza_Select_Id(IdRegistroPoliza).FirstOrDefault();
            return Json(DatosRegistroPoliza);
        }
        #endregion FIN JSON CARGAR DATOS DE REGISTRO DE POLIZA

        #region JSON REGISTRO POLIZA UPDATE
        public ActionResult RegistroPolizaUpdate(pa_RegistroPoliza_Select_Result pRegistroPoliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.ModificarRegistroPoliza(pRegistroPoliza.IdRegistroPoliza, pRegistroPoliza.IdCoberturaPoliza,
                pRegistroPoliza.IdCliente, pRegistroPoliza.MontoAsegurado, pRegistroPoliza.FechaVencimiento);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON REGISTRO POLIZA UPDATE

    }
}
