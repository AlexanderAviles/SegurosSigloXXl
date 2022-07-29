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
    public class RegistroPolizaController : Controller
    {
        SegurosSigloXXlEntities BDSeguros = new SegurosSigloXXlEntities();
        BLRegistroPoliza RegistroPolizaBL = new BLRegistroPoliza();
        private Usuarios oUsurio;
        // GET: RegistroPoliza
        [VerificaSession("Colaborador")]
        public ActionResult RegistroPoliza()
        {
            oUsurio = (Usuarios)Session["Usuario"];

            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();
        }
        public ActionResult RegistroPolizaSelect(string NombrePoliza)
        {
            List<pa_RegistroPoliza_Select_Result> modeloVista = new List<pa_RegistroPoliza_Select_Result>();

            modeloVista = this.BDSeguros.pa_RegistroPoliza_Select(NombrePoliza).ToList();

            return Json(modeloVista);
        }
        public ActionResult CoberturaPolizaSelect()
        {
            List<pa_CoberturaPoliza_Select_Result> CoberturaPoliza = new List<pa_CoberturaPoliza_Select_Result>();
            CoberturaPoliza = this.BDSeguros.pa_CoberturaPoliza_Select(null).ToList();
            return Json(CoberturaPoliza);
        }
        public ActionResult ClientesSelect()
        {
            List<pa_Clientes_Select_Result> Clientes = new List<pa_Clientes_Select_Result>();
            Clientes = this.BDSeguros.pa_Clientes_Select(null).ToList();
            return Json(Clientes);
        }
        public ActionResult RegistroPolizaInsert(pa_RegistroPoliza_Select_Result Poliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.InsertarRegistroPoliza(Poliza.IdCoberturaPoliza, Poliza.IdCliente, Poliza.MontoAsegurado);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        public ActionResult RegistroPolizaDelete(pa_RegistroPoliza_Select_Result Poliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.EliminarRegistroPoliza(Poliza.IdRegistroPoliza);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        public ActionResult CargarDatosRegistroPoliza(int IdRegistroPoliza)
        {
            pa_RegistroPoliza_Select_Id_Result DatosRegistroPoliza = this.BDSeguros.pa_RegistroPoliza_Select_Id(IdRegistroPoliza).FirstOrDefault();
            return Json(DatosRegistroPoliza);
        }
        public ActionResult RegistroPolizaUpdate(pa_RegistroPoliza_Select_Result pRegistroPoliza)
        {
            var (mensaje, err) = this.RegistroPolizaBL.ModificarRegistroPoliza(pRegistroPoliza.IdRegistroPoliza, pRegistroPoliza.IdCoberturaPoliza,
                pRegistroPoliza.IdCliente, pRegistroPoliza.MontoAsegurado);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
    }
}
