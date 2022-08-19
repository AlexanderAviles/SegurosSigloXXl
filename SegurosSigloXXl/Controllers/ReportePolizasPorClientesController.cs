using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SegurosSigloXXl.Models;
using SegurosSigloXXl.BLSeguroSigloXXl;
using SegurosSigloXXl.Clases;
using SegurosSigloXXl.Filtros;
namespace SegurosSigloXXl.Controllers
{
    [Authorize]
    public class ReportePolizasPorClientesController : Controller
    {
        #region INSTANCIAS DE DATOS
        // GET: PolizasPorClientes
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLCLientes Cliente = new BLCLientes();
        readonly Correo CorreoElectronico = new Correo();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA REPORTE DE POLIZAS POR CLIENTE
        public ActionResult ReportePolizasPorClientes()
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
        #endregion FIN VISTA REPORTE DE POLIZAS POR CLIENTE

        #region JSON RETORNA LISTA DE POLIZAS
        public ActionResult RetornaPolizasLista()
        {
            List<pa_RegistroPoliza_Reporte_Select_Result> listaAdicciones =
               this.DBSeguros.pa_RegistroPoliza_Reporte_Select().ToList();
            return Json(new
            {
                resultado = listaAdicciones
            });
        }
        #endregion FIN JSON RETORNA LISTA DE POLIZAS

        #region JSON RETORNA LISTA DE POLIZAS POR CLIENTE
        public ActionResult RetornaPolizasListaPorCliente(int IdCliente)
        {
            List<pa_RegistroPoliza_Reporte_Cliente_Select_Result> listaAdicciones =
               this.DBSeguros.pa_RegistroPoliza_Reporte_Cliente_Select(IdCliente).ToList();
            return Json(new
            {
                resultado = listaAdicciones
            });
        }
        #endregion FIN JSON RETORNA LISTA DE POLIZAS POR CLIENTE

    }
}