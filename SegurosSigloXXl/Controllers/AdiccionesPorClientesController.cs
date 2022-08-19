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
    public class AdiccionesPorClientesController : Controller
    {
        #region INSTANCIAS DE DATOS
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLAdiccionesCliente BLAdiccionesClientes = new BLAdiccionesCliente();
        readonly BLCLientes Cliente = new BLCLientes();
        readonly Correo CorreoElectronico = new Correo();
        private Usuarios oUsurio;
        private Clientes oCliente;
        #endregion FIN INSTANCIAS DE DATOS

        #region VISTA ADICCIONES POR CLIENTE
        // GET: AdiccionesPorClientes
        public ActionResult AdiccionesPorClientes()
        {
            List<pa_AdiccionesEncabezado_Select_Result> modeloVista = new List<pa_AdiccionesEncabezado_Select_Result>();
            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                Session["PrimeraVez"] = "false";
                if (oUsurio.TipoUsuario == "Cliente")
                {
                    modeloVista = this.DBSeguros.pa_AdiccionesEncabezado_Select(oCliente.IdCliente).ToList();
                    return View(modeloVista);
                }
                else
                {
                    modeloVista = this.DBSeguros.pa_AdiccionesEncabezado_Select(null).ToList();
                    return View(modeloVista);
                }
            }
            return View(modeloVista);
        }
        #endregion FIN VISTA ADICCIONES POR CLIENTE

        #region VISTA CLIENTE REGISTRO
        public ActionResult ClienteRegistro()
        {
            List<pa_AdiccionesEncabezado_Select_Result> modeloVista = this.DBSeguros.pa_AdiccionesEncabezado_Select(null).ToList();

            return View(modeloVista);
        }
        #endregion FIN VISTA CLIENTE REGISTRO

        #region VISTA CLIENTE HISTORIAL
        public ActionResult ClienteHistorial(int IdCliente)
        {
            pa_Clientes_Select_Id_Result modeloVista = this.DBSeguros.pa_Clientes_Select_Id(IdCliente).FirstOrDefault();
            oUsurio = (Usuarios)Session["Usuario"];
            oCliente = (Clientes)Session["Cliente"];
            if (oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                ViewBag.NombreCliente = oCliente.Nombre + " " + oCliente.PrimerApellido + " " + oCliente.SegundoApellido;
                return View(modeloVista);
            }
            return View(modeloVista);
        }
        #endregion FIN VISTA CLIENTE HISTORIAL

        #region JSON ADICCIONES ENCABEZADO SELECT ID
        public ActionResult AdiccionEncabezadoSelectId(int IdCliente)
        {
            pa_AdiccionesEncabezado_Select_Id_Result ClienteEncabezado = this.DBSeguros.pa_AdiccionesEncabezado_Select_Id(IdCliente).FirstOrDefault();
            return Json(ClienteEncabezado);
        }
        #endregion FIN JSON ADICCIONES ENCABEZADO SELECT ID

        #region JSON DIRECCIONES ID
        public ActionResult DireccionesId(int IdCliente)
        {
            pa_DireccionCliente_Id_Result Direccion = this.DBSeguros.pa_DireccionCliente_Id(IdCliente).FirstOrDefault();
            return Json(Direccion);
        }
        #endregion FIN JSON DIRECCIONES ID

        #region JSON CLIENTE HISTORIAL SELECT
        public ActionResult CLienteHistorialSelect(int IdCliente)
        {
            List<pa_HistorialCliente_Select_Id_Result> modelo = this.DBSeguros.pa_HistorialCliente_Select_Id(IdCliente).ToList();
            ListadoAdicciones(IdCliente);
            return Json(modelo);
        }
        #endregion FIN JSON CLIENTE HISTORIAL SELECT

        #region JSON LISTADO ADICCIONES
        public ActionResult ListadoAdicciones(int IdCliente)
        {
            List<Pa_AdiccionesValidas_Select_Result> Listado = this.DBSeguros.Pa_AdiccionesValidas_Select(IdCliente).ToList();
            return Json(Listado);
        }
        #endregion FIN JSON LISTADO ADICCIONES

        #region JSON CLIENTE HISTORIAL INSERT
        public ActionResult ClienteHistorialInsert(pa_HistorialClientes_Select_Result modelo)
        {
            var (mensaje, err) = this.BLAdiccionesClientes.InsertarAdiccionCliente(modelo.IdAdiccionCliente, modelo.IdAdiccion);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON CLIENTE HISTORIAL INSERT

        #region JSON CLIENTE HISTORIAL UPDATE
        public ActionResult ClienteHistorialUpdate(pa_HistorialClientes_Select_Result modelo)
        {
            var (mensaje, err) = this.BLAdiccionesClientes.ModificarAdiccionCliente(modelo.IdAdiccionDetalle, modelo.IdAdiccionCliente, modelo.IdAdiccion);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON CLIENTE HISTORIAL UPDATE

        #region JSON CARGAR HISTORIAL CLIENTE
        public ActionResult CargarHistorialCliente(int IdCliente, int IdAdiccionDetalle)
        {
            pa_AdiccionesDetalle_Select_Id_Result modeloVista = this.DBSeguros.pa_AdiccionesDetalle_Select_Id(IdCliente, IdAdiccionDetalle).FirstOrDefault();
            return Json(modeloVista);
        }
        #endregion FIN JSON CARGAR HISTORIAL CLIENTE

        #region JSON CLIENTE HISOTIRAL DELETE
        public ActionResult ClienteHistorialDelete(pa_HistorialClientes_Select_Result modelo)
        {
            var (mensaje, err) = this.BLAdiccionesClientes.EliminarAdiccionCliente(modelo.IdAdiccionDetalle);
            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        #endregion FIN JSON CLIENTE HISTORIAL DELETE

    }
}