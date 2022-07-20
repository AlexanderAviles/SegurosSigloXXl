using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
using SegurosSigloXXl.BLSeguroSigloXXl;

namespace SegurosSigloXXl.Controllers
{
    public class AdiccionesController : Controller
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLAdicciones Adiccion = new BLAdicciones();

        // GET: Adicciones
        public ActionResult Adicciones()
        {
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
    }
}