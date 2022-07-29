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
    public class ClientesController : Controller
    {
        readonly SegurosSigloXXlEntities DBSeguros = new SegurosSigloXXlEntities();
        readonly BLCLientes Cliente = new BLCLientes();
        readonly Correo CorreoElectronico = new Correo();
        private Usuarios oUsurio;

        // GET: Clientes
        public ActionResult Clientes()
        {
            oUsurio = (Usuarios)Session["Usuario"];
            if(oUsurio != null)
            {
                ViewBag.TipoUsuario = oUsurio.TipoUsuario;
                return View();
            }
            return View();
        }
        public ActionResult ClientesSelect(string Nombre)
        {
            List<pa_Clientes_Select_Result> ModeloVista = this.DBSeguros.pa_Clientes_Select(Nombre).ToList();
            //ModeloVista = this.DBSeguros.pa_Clientes_Select(Nombre).ToList();
            return Json(ModeloVista);
        }
        public ActionResult ProvinciasSelect()
        {
            List<pa_Provincias_Select_Result> Provincias = this.DBSeguros.pa_Provincias_Select(null).ToList();
            return Json(Provincias);
        }
        public ActionResult CantonSelect(int? id_Provincia = null)
        {
            List<pa_Canton_Select_Result> Cantones = this.DBSeguros.pa_Canton_Select(null, id_Provincia).ToList();
            return Json(Cantones);
        }
        public ActionResult DistritoSelect(int? id_Canton = null)
        {
            List<pa_Distritos_Select_Result> Distritos = this.DBSeguros.pa_Distritos_Select(null, id_Canton).ToList();

            return Json(Distritos);
        }
        public ActionResult InsertaCliente(pa_Clientes_Select_Id_Result C)
        {

            var (mensaje, err) = Cliente.InsertarCliente(C.Cedula, C.Genero, C.FechaNacimiento, C.Nombre,
                                                         C.PrimerApellido, C.SegundoApellido, C.Telefono,
                                                         C.Correo, C.DireccionFisica, C.IdProvincia, C.IdCanton,
                                                         C.IdDistrito, C.Contrasenia, C.TipoUsuario);

            if (!err)
            {
                CorreoElectronico.EnviarCorreoClienteNuevo(C.Correo, C.PrimerApellido + " " + C.SegundoApellido + " " + C.Nombre, C.Contrasenia);
            }

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }
        public ActionResult EliminarCliente(int IdCliente)
        {
            var (mensaje, err) = Cliente.EliminarCliente(IdCliente);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });

        }
        public ActionResult CargarDatosCliente(int IdCliente)
        {
            pa_Clientes_Select_Id_Result DatosCliente = this.DBSeguros.pa_Clientes_Select_Id(IdCliente).FirstOrDefault();
            return Json(DatosCliente);
        }
        public ActionResult ModificarCliente(pa_Clientes_Select_Id_Result C)
        {
            var (mensaje, err) = Cliente.ModificarCliente(C.IdCliente, C.Cedula, C.Genero, C.FechaNacimiento, C.Nombre,
                                                         C.PrimerApellido, C.SegundoApellido, C.Telefono,
                                                         C.Correo, C.DireccionFisica, C.IdProvincia, C.IdCanton,
                                                         C.IdDistrito, C.Contrasenia, C.TipoUsuario);

            return Json(new
            {
                resultMensaje = mensaje,
                resultError = err
            });
        }

    }
}