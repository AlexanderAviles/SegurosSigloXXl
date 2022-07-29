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
        readonly SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        readonly BLCoberturas BLCoberturas = new BLCoberturas();
        readonly BLAdicciones Adiccion = new BLAdicciones();
        private Usuarios oUsurio;

        // GET: Coberturas
        [VerificaSession("Colaborador")]
        public ActionResult Coberturas()
        {
            oUsurio = (Usuarios)Session["Usuario"];

            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();
        }

        public ActionResult CoberturasSelect(string Nombre)
        {
            List<pa_CoberturaPoliza_Select_Result> ModeloVista = this.BDSeguros.pa_CoberturaPoliza_Select(Nombre).ToList();
            return Json(ModeloVista);
        }
        public ActionResult CoberturasInsert(pa_CoberturaPoliza_Select_Result Modelo)
        {
            var (mensaje, err) = this.BLCoberturas.InsertarCobertura(Modelo.Nombre, Modelo.Descripcion, Modelo.Porcentaje);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        public ActionResult CoberturasDelete(int IdCoberturaPoliza)
        {
            var (mensaje, err) = this.BLCoberturas.EliminarCobertura(IdCoberturaPoliza);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

        public ActionResult CargarDatosCoberturas(int IdCoberturaPoliza)
        {
            pa_CoberturaPoliza_Select_Id_Result DatosCoberturas = new pa_CoberturaPoliza_Select_Id_Result();

            DatosCoberturas = this.BDSeguros.pa_CoberturaPoliza_Select_Id(IdCoberturaPoliza).FirstOrDefault();
            return Json(DatosCoberturas);
        }

        public ActionResult CoberturasUpdate(pa_CoberturaPoliza_Select_Result pCoberturas)
        {
            var (mensaje, err) = this.BLCoberturas.ModificarCoberturas(pCoberturas.IdCoberturaPoliza, pCoberturas.Nombre, pCoberturas.Descripcion, pCoberturas.Porcentaje);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
    }
}