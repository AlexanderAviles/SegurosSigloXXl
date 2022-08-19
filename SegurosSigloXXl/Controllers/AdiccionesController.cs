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
        #region INSTANCIAS DE DATOS
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLAdicciones Adiccion = new BLAdicciones();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA ADICCIONES
        // GET: Adicciones
        [VerificaSession("Colaborador")]
        public ActionResult Adicciones()
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
        #endregion FIN VISTA ADICCIONES

        #region JSON DE LISTA DE ADICCIONES
        public ActionResult AdiccionesSelect(string Nombre)
        {
            // Variable que contiene las adicciones.
            List<pa_Adicciones_Select_Result> ModeloVista = this.DBSeguros.pa_Adicciones_Select(Nombre).ToList();
            return Json(ModeloVista);

        }
        #endregion FIN JSON DE LISTA DE ADICCIONES

        #region JSON INSERTAR ADICIONES
        public ActionResult InsertarAdiccion(pa_Adicciones_Select_Result Modelo)
        {
            var (mensaje, err) = Adiccion.InsertarAdiccion(Modelo.Nombre, Modelo.Descripcion, Modelo.Codigo);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

        #endregion FIN JSON INSERTAR ADICCIONES

        #region JSON ELIMINAR ADICCIONES
        public ActionResult EliminarAdiccion(int IdAdiccion)
        {
            var (mensaje, err) = Adiccion.EliminarAdiccion(IdAdiccion);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON ELIMINAR ADICCIONES

        #region JSON CARGAR DATOS
        public ActionResult CargarDatos(int IdAdiccion)
        {
            // Variable que contiene las adicciones.
            pa_Adicciones_Select_Id_Result DatosAdiccion = new pa_Adicciones_Select_Id_Result();

            DatosAdiccion = this.DBSeguros.pa_Adicciones_Select_Id(IdAdiccion).FirstOrDefault();
            return Json(DatosAdiccion);

        }
        #endregion FIN JSON CARGAR DATOS

        #region JSON MODIFICAR ADICCIONES
        public ActionResult ModificarAdiccion(pa_Adicciones_Select_Result M)
        {
            var (mensaje, err) = Adiccion.ModificarAdiccion(M.IdAdiccion, M.Nombre, M.Descripcion, M.Codigo);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON MODIFICAR ADICCIONES
    }
}