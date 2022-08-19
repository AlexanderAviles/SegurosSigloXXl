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
    public class ReporteAdiccionesPorClienteController : Controller
    {
        #region INSTANCIAS DE DATOS
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLAdicciones Adiccion = new BLAdicciones();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA REPORTE DE ADICCIONES POR CLIENTE
        // GET: ReporteAdiccionesPorCliente
        public ActionResult ReporteAdiccionesPorCliente()
        {
            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                ViewBag.IdCliente = oCliente.IdCliente;
                ViewBag.DatosCliente = DBSeguros.pa_Clientes_Select_Datos(oCliente.IdCliente).FirstOrDefault();
                Session["PrimeraVez"] = "false";
                return View();
            }
            return View();
        }
        #endregion FIN VISTA REPORTE DE ADICCIONES POR CLIENTE

        #region JSON RETORNA LISTA ADICCIONES
        public ActionResult RetornaAdiccionesLista()
        {
            List<pa_AdiccionesEncabezado_Select_Result> listaAdicciones =
               this.DBSeguros.pa_AdiccionesEncabezado_Select(null).ToList();
            return Json(new
            {
                resultado = listaAdicciones
            });
        }
        #endregion FIN JSON RETORNA LISTA ADICCIONES

        #region JSON RETORNA LISTA ADICCIONES POR CLIENTE
        public ActionResult RetornaAdiccionesListaPorCliente(int IdCliente)
        {
            List<pa_AdiccionesDetalle_Select_Result> listaAdicciones =
               this.DBSeguros.pa_AdiccionesDetalle_Select(IdCliente).ToList();
            return Json(new
            {
                resultado = listaAdicciones
            });
        }
        #endregion FIN JSON RETORNA LISTA ADICCIONES POR CLIENTE

    }
}