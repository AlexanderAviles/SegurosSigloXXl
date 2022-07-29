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
    public class AdiccionesController : Controller
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLAdicciones Adiccion = new BLAdicciones();
        private Usuarios oUsurio;
        // GET: Adicciones
        [VerificaSession("Colaborador")]
        public ActionResult Adicciones()
        {
            oUsurio = (Usuarios)Session["Usuario"];

            if(oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();

        }

        public ActionResult AdiccionesSelect(string Nombre)
        {
            // Variable que contiene las adicciones.
            List<pa_Adicciones_Select_Result> ModeloVista = this.DBSeguros.pa_Adicciones_Select(Nombre).ToList();
            return Json(ModeloVista);

        }

        public ActionResult InsertarAdiccion(pa_Adicciones_Select_Result Modelo)
        {
            var (mensaje, err) = Adiccion.InsertarAdiccion(Modelo.Nombre, Modelo.Descripcion, Modelo.Codigo);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

        public ActionResult EliminarAdiccion(int IdAdiccion)
        {
            var (mensaje, err) = Adiccion.EliminarAdiccion(IdAdiccion);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

        public ActionResult CargarDatos(int IdAdiccion)
        {
            // Variable que contiene las adicciones.
            pa_Adicciones_Select_Id_Result DatosAdiccion = new pa_Adicciones_Select_Id_Result();

            DatosAdiccion = this.DBSeguros.pa_Adicciones_Select_Id(IdAdiccion).FirstOrDefault();
            return Json(DatosAdiccion);

        }
        public ActionResult ModificarAdiccion(pa_Adicciones_Select_Result M)
        {
            var (mensaje, err) = Adiccion.ModificarAdiccion(M.IdAdiccion, M.Nombre, M.Descripcion, M.Codigo);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

        public ActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no tiene permisos para ver esta pagina";
            return View();
        }
    }
}