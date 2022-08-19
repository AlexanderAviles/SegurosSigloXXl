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
    public class CoberturasController : Controller
    {
        #region INSTANCIAS DE DATOS
        readonly SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        readonly BLCoberturas BLCoberturas = new BLCoberturas();
        readonly BLAdicciones Adiccion = new BLAdicciones();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA COBERTURAS
        // GET: Coberturas
        [VerificaSession("Colaborador")]
        public ActionResult Coberturas()
        {
            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            Session["PrimeraVez"] = "false";
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                return View();
            }
            return View();
        }
        #endregion FIN VISTA COBERTURAS

        #region JSON COBERTURAS SELECT
        public ActionResult CoberturasSelect(string Nombre)
        {
            List<pa_CoberturaPoliza_Select_Result> ModeloVista = this.BDSeguros.pa_CoberturaPoliza_Select(Nombre).ToList();
            return Json(ModeloVista);
        }
        #endregion FIN JSON COBERTUAS SELECT

        #region JSON COBERTURAS INSERT
        public ActionResult CoberturasInsert(pa_CoberturaPoliza_Select_Result Modelo)
        {
            var (mensaje, err) = this.BLCoberturas.InsertarCobertura(Modelo.Nombre, Modelo.Descripcion, Modelo.Porcentaje);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON COBERTURAS INSERT

        #region JSON COBERTURAS DELETE
        public ActionResult CoberturasDelete(int IdCoberturaPoliza)
        {
            var (mensaje, err) = this.BLCoberturas.EliminarCobertura(IdCoberturaPoliza);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON COBERTURAS DELETE

        #region JSON CARGAR DATOS COBERTURAS
        public ActionResult CargarDatosCoberturas(int IdCoberturaPoliza)
        {
            pa_CoberturaPoliza_Select_Id_Result DatosCoberturas = new pa_CoberturaPoliza_Select_Id_Result();

            DatosCoberturas = this.BDSeguros.pa_CoberturaPoliza_Select_Id(IdCoberturaPoliza).FirstOrDefault();
            return Json(DatosCoberturas);
        }
        #endregion FIN JSON CARGAR DATOS COBERTURAS

        #region JSON COBERTURAS UPDATE
        public ActionResult CoberturasUpdate(pa_CoberturaPoliza_Select_Result pCoberturas)
        {
            var (mensaje, err) = this.BLCoberturas.ModificarCoberturas(pCoberturas.IdCoberturaPoliza, pCoberturas.Nombre, pCoberturas.Descripcion, pCoberturas.Porcentaje);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON COBERTURAS UPDATE

    }
}